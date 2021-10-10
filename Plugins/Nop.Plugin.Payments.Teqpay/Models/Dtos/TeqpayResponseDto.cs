using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Payments.Teqpay.Models.Dtos
{
   public class TeqpayResponseDto
    {
        public bool Result { get; set; }
        public int ResultCode { get; set; }
        public string ResultMessage { get; set; }
        public PaymentData PaymentData { get; set; }
    }
}
