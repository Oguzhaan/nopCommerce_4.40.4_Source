using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Domain.Cms;
using Nop.Plugin.Widgets.Faqs;
using Nop.Plugin.Widgets.Faqs.Models;
using Nop.Plugin.Widgets.Faqs.Models.Domain;
using Nop.Plugin.Widgets.Faqs.Services;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Messages;
using Nop.Services.Security;
using Nop.Services.Stores;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Plugin.Widgets.Faqs.Controllers
{
    [Area(AreaNames.Admin)]
    [AuthorizeAdmin]
    [AutoValidateAntiforgeryToken]
    public class FaqsController : BasePluginController
    {
        #region Fields

        private readonly ILocalizationService _localizationService;
        private readonly INotificationService _notificationService;
        private readonly IPermissionService _permissionService;
        private readonly ISettingService _settingService;
        private readonly IStoreContext _storeContext;
        private readonly IStoreService _storeService;
        private readonly IFaqsViewTrackerService _faqsViewTrackerService;
        private readonly IWebHelper _webHelper;

        #endregion

        #region Ctor

        public FaqsController(ILocalizationService localizationService,
            INotificationService notificationService,
            IPermissionService permissionService,
            ISettingService settingService,
            IStoreContext storeContext,
            IStoreService storeService,
            IFaqsViewTrackerService faqsViewTrackerService,
            IWebHelper webHelper)
        {
            _localizationService = localizationService;
            _notificationService = notificationService;
            _permissionService = permissionService;
            _settingService = settingService;
            _storeContext = storeContext;
            _storeService = storeService;
            _faqsViewTrackerService = faqsViewTrackerService;
            _webHelper = webHelper;
        }

        #endregion

        #region Methods

        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task<IActionResult> Configure()
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageWidgets)) return AccessDeniedView();

            var storeId = await _storeContext.GetActiveStoreScopeConfigurationAsync();
            var settings = await _settingService.LoadSettingAsync<FaqsSettings>(storeId);
            var widgetSettings = await _settingService.LoadSettingAsync<WidgetSettings>(storeId);
            var model = new ConfigurationModel { WidgetZone = settings.WidgetZone, ActiveStoreScopeConfiguration = storeId };
            if (storeId > 0) { model.WidgetZone_OverrideForStore = await _settingService.SettingExistsAsync(settings, setting => setting.WidgetZone, storeId); }
            return View("~/Plugins/Widgets.Faqs/Views/Configure.cshtml", model);
        }

        public async Task<IActionResult> Add()
        {
            return View("~/Plugins/Widgets.Faqs/Views/Add.cshtml");
        }

        public async Task<IActionResult> List()
        {
            var list = _faqsViewTrackerService.GetAll();
            return View("~/Plugins/Widgets.Faqs/Views/List.cshtml");
        }


        [HttpPost]
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task<IActionResult> Configure(ConfigurationModel model)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageWidgets))
                return AccessDeniedView();

            if (!ModelState.IsValid)
                return await Configure();

            var storeId = await _storeContext.GetActiveStoreScopeConfigurationAsync();
            var settings = await _settingService.LoadSettingAsync<FaqsSettings>(storeId);
            var widgetSettings = await _settingService.LoadSettingAsync<WidgetSettings>(storeId);

            settings.WidgetZone = model.WidgetZone;
            await _settingService.SaveSettingOverridablePerStoreAsync(settings, setting => setting.WidgetZone, model.WidgetZone_OverrideForStore, storeId, false);

            await _settingService.ClearCacheAsync();

            _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Plugins.Saved"));

            return await Configure();
        }

        [HttpPost]
        public async Task<IActionResult> Add(FaqsViewTrackerRecord record)
        {
            _faqsViewTrackerService.InsertAsync(record);
            ViewBag.Message = "Basarili";
            ViewBag.IsSuccess = true;
            return View("~/Plugins/Widgets.Faqs/Views/List.cshtml");
        }
        #endregion
    }
}