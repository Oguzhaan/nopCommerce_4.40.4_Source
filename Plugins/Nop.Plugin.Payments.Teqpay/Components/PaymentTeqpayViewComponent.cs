using Microsoft.AspNetCore.Mvc;
using Nop.Web.Framework.Components;

namespace Nop.Plugin.Payments.Teqpay.Components
{
    [ViewComponent(Name = "PaymentTeqpay")]
    public class PaymentTeqpayViewComponent : NopViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Plugins/Payments.Teqpay/Views/PaymentInfo.cshtml");
        }
    }
}
