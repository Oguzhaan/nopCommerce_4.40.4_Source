using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Domain.Cms;
using Nop.Plugin.Widgets.Faqs;
using Nop.Plugin.Widgets.Faqs.Models;
using Nop.Plugin.Widgets.Faqs.Models.Domain;
using Nop.Plugin.Widgets.Faqs.Services;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Messages;
using Nop.Services.Security;
using Nop.Services.Stores;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Plugin.Widgets.Faqs.Controllers
{
    public class FaqsViewController : BasePluginController
    {
        #region Fields

        private readonly IFaqsViewTrackerService _faqsViewTrackerService;

        #endregion

        #region Ctor

        public FaqsViewController(IFaqsViewTrackerService faqsViewTrackerService)
        {
            _faqsViewTrackerService = faqsViewTrackerService;
        }

        #endregion

        #region Methods

        public async Task<IActionResult> index()
        {
            var list = _faqsViewTrackerService.GetAll().OrderBy(x => x.Order).ToList();
            return View("~/Plugins/Widgets.Faqs/Views/FaqsView.cshtml", list);
        }
        #endregion
    }
}