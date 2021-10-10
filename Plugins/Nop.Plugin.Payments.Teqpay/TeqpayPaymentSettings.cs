using Nop.Core.Configuration;

namespace Nop.Plugin.Payments.Teqpay
{
    /// <summary>
    /// Represents settings of the PayPal Standard payment plugin
    /// </summary>
    public class TeqpayPaymentSettings : ISettings
    {
        public bool UseSandbox { get; set; }

        public string TestApiUrl { get; set; }

        public string TestApiKey { get; set; }

        public string TestApiSecretKey { get; set; }

        public string LiveApiUrl { get; set; }

        public string LiveApiKey { get; set; }

        public string LiveApiSecretKey { get; set; }

    }
}
