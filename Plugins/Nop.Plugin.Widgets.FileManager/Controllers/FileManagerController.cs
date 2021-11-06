using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Domain.Cms;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Messages;
using Nop.Services.Security;
using Nop.Services.Stores;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Plugin.Widgets.FileManager.Controllers
{
    public class FileManagerController : BasePluginController
    {

        #region Methods

        public async Task<IActionResult> Index()
        {
            return View("~/Plugins/Widgets.FileManager/Views/Index.cshtml");
        }
        #endregion
    }
}