using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Payments.Teqpay.Models.Dtos
{
    public class TeqpayRequestDto
    {
        public string customerName { get; set; }
        public string customerIpAddress { get; set; }
        public string customerCitizenNo { get; set; }
        public string customerEmail { get; set; }
        public string customerPhone { get; set; }
        public int price { get; set; }
        public string currency { get; set; }
        public string conversationId { get; set; }
        public string callbackUrl { get; set; }
        public string language { get; set; }
        public string paymentMethodId { get; set; }
        public List<Product> products { get; set; }
        public Billing billing { get; set; }
        public Shipping shipping { get; set; }
        public List<string> installments { get; set; }
    }
}
