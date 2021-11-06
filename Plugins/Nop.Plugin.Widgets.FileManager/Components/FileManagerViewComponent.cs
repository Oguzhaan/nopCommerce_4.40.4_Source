using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Nop.Web.Framework.Components;

namespace Nop.Plugin.Widgets.FileManager.Components
{
    /// <summary>
    /// Represents the view component to place a widget into pages
    /// </summary>
    [ViewComponent(Name = FileManagerDefaults.VIEW_COMPONENT)]
    public class FileManagerViewComponent : NopViewComponent
    {
        #region Fields

        private readonly FileManagerSettings _filemanagerSettings;

        #endregion

        #region Ctor

        public FileManagerViewComponent(FileManagerSettings filemanagerSettings)
        {
            _filemanagerSettings = filemanagerSettings;
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
            if (widgetZone != _filemanagerSettings.WidgetZone) return new HtmlContentViewComponentResult(new HtmlString(string.Empty));
            else return View("~/Plugins/Widgets.FileManager/Views/Link.cshtml");
        }

        #endregion
    }
}