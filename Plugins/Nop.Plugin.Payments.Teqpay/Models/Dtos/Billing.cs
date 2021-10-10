using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Payments.Teqpay.Models.Dtos
{
    public class Billing
    {
        public string billingName { get; set; }
        public string billingCity { get; set; }
        public string billingCountry { get; set; }
        public string billingAddress { get; set; }
    }
}
