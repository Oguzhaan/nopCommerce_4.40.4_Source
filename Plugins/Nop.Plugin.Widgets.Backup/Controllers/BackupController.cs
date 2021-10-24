using System;
using System.Threading.Tasks;
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
            var model = new ConfigurationModel
            {
            IsSqlBackupDirectoryPermission = widgetSettings.IsSqlBackupDirectoryPermission,
            IsBackupPermission = widgetSettings.IsBackupPermission,
            IsBulkStatementPermission = widgetSettings.IsBulkStatementPermission,
            IsConnectedGoogleDrive = widgetSettings.IsConnectedGoogleDrive,
            Enabled = widgetSettings.Enabled,
            DatabaseName = widgetSettings.DatabaseName,
            BackupTime = widgetSettings.BackupTime,
            DayOfWeek = widgetSettings.DayOfWeek,
            DayOfMonth = widgetSettings.DayOfMonth,
            UploadToGoogleDrive = widgetSettings.UploadToGoogleDrive,
            GoogleDriveClientId = widgetSettings.GoogleDriveClientId,
            GoogleDriveClientSecret = widgetSettings.GoogleDriveClientSecret,
            GoogleDriveAPIKey = widgetSettings.GoogleDriveAPIKey,
            RedirectURL = widgetSettings.RedirectURL,
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

            var storeId = await _storeContext.GetActiveStoreScopeConfigurationAsync();
            var settings = await _settingService.LoadSettingAsync<BackupSettings>(storeId);
            var widgetSettings = await _settingService.LoadSettingAsync<WidgetSettings>(storeId);


            if (model.Enabled && !widgetSettings.ActiveWidgetSystemNames.Contains(BackupDefaults.SystemName))
                widgetSettings.ActiveWidgetSystemNames.Add(BackupDefaults.SystemName);
            if (!model.Enabled && widgetSettings.ActiveWidgetSystemNames.Contains(BackupDefaults.SystemName))
                widgetSettings.ActiveWidgetSystemNames.Remove(BackupDefaults.SystemName);

            await _settingService.ClearCacheAsync();

            _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Plugins.Saved"));

            return await Configure();
        }

        [HttpPost]
        public JsonResult RunBackup()
        {
            try
            {
                BackupSettings settings;
              /* string connectionString = new DataSettingsManager().LoadSettings((string)null,false,null).ConnectionString;
                GoogleDriveToken googleDriveToken = new GoogleDriveToken();
                if (!string.IsNullOrEmpty(settings.GoogleAccessToken) && !string.IsNullOrEmpty(settings.GoogleDriveRefreshToken))
                {
                    googleDriveToken = this.CheckTokenExpiryTime(settings);
                }
                else
                {
                    googleDriveToken.access_token = Convert.ToString(settings.GoogleAccessToken);
                    googleDriveToken.expires_in = Convert.ToString(settings.GoogleDriveAccessTokenTime);
                    googleDriveToken.refresh_token = settings.GoogleDriveRefreshToken;
                }*/
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