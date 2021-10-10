using Nop.Web.Framework.Mvc.ModelBinding;
using Nop.Web.Framework.Models;

namespace Nop.Plugin.Payments.Teqpay.Models
{
    public record ConfigurationModel : BaseNopModel
    {
        public int ActiveStoreScopeConfiguration { get; set; }

        [NopResourceDisplayName("Plugins.Payments.Teqpay.Fields.UseSandbox")]
        public bool UseSandbox { get; set; }
        public bool UseSandbox_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Payments.Teqpay.Fields.TestApiKey")]
        public string TestApiKey { get; set; }
        public bool TestApiKey_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Payments.Teqpay.Fields.TestApiSecretKey")]
        public string TestApiSecretKey { get; set; }
        public bool TestApiSecretKey_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Payments.Teqpay.Fields.TestApiUrl")]
        public string TestApiUrl { get; set; }
        public bool TestApiUrl_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Payments.Teqpay.Fields.LiveApiKey")]
        public string LiveApiKey { get; set; }
        public bool LiveApiKey_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Payments.Teqpay.Fields.LiveApiSecretKey")]
        public string LiveApiSecretKey { get; set; }
        public bool LiveApiSecretKey_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Payments.Teqpay.Fields.LiveApiUrl")]
        public string LiveApiUrl { get; set; }
        public bool LiveApiUrl_OverrideForStore { get; set; }
    }
}