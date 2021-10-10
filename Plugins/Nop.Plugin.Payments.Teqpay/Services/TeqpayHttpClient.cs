using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Net.Http.Headers;
using Nop.Core;

namespace Nop.Plugin.Payments.Teqpay.Services
{
    /// <summary>
    /// Represents the HTTP client to request PayPal services
    /// </summary>
    public partial class TeqpayHttpClient
    {
        #region Fields

        private readonly HttpClient _httpClient;
        private readonly TeqpayPaymentSettings _teqpayPaymentSettings;

        #endregion

        #region Ctor

        public TeqpayHttpClient(HttpClient client,
            TeqpayPaymentSettings teqpayPaymentSettings)
        {
            //configure client
            client.Timeout = TimeSpan.FromSeconds(20);


            _httpClient = client;
            _teqpayPaymentSettings = teqpayPaymentSettings;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets PDT details
        /// </summary>
        /// <param name="tx">TX</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the asynchronous task whose result contains the PDT details
        /// </returns>
        public async Task<string> GetRedirectUrl(string tx)
        {
            //get response
            var url = _teqpayPaymentSettings.UseSandbox ? _teqpayPaymentSettings.TestApiUrl : _teqpayPaymentSettings.LiveApiUrl;
            var requestContent = new StringContent(tx, Encoding.UTF8, MimeTypes.ApplicationJson);


            if (!_teqpayPaymentSettings.UseSandbox)
            {
                _httpClient.DefaultRequestHeaders.Add("ApiKey", _teqpayPaymentSettings.LiveApiKey);
                _httpClient.DefaultRequestHeaders.Add("SecretKey", _teqpayPaymentSettings.LiveApiSecretKey);
            }
            else
            {
                _httpClient.DefaultRequestHeaders.Add("ApiKey", _teqpayPaymentSettings.TestApiKey);
                _httpClient.DefaultRequestHeaders.Add("SecretKey", _teqpayPaymentSettings.TestApiSecretKey);
            }

            var response = await _httpClient.PostAsync(url, requestContent);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        #endregion
    }
}