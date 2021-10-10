using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Domain.Orders;
using Nop.Core.Domain.Payments;
using Nop.Plugin.Payments.Teqpay.Models;
using Nop.Services.Common;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Logging;
using Nop.Services.Messages;
using Nop.Services.Orders;
using Nop.Services.Payments;
using Nop.Services.Security;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Plugin.Payments.Teqpay.Controllers
{
    public class PaymentTeqpayController : BasePaymentController
    {
        #region Fields

        private readonly IGenericAttributeService _genericAttributeService;
        private readonly IOrderProcessingService _orderProcessingService;
        private readonly IOrderService _orderService;
        private readonly IPaymentPluginManager _paymentPluginManager;
        private readonly IPermissionService _permissionService;
        private readonly ILocalizationService _localizationService;
        private readonly ILogger _logger;
        private readonly INotificationService _notificationService;
        private readonly ISettingService _settingService;
        private readonly IStoreContext _storeContext;
        private readonly IWebHelper _webHelper;
        private readonly IWorkContext _workContext;
        private readonly ShoppingCartSettings _shoppingCartSettings;

        #endregion

        #region Ctor

        public PaymentTeqpayController(IGenericAttributeService genericAttributeService,
            IOrderProcessingService orderProcessingService,
            IOrderService orderService,
            IPaymentPluginManager paymentPluginManager,
            IPermissionService permissionService,
            ILocalizationService localizationService,
            ILogger logger,
            INotificationService notificationService,
            ISettingService settingService,
            IStoreContext storeContext,
            IWebHelper webHelper,
            IWorkContext workContext,
            ShoppingCartSettings shoppingCartSettings)
        {
            _genericAttributeService = genericAttributeService;
            _orderProcessingService = orderProcessingService;
            _orderService = orderService;
            _paymentPluginManager = paymentPluginManager;
            _permissionService = permissionService;
            _localizationService = localizationService;
            _logger = logger;
            _notificationService = notificationService;
            _settingService = settingService;
            _storeContext = storeContext;
            _webHelper = webHelper;
            _workContext = workContext;
            _shoppingCartSettings = shoppingCartSettings;
        }

        #endregion

        #region Methods

        [AuthorizeAdmin]
        [Area(AreaNames.Admin)]
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task<IActionResult> Configure()
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManagePaymentMethods))
                return AccessDeniedView();

            //load settings for a chosen store scope
            var storeScope = await _storeContext.GetActiveStoreScopeConfigurationAsync();
            var teqpayPaymentSettings = await _settingService.LoadSettingAsync<TeqpayPaymentSettings>(storeScope);

            var model = new ConfigurationModel
            {
                UseSandbox = teqpayPaymentSettings.UseSandbox,
                TestApiKey = teqpayPaymentSettings.TestApiKey,
                TestApiSecretKey = teqpayPaymentSettings.TestApiSecretKey,
                TestApiUrl = teqpayPaymentSettings.TestApiUrl,
                LiveApiKey = teqpayPaymentSettings.LiveApiKey,
                LiveApiSecretKey = teqpayPaymentSettings.LiveApiSecretKey,
                LiveApiUrl = teqpayPaymentSettings.LiveApiUrl,
            };

            if (storeScope <= 0)
                return View("~/Plugins/Payments.Teqpay/Views/Configure.cshtml", model);

            model.UseSandbox_OverrideForStore = await _settingService.SettingExistsAsync(teqpayPaymentSettings, x => x.UseSandbox, storeScope);
            model.TestApiKey_OverrideForStore = await _settingService.SettingExistsAsync(teqpayPaymentSettings, x => x.TestApiKey, storeScope);
            model.TestApiSecretKey_OverrideForStore = await _settingService.SettingExistsAsync(teqpayPaymentSettings, x => x.TestApiSecretKey, storeScope);
            model.TestApiUrl_OverrideForStore = await _settingService.SettingExistsAsync(teqpayPaymentSettings, x => x.TestApiUrl, storeScope);
            model.LiveApiKey_OverrideForStore = await _settingService.SettingExistsAsync(teqpayPaymentSettings, x => x.LiveApiKey, storeScope);
            model.LiveApiKey_OverrideForStore = await _settingService.SettingExistsAsync(teqpayPaymentSettings, x => x.LiveApiSecretKey, storeScope);
            model.LiveApiUrl_OverrideForStore = await _settingService.SettingExistsAsync(teqpayPaymentSettings, x => x.LiveApiUrl, storeScope);

            return View("~/Plugins/Payments.Teqpay/Views/Configure.cshtml", model);
        }

        [HttpPost]
        [AuthorizeAdmin]
        [Area(AreaNames.Admin)]
        [AutoValidateAntiforgeryToken]
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task<IActionResult> Configure(ConfigurationModel model)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManagePaymentMethods))
                return AccessDeniedView();

            if (!ModelState.IsValid)
                return await Configure();

            //load settings for a chosen store scope
            var storeScope = await _storeContext.GetActiveStoreScopeConfigurationAsync();
            var teqpayPaymentSettings = await _settingService.LoadSettingAsync<TeqpayPaymentSettings>(storeScope);

            //save settings
            teqpayPaymentSettings.UseSandbox = model.UseSandbox;
            teqpayPaymentSettings.TestApiKey = model.TestApiKey;
            teqpayPaymentSettings.TestApiSecretKey = model.TestApiSecretKey;
            teqpayPaymentSettings.TestApiUrl = model.TestApiUrl;
            teqpayPaymentSettings.LiveApiKey = model.LiveApiKey;
            teqpayPaymentSettings.LiveApiSecretKey = model.LiveApiSecretKey;
            teqpayPaymentSettings.LiveApiUrl = model.LiveApiUrl;

            /* We do not clear cache after each setting update.
             * This behavior can increase performance because cached settings will not be cleared 
             * and loaded from database after each update */
            await _settingService.SaveSettingOverridablePerStoreAsync(teqpayPaymentSettings, x => x.UseSandbox, model.UseSandbox_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(teqpayPaymentSettings, x => x.TestApiKey, model.TestApiKey_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(teqpayPaymentSettings, x => x.TestApiSecretKey, model.TestApiSecretKey_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(teqpayPaymentSettings, x => x.TestApiUrl, model.TestApiUrl_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(teqpayPaymentSettings, x => x.LiveApiKey, model.LiveApiKey_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(teqpayPaymentSettings, x => x.LiveApiSecretKey, model.LiveApiSecretKey_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(teqpayPaymentSettings, x => x.LiveApiUrl, model.LiveApiUrl_OverrideForStore, storeScope, false);

            //now clear settings cache
            await _settingService.ClearCacheAsync();

            _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Plugins.Saved"));

            return await Configure();
        }


        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task<IActionResult> Confirmation()
        {
            if (await _paymentPluginManager.LoadPluginBySystemNameAsync("Payments.Teqpay") is not TeqpayPaymentProcessor processor || !_paymentPluginManager.IsPluginActive(processor))
                throw new NopException("Teqpay Standard module cannot be loaded");

            var (Result, ResultCode, ResultMessage, OrderId, ConversationId, Token) = await processor.GetFormData();

            var order = (await _orderService.GetOrderByIdAsync(Convert.ToInt32(ConversationId)));

            if (order == null) return RedirectToAction("Index", "Home", new { area = string.Empty });
            //order note
            await _orderService.InsertOrderNoteAsync(new OrderNote { OrderId = order.Id, Note = ResultMessage, DisplayToCustomer = false, CreatedOnUtc = DateTime.UtcNow });

            if (ResultCode == "10000")
            {
                order.OrderStatus = OrderStatus.Complete;
                await _orderService.UpdateOrderAsync(order);
                return RedirectToRoute("CheckoutCompleted", new { orderId = order.Id });
            }
            else
            {
                await _logger.ErrorAsync(ResultMessage);
                return RedirectToRoute("OrderDetails", new { orderId = order.Id });
            }

        }
        #endregion
    }
}