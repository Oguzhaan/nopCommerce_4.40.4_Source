using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Nop.Plugin.Widgets.Faqs.Services;
using Nop.Web.Framework.Components;

namespace Nop.Plugin.Widgets.Faqs.Components
{
    /// <summary>
    /// Represents the view component to place a widget into pages
    /// </summary>
    [ViewComponent(Name = FaqsDefaults.VIEW_COMPONENT)]
    public class FaqsViewComponent : NopViewComponent
    {
        #region Fields

        private readonly FaqsSettings _faqsSettings;
        private readonly IFaqsViewTrackerService _faqsViewTrackerService;

        #endregion

        #region Ctor

        public FaqsViewComponent(FaqsSettings faqsSettings, IFaqsViewTrackerService faqsViewTrackerService)
        {
            _faqsViewTrackerService = faqsViewTrackerService;
            _faqsSettings = faqsSettings;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Invoke view component
        /// </summary>
        /// <param name="widgetZone">Widget zone name</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the view component result
        /// </returns>
        public IViewComponentResult Invoke(string widgetZone)
        {
            if (widgetZone != _faqsSettings.WidgetZone) return new HtmlContentViewComponentResult(new HtmlString(string.Empty));
            else return View("~/Plugins/Widgets.Faqs/Views/FaqsLink.cshtml");
        }

        #endregion
    }
}