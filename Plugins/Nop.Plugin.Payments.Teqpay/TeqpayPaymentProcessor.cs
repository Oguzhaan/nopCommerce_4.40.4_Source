using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using Nop.Core;
using Nop.Core.Domain.Directory;
using Nop.Core.Domain.Orders;
using Nop.Core.Domain.Shipping;
using Nop.Plugin.Payments.Teqpay.Models.Dtos;
using Nop.Plugin.Payments.Teqpay.Services;
using Nop.Services.Catalog;
using Nop.Services.Common;
using Nop.Services.Configuration;
using Nop.Services.Customers;
using Nop.Services.Directory;
using Nop.Services.Localization;
using Nop.Services.Orders;
using Nop.Services.Payments;
using Nop.Services.Plugins;
using Nop.Services.Tax;

namespace Nop.Plugin.Payments.Teqpay
{
    /// <summary>
    /// Teqpay payment processor
    /// </summary>
    public class TeqpayPaymentProcessor : BasePlugin, IPaymentMethod
    {
        #region Fields

        private readonly CurrencySettings _currencySettings;
        private readonly IAddressService _addressService;
        private readonly ICheckoutAttributeParser _checkoutAttributeParser;
        private readonly ICountryService _countryService;
        private readonly ICurrencyService _currencyService;
        private readonly ICustomerService _customerService;
        private readonly IGenericAttributeService _genericAttributeService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILocalizationService _localizationService;
        private readonly ILanguageService _languageService;
        private readonly IOrderService _orderService;
        private readonly IPaymentService _paymentService;
        private readonly IProductService _productService;
        private readonly ISettingService _settingService;
        private readonly IStateProvinceService _stateProvinceService;
        private readonly ITaxService _taxService;
        private readonly IWebHelper _webHelper;
        private readonly TeqpayHttpClient _teqpayHttpClient;
        private readonly TeqpayPaymentSettings _teqpayPaymentSettings;

        #endregion

        #region Ctor

        public TeqpayPaymentProcessor(CurrencySettings currencySettings,
            IAddressService addressService,
            ICheckoutAttributeParser checkoutAttributeParser,
            ICountryService countryService,
            ICurrencyService currencyService,
            ICustomerService customerService,
            IGenericAttributeService genericAttributeService,
            IHttpContextAccessor httpContextAccessor,
            ILocalizationService localizationService,
            ILanguageService languageService,
            IOrderService orderService,
            IPaymentService paymentService,
            IProductService productService,
            ISettingService settingService,
            IStateProvinceService stateProvinceService,
            ITaxService taxService,
            IWebHelper webHelper,
            TeqpayHttpClient teqpayHttpClient,
            TeqpayPaymentSettings teqpayPaymentSettings)
        {
            _currencySettings = currencySettings;
            _addressService = addressService;
            _checkoutAttributeParser = checkoutAttributeParser;
            _countryService = countryService;
            _currencyService = currencyService;
            _customerService = customerService;
            _genericAttributeService = genericAttributeService;
            _httpContextAccessor = httpContextAccessor;
            _localizationService = localizationService;
            _languageService = languageService;
            _orderService = orderService;
            _paymentService = paymentService;
            _productService = productService;
            _settingService = settingService;
            _stateProvinceService = stateProvinceService;
            _taxService = taxService;
            _webHelper = webHelper;
            _teqpayHttpClient = teqpayHttpClient;
            _teqpayPaymentSettings = teqpayPaymentSettings;
        }

        #endregion

        #region Utilities

        /// <summary>
        /// Create common query parameters for the request
        /// </summary>
        /// <param name="postProcessPaymentRequest">Payment info required for an order processing</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the created query parameters
        /// </returns>
        private async Task<TeqpayRequestDto> CreateParametersAsync(PostProcessPaymentRequest postProcessPaymentRequest)
        {
            //get store location
            var storeLocation = _webHelper.GetStoreLocation();

            //choosing correct order address
            var orderAddress = await _addressService.GetAddressByIdAsync(
                (postProcessPaymentRequest.Order.PickupInStore ? postProcessPaymentRequest.Order.PickupAddressId : postProcessPaymentRequest.Order.ShippingAddressId) ?? 0);

            List<Product> productList = new List<Product>();
            var orderItems = (await _orderService.GetOrderItemsAsync(postProcessPaymentRequest.Order.Id));
            foreach (var item in orderItems)
            {
                var product = (await _productService.GetProductByIdAsync(item.ProductId));
                productList.Add(new Product
                {
                    itemPrice = Convert.ToInt32(product.Price),
                    itemQuantity = item.Quantity,
                    itemCategory = "",
                    itemType = product.ProductType.ToString(),
                    merchantItemId = product.Name,
                    itemName = product.Name
                });
            }

            TeqpayRequestDto teqpayRequestDto = new TeqpayRequestDto();
            teqpayRequestDto.billing = new Billing
            {
                billingAddress = orderAddress?.Address1,
                billingCity = orderAddress?.City,
                billingCountry = orderAddress?.County,
                billingName = orderAddress?.Id.ToString(),
            };
            teqpayRequestDto.shipping = new Shipping
            {
                shippingAddress = orderAddress?.Address1,
                shippingCity = orderAddress?.City,
                shippingCountry = orderAddress?.County,
                shippingContactName = orderAddress?.FirstName,
            };
            teqpayRequestDto.installments = new List<string>() { "1", "2", "3" };
            teqpayRequestDto.products = productList;
            teqpayRequestDto.customerName = orderAddress?.FirstName + " " + orderAddress?.LastName;
            teqpayRequestDto.customerIpAddress = postProcessPaymentRequest.Order.CustomerIp;
            teqpayRequestDto.customerCitizenNo = postProcessPaymentRequest.Order.VatNumber;
            teqpayRequestDto.customerEmail = orderAddress?.Email;
            teqpayRequestDto.customerPhone = orderAddress?.PhoneNumber;
            teqpayRequestDto.price = Convert.ToInt32(postProcessPaymentRequest.Order.OrderTotal);
            teqpayRequestDto.currency = (await _currencyService.GetCurrencyByIdAsync(_currencySettings.PrimaryStoreCurrencyId))?.CurrencyCode;
            teqpayRequestDto.conversationId = postProcessPaymentRequest.Order.Id.ToString();
            teqpayRequestDto.callbackUrl = $"{storeLocation}Plugins/PaymentTeqpay/Confirmation";
            teqpayRequestDto.language = (await _languageService.GetLanguageByIdAsync(postProcessPaymentRequest.Order.CustomerLanguageId))?.LanguageCulture;
            teqpayRequestDto.paymentMethodId = "";
            //create query parameters
            return teqpayRequestDto;
        }

        public async Task<(string Result, string ResultCode, string ResultMessage, string OrderId, string ConversationId, string Token)> GetFormData()
        {
            string Result = _httpContextAccessor.HttpContext.Request.Form["Result"];
            string ResultCode = _httpContextAccessor.HttpContext.Request.Form["ResultCode"];
            string ResultMessage = _httpContextAccessor.HttpContext.Request.Form["ResultMessage"];
            string OrderId = _httpContextAccessor.HttpContext.Request.Form["OrderId"];
            string ConversationId = _httpContextAccessor.HttpContext.Request.Form["ConversationId"];
            string Token = _httpContextAccessor.HttpContext.Request.Form["Token"];
            return (Result, ResultCode, ResultMessage, OrderId, ConversationId, Token);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Process a payment
        /// </summary>
        /// <param name="processPaymentRequest">Payment info required for an order processing</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the process payment result
        /// </returns>
        public Task<ProcessPaymentResult> ProcessPaymentAsync(ProcessPaymentRequest processPaymentRequest)
        {
            return Task.FromResult(new ProcessPaymentResult());
        }

        /// <summary>
        /// Post process payment (used by payment gateways that require redirecting to a third-party URL)
        /// </summary>
        /// <param name="postProcessPaymentRequest">Payment info required for an order processing</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task PostProcessPaymentAsync(PostProcessPaymentRequest postProcessPaymentRequest)
        {
            //create common query parameters for the request
            var queryParameters = await CreateParametersAsync(postProcessPaymentRequest);
            string postdata = JsonConvert.SerializeObject(queryParameters);
            var responsedata = (await _teqpayHttpClient.GetRedirectUrl(postdata));
            var ObjectData = JsonConvert.DeserializeObject<TeqpayResponseDto>(responsedata);
            if (ObjectData.ResultCode == 10000)
            {
                _httpContextAccessor.HttpContext.Response.Redirect(ObjectData.PaymentData.PaymentUrl);
            }
        }

        /// <summary>
        /// Returns a value indicating whether payment method should be hidden during checkout
        /// </summary>
        /// <param name="cart">Shopping cart</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the rue - hide; false - display.
        /// </returns>
        public Task<bool> HidePaymentMethodAsync(IList<ShoppingCartItem> cart)
        {
            //you can put any logic here
            //for example, hide this payment method if all products in the cart are downloadable
            //or hide this payment method if current customer is from certain country
            return Task.FromResult(false);
        }

        /// <summary>
        /// Gets additional handling fee
        /// </summary>
        /// <param name="cart">Shopping cart</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the additional handling fee
        /// </returns>
        public Task<decimal> GetAdditionalHandlingFeeAsync(IList<ShoppingCartItem> cart)
        {
            return Task.FromResult((decimal)0);
        }

        /// <summary>
        /// Captures payment
        /// </summary>
        /// <param name="capturePaymentRequest">Capture payment request</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the capture payment result
        /// </returns>
        public Task<CapturePaymentResult> CaptureAsync(CapturePaymentRequest capturePaymentRequest)
        {
            return Task.FromResult(new CapturePaymentResult { Errors = new[] { "Capture method not supported" } });
        }

        /// <summary>
        /// Refunds a payment
        /// </summary>
        /// <param name="refundPaymentRequest">Request</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the result
        /// </returns>
        public Task<RefundPaymentResult> RefundAsync(RefundPaymentRequest refundPaymentRequest)
        {
            return Task.FromResult(new RefundPaymentResult { Errors = new[] { "Refund method not supported" } });
        }

        /// <summary>
        /// Voids a payment
        /// </summary>
        /// <param name="voidPaymentRequest">Request</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the result
        /// </returns>
        public Task<VoidPaymentResult> VoidAsync(VoidPaymentRequest voidPaymentRequest)
        {
            return Task.FromResult(new VoidPaymentResult { Errors = new[] { "Void method not supported" } });
        }

        /// <summary>
        /// Process recurring payment
        /// </summary>
        /// <param name="processPaymentRequest">Payment info required for an order processing</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the process payment result
        /// </returns>
        public Task<ProcessPaymentResult> ProcessRecurringPaymentAsync(ProcessPaymentRequest processPaymentRequest)
        {
            return Task.FromResult(new ProcessPaymentResult { Errors = new[] { "Recurring payment not supported" } });
        }

        /// <summary>
        /// Cancels a recurring payment
        /// </summary>
        /// <param name="cancelPaymentRequest">Request</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the result
        /// </returns>
        public Task<CancelRecurringPaymentResult> CancelRecurringPaymentAsync(CancelRecurringPaymentRequest cancelPaymentRequest)
        {
            return Task.FromResult(new CancelRecurringPaymentResult { Errors = new[] { "Recurring payment not supported" } });
        }

        /// <summary>
        /// Gets a value indicating whether customers can complete a payment after order is placed but not completed (for redirection payment methods)
        /// </summary>
        /// <param name="order">Order</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the result
        /// </returns>
        public Task<bool> CanRePostProcessPaymentAsync(Order order)
        {
            if (order == null)
                throw new ArgumentNullException(nameof(order));

            //let's ensure that at least 5 seconds passed after order is placed
            //P.S. there's no any particular reason for that. we just do it
            if ((DateTime.UtcNow - order.CreatedOnUtc).TotalSeconds < 5)
                return Task.FromResult(false);

            return Task.FromResult(true);
        }

        /// <summary>
        /// Validate payment form
        /// </summary>
        /// <param name="form">The parsed form values</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the list of validating errors
        /// </returns>
        public Task<IList<string>> ValidatePaymentFormAsync(IFormCollection form)
        {
            return Task.FromResult<IList<string>>(new List<string>());
        }

        /// <summary>
        /// Get payment information
        /// </summary>
        /// <param name="form">The parsed form values</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the payment info holder
        /// </returns>
        public Task<ProcessPaymentRequest> GetPaymentInfoAsync(IFormCollection form)
        {
            return Task.FromResult(new ProcessPaymentRequest());
        }

        /// <summary>
        /// Gets a configuration page URL
        /// </summary>
        public override string GetConfigurationPageUrl()
        {
            return $"{_webHelper.GetStoreLocation()}Admin/PaymentTeqpay/Configure";
        }

        /// <summary>
        /// Gets a name of a view component for displaying plugin in public store ("payment info" checkout step)
        /// </summary>
        /// <returns>View component name</returns>
        public string GetPublicViewComponentName()
        {
            return "PaymentTeqpay";
        }

        /// <summary>
        /// Install the plugin
        /// </summary>
        /// <returns>A task that represents the asynchronous operation</returns>
        public override async Task InstallAsync()
        {
            //settings
            await _settingService.SaveSettingAsync(new TeqpayPaymentSettings
            {
                UseSandbox = true
            });

            //locales
            await _localizationService.AddLocaleResourceAsync(new Dictionary<string, string>
            {
                ["Plugins.Payments.Teqpay.Instructions"] = @"
                    <p>
	                    <b>You can edit Tekpay api.</b>
	                    <br />
	                    If you have received live information, do not forget to deselect the test checkbox.
                    </p>",
                ["Plugins.Payments.Teqpay.Fields.UseSandbox"] = "Use Test",
                ["Plugins.Payments.Teqpay.Fields.TestApiKey"] = "Test Api Key",
                ["Plugins.Payments.Teqpay.Fields.TestApiSecretKey"] = "Test Api SecretKey",
                ["Plugins.Payments.Teqpay.Fields.TestApiUrl"] = "Test Api Url",
                ["Plugins.Payments.Teqpay.Fields.LiveApiKey"] = "Live Api Key",
                ["Plugins.Payments.Teqpay.Fields.LiveApiSecretKey"] = "Live Api SecretKey",
                ["Plugins.Payments.Teqpay.Fields.LiveApiUrl"] = "Live Api Url",
                ["Plugins.Payments.Teqpay.Fields.RedirectionTip"] = "You will be redirected to Teqpay site to complete the order.",



            });

            await base.InstallAsync();
        }

        /// <summary>
        /// Uninstall the plugin
        /// </summary>
        /// <returns>A task that represents the asynchronous operation</returns>
        public override async Task UninstallAsync()
        {
            //settings
            await _settingService.DeleteSettingAsync<TeqpayPaymentSettings>();

            //locales
            await _localizationService.DeleteLocaleResourcesAsync("Plugins.Payments.Teqpay");

            await base.UninstallAsync();
        }

        /// <summary>
        /// Gets a payment method description that will be displayed on checkout pages in the public store
        /// </summary>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task<string> GetPaymentMethodDescriptionAsync()
        {
            return await _localizationService.GetResourceAsync("Plugins.Payments.Teqpay.PaymentMethodDescription");
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets a value indicating whether capture is supported
        /// </summary>
        public bool SupportCapture => false;

        /// <summary>
        /// Gets a value indicating whether partial refund is supported
        /// </summary>
        public bool SupportPartiallyRefund => false;

        /// <summary>
        /// Gets a value indicating whether refund is supported
        /// </summary>
        public bool SupportRefund => false;

        /// <summary>
        /// Gets a value indicating whether void is supported
        /// </summary>
        public bool SupportVoid => false;

        /// <summary>
        /// Gets a recurring payment type of payment method
        /// </summary>
        public RecurringPaymentType RecurringPaymentType => RecurringPaymentType.NotSupported;

        /// <summary>
        /// Gets a payment method type
        /// </summary>
        public PaymentMethodType PaymentMethodType => PaymentMethodType.Redirection;

        /// <summary>
        /// Gets a value indicating whether we should display a payment information page for this plugin
        /// </summary>
        public bool SkipPaymentInfo => false;

        #endregion
    }
}