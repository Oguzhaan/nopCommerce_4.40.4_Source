using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Payments.Teqpay.Models.Dtos
{
    public class Shipping
    {
        public string shippingContactName { get; set; }
        public string shippingCity { get; set; }
        public string shippingCountry { get; set; }
        public string shippingAddress { get; set; }
    }
}
