using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Payments.Teqpay.Models.Dtos
{
    public class Product
    {
        public string merchantItemId { get; set; }
        public string itemType { get; set; }
        public string itemCategory { get; set; }
        public string itemName { get; set; }
        public int itemQuantity { get; set; }
        public int itemPrice { get; set; }
    }
}
