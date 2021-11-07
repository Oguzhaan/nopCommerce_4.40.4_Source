using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nop.Core;
using Nop.Core.Domain.Cms;
using Nop.Data;
using Nop.Plugin.Widgets.Backup.Models;
using Nop.Services.Configuration;
using Nop.Services.Helpers;
using Nop.Services.Localization;
using Nop.Services.Messages;
using Nop.Services.Plugins;
using Nop.Services.Security;
using Nop.Services.Stores;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Plugin.Widgets.Backup.Controllers
{
    [Area(AreaNames.Admin)]
    [AuthorizeAdmin]
    [AutoValidateAntiforgeryToken]
    public class BackupController : BasePluginController
    {
        #region Fields

        private readonly ILocalizationService _localizationService;
        private readonly INotificationService _notificationService;
        private readonly IPermissionService _permissionService;
        private readonly ISettingService _settingService;
        private readonly IStoreContext _storeContext;
        private readonly IStoreService _storeService;
        private readonly IWebHelper _webHelper;
        private readonly IDateTimeHelper _datetimeHelper;
        private readonly IPluginService _pluginService;
        private readonly INopDataProvider _nopDataProvider;
        private readonly IHostingEnvironment _hostingEnvironment;


        #endregion

        #region Ctor

        public BackupController(ILocalizationService localizationService,
            INotificationService notificationService,
            IPermissionService permissionService,
            ISettingService settingService,
            IStoreContext storeContext,
            IStoreService storeService,
              IDateTimeHelper dateTimeHelper,
                IPluginService pluginService,
                INopDataProvider nopDataProvider,
                IHostingEnvironment hostingEnvironment,
            IWebHelper webHelper)
        {
            _localizationService = localizationService;
            _notificationService = notificationService;
            _permissionService = permissionService;
            _settingService = settingService;
            _storeContext = storeContext;
            _pluginService = pluginService;
            _storeService = storeService;
            _datetimeHelper = dateTimeHelper;
            _nopDataProvider = nopDataProvider;
            _hostingEnvironment = hostingEnvironment;
            _webHelper = webHelper;
        }

        #endregion

        #region Methods

        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task<IActionResult> Configure()
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageWidgets))
                return AccessDeniedView();

            var storeId = await _storeContext.GetActiveStoreScopeConfigurationAsync();
            var widgetSettings = await _settingService.LoadSettingAsync<BackupSettings>(storeId);
            var dbName = DataSettingsManager.LoadSettings().ConnectionString.Split(";")[1].Split("=")[1];
            var model = new ConfigurationModel
            {
                DatabaseName = dbName,
                BackupTime = widgetSettings.BackupTime,
                DayOfWeek = widgetSettings.DayOfWeek,
                DayOfMonth = widgetSettings.DayOfMonth,
                ActiveStoreScopeConfiguration = storeId
            };


            return View("~/Plugins/Widgets.Backup/Views/Configure.cshtml", model);
        }

        public async Task<IActionResult> LocalBackupList()
        {
            return View("~/Plugins/Widgets.Backup/Views/Configure.cshtml");
        }
        public async Task<IActionResult> GoogleDriveBackupList()
        {
            return View("~/Plugins/Widgets.Backup/Views/Configure.cshtml");
        }
        [HttpPost]
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task<IActionResult> Configure(ConfigurationModel model)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageWidgets))
                return AccessDeniedView();

            if (!ModelState.IsValid)
                return await Configure();

            var storeScope = await _storeContext.GetActiveStoreScopeConfigurationAsync();
            var settings = await _settingService.LoadSettingAsync<BackupSettings>(storeScope);
            var widgetSettings = await _settingService.LoadSettingAsync<WidgetSettings>(storeScope);

            //save settings
            settings.BackupTime = model.BackupTime;
            settings.BackupType = model.BackupType;
            settings.DatabaseName = DataSettingsManager.LoadSettings().ConnectionString.Split(";")[1].Split("=")[1];
            settings.DayOfMonth = model.DayOfMonth;
            settings.DayOfWeek = model.DayOfWeek;

            /* We do not clear cache after each setting update.
             * This behavior can increase performance because cached settings will not be cleared 
             * and loaded from database after each update */
            await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.BackupTime, model.BackupTime_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.BackupType, model.BackupType_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.DatabaseName, model.DatabaseName_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.DayOfMonth, model.DayOfMonth_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.DayOfWeek, model.DayOfWeek_OverrideForStore, storeScope, false);

            await _settingService.ClearCacheAsync();

            _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Plugins.Saved"));

            return View("~/Plugins/Widgets.Backup/Views/Configure.cshtml", model);
        }

        [HttpPost]
        [IgnoreAntiforgeryToken]
        public async Task<JsonResult> RunBackup()
        {
            
            var dbName = DataSettingsManager.LoadSettings().ConnectionString.Split(";")[1].Split("=")[1];
            string connectionstr = "Data Source=OGUZHAN\\SQLEXPRESS2014;Initial Catalog=NopTest;Integrated Security=False;Persist Security Info=False;User ID=sa;Password=adm123";
            SqlConnection sqlconn = new SqlConnection(connectionstr);
            SqlCommand sqlcmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            // Backup destibation
            string backupDestination = _hostingEnvironment.WebRootPath.Replace("\\wwwroot", "") + "\\Plugins\\Widgets.Backup\\Backup\\";
            // check if backup folder exist, otherwise create it.
            if (!System.IO.Directory.Exists(backupDestination))
            {
                System.IO.Directory.CreateDirectory(backupDestination);
            }
            try
            {
                sqlconn.Open();
                backupDestination += DateTime.Now.ToString("yyyyMMddHHmmss") + ".bak";
                sqlcmd = new SqlCommand("backup database "+ dbName + " to disk='" + backupDestination + "\'" , sqlconn);
                sqlcmd.ExecuteNonQuery();
                //Close connection
                sqlconn.Close();
                return ((Controller)this).Json("");
            }
            catch (Exception ex)
            {
                return ((Controller)this).Json((object)ex.Message);
            }
        }

        #endregion
    }
}