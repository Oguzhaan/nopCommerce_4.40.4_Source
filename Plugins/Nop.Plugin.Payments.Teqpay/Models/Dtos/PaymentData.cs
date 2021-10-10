using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Payments.Teqpay.Models.Dtos
{
    public class PaymentData
    {
        public string ConversationId { get; set; }
        public double Price { get; set; }
        public string PaymentUrl { get; set; }
        public string TransactionDate { get; set; }
    }
}
