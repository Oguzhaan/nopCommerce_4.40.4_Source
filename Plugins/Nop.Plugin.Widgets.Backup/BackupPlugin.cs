using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Routing;
using Nop.Core.Domain.Cms;
using Nop.Services.Cms;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Plugins;
using Nop.Services.Stores;
using Nop.Web.Framework.Infrastructure;
using Nop.Web.Framework.Menu;

namespace Nop.Plugin.Widgets.Backup
{
    /// <summary>
    /// Represents the plugin implementation
    /// </summary>
    public class BackupPlugin : BasePlugin, IWidgetPlugin, IAdminMenuPlugin
    {
        #region Fields

        private readonly BackupSettings _backupSettings;
        private readonly IActionContextAccessor _actionContextAccessor;
        private readonly ILocalizationService _localizationService;
        private readonly ISettingService _settingService;
        private readonly IStoreService _storeService;
        private readonly IUrlHelperFactory _urlHelperFactory;


        #endregion

        #region Ctor

        public BackupPlugin(BackupSettings backupSettings,
            IActionContextAccessor actionContextAccessor,
            ILocalizationService localizationService,
            ISettingService settingService,
            IStoreService storeService,
            IUrlHelperFactory urlHelperFactory)
        {
            _backupSettings = backupSettings;
            _actionContextAccessor = actionContextAccessor;
            _localizationService = localizationService;
            _settingService = settingService;
            _storeService = storeService;
            _urlHelperFactory = urlHelperFactory;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets a configuration page URL
        /// </summary>
        public override string GetConfigurationPageUrl()
        {
            return _urlHelperFactory.GetUrlHelper(_actionContextAccessor.ActionContext).RouteUrl(BackupDefaults.ConfigurationRouteName);
        }

        /// <summary>
        /// Gets widget zones where this widget should be rendered
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the widget zones
        /// </returns>
        public Task<IList<string>> GetWidgetZonesAsync()
        {
            return Task.FromResult<IList<string>>(new List<string> { _backupSettings.WidgetZone });
        }

        /// <summary>
        /// Gets a name of a view component for displaying widget
        /// </summary>
        /// <param name="widgetZone">Name of the widget zone</param>
        /// <returns>View component name</returns>
        public string GetWidgetViewComponentName(string widgetZone)
        {
            if (widgetZone == null)
                throw new ArgumentNullException(nameof(widgetZone));

            return BackupDefaults.VIEW_COMPONENT;
        }

        /// <summary>
        /// Install plugin
        /// </summary>
        /// <returns>A task that represents the asynchronous operation</returns>
        public override async Task InstallAsync()
        {
            await _settingService.SaveSettingAsync(new BackupSettings
            {
                WidgetZone = PublicWidgetZones.HeadHtmlTag
            });

            await _localizationService.AddLocaleResourceAsync(new Dictionary<string, string>
            {
                ["Nop.Plugin.Widgets.Backup.Tabs.General"] = "General",
                ["Nop.Plugin.Widgets.Backup.Tabs.StorageSetting"] = "Storage Settings",
                ["Nop.Plugin.Widgets.Backup.Tabs.BackupRepository"] = "Backup Repository",
                ["Nop.Plugin.Widgets.Backup.Tabs.RunBackupNow"] = "Run Backup Now",
                ["Nop.Plugin.Widgets.Backup.Tabs.StopTask"] = "Stop Task",
                ["Nop.Plugin.Widgets.Backup.Fields.DatabaseName"] = "Database Name:",
                ["Nop.Plugin.Widgets.Backup.Fields.BackupType"] = "Backup Type:",
                ["Nop.Plugin.Widgets.Backup.Fields.BackupTime"] = "Backup Time:",
                ["Nop.Plugin.Widgets.Backup.Fields.DayOfWeek"] = "Day of Week:",
                ["Nop.Plugin.Widgets.Backup.Fields.DayOfMonth"] = "Day of Month:",
                ["Nop.Plugin.Widgets.Backup.Fields.UploadToGoogleDrive"] = "Upload backup Auto to GD:",
                ["Nop.Plugin.Widgets.Backup.Fields.GoogleDriveClientId"] = "Google Drive Client Id:",
                ["Nop.Plugin.Widgets.Backup.Fields.GoogleDriveClientSecret"] = "Google Drive Client Secret:",
                ["Nop.Plugin.Widgets.Backup.Fields.DeleteFromLocalRepository"] = "Delete local backup file after uploading backup to external storage:",
                ["Nop.Plugin.Widgets.Backup.Fields.GoogleDriveAPIKey"] = "API Key:",
                ["Nop.Plugin.Widgets.Backup.Fields.GoogleRedirectURL"] = "Google Drive redirect URL:",
                ["Nop.Plugin.Widgets.Backup.Fields.RedirectURL"] = "Redirect URL:",
                ["Nop.Plugin.Widgets.Backup.Fields.RerunAssesment"] = "Re-run assesment",
                ["Nop.Plugin.Widgets.Backup.Step1"] = "Backup device permission",
                ["Nop.Plugin.Widgets.Backup.Step2"] = "Database backup permission",
                ["Nop.Plugin.Widgets.Backup.Step3"] = "Bulk admin permission",
                ["Nop.Plugin.Widgets.Backup.backupsettings"] = "Backup Configuration",
              
                ["Nop.Plugin.Widgets.Backup.storagesetting"] = "Google Configuration",
                ["Nop.Plugin.Widgets.Backup.LocalBackupRepository"] = "Local Backup Repository",
                ["Nop.Plugin.Widgets.Backup.Delete.LocalBackupRepository"] = "Backup Delete",
                ["Nop.Plugin.Widgets.Backup.Delete.gooogledrivebackuprepository"] = "Google Backup Delete",
                ["Nop.Plugin.Widgets.Backup.ConfigureSuccessMessage"] = "Settings have been saved successfully",
                ["Nop.Plugin.Widgets.Backup.RunBackupSuccessMessage"] = "Backup completed successfully.",
                ["Nop.Plugin.Widgets.Backup.RunBackupFailedMessage"] = "Unknown error occured while taking backup. Please try again. If problem persists, contact plugin support team.",
                ["Nop.Plugin.Widgets.Backup.DeleteLocalBackupSuccessMessage"] = "Local backup deleted successfully",
                ["Nop.Plugin.Widgets.Backup.DeleteGoogleBackupSuccessMessage"] = "Backup deleted from drive successfully",
                ["Nop.Plugin.Widgets.Backup.DriveLogoConnectedMessage"] = "Connected",
                ["Nop.Plugin.Widgets.Backup.DriveLogoNotConnectedMessage"] = "Not Connected",
                ["Nop.Plugin.Widgets.Backup.Step1InfoMessage"] = "Backup access path not permitted",
                ["Nop.Plugin.Widgets.Backup.Step2InfoMessage"] = "Backup permission not granted",
                ["Nop.Plugin.Widgets.Backup.Step3InfoMessage"] = "Bulkadmin permission not granted.",
                ["Nop.Plugin.Widgets.Backup.ReassesmentSuccessMessage"] = "Assesment has been done successfully.We did not found any permission issue while running tests.",
                ["Nop.Plugin.Widgets.Backup.Fields.Monday"] = "Monday",
                ["Nop.Plugin.Widgets.Backup.Fields.Tuesday"] = "Tuesday",
                ["Nop.Plugin.Widgets.Backup.Fields.Wednesday"] = "Wednesday",
                ["Nop.Plugin.Widgets.Backup.Fields.Thursday"] = "Thursday",
                ["Nop.Plugin.Widgets.Backup.Fields.Friday"] = "Friday",
                ["Nop.Plugin.Widgets.Backup.Fields.Saturday"] = "Saturday",
                ["Nop.Plugin.Widgets.Backup.Fields.Sunday"] = "Sunday",
                ["Nop.Plugin.Widgets.Backup.Fields.BackupName"] = "Backup Name",
                ["Nop.Plugin.Widgets.Backup.Fields.FileSize"] = "File Size",
                ["Nop.Plugin.Widgets.Backup.Fields.Enabled"] = "Enabled",
                ["Nop.Plugin.Widgets.Backup.Tabs.Save"] = "Save",
            });

            await base.InstallAsync();
        }

        /// <summary>
        /// Uninstall plugin
        /// </summary>
        /// <returns>A task that represents the asynchronous operation</returns>
        public override async Task UninstallAsync()
        {
            await _settingService.DeleteSettingAsync<BackupSettings>();

            var stores = await _storeService.GetAllStoresAsync();
            var storeIds = new List<int> { 0 }.Union(stores.Select(store => store.Id));
            foreach (var storeId in storeIds)
            {
                var widgetSettings = await _settingService.LoadSettingAsync<WidgetSettings>(storeId);
                widgetSettings.ActiveWidgetSystemNames.Remove(BackupDefaults.SystemName);
                await _settingService.SaveSettingAsync(widgetSettings);
            }

            await _localizationService.DeleteLocaleResourcesAsync("Plugins.Widgets.Backup");

            await base.UninstallAsync();
        }

        public Task ManageSiteMapAsync(SiteMapNode rootNode)
        {

            var parentNode = new SiteMapNode()
            {
                SystemName = this.PluginDescriptor.SystemName,
                Title = "Backup",
                IconClass = "fas fa-cube",
                Visible = true,
                RouteValues = new RouteValueDictionary() { { "area", null } },
            };
            parentNode.ChildNodes.Add(new SiteMapNode()
            {
                Title = "Configure",
                ControllerName = "Backup", // Your controller Name
                ActionName = "Configure", // Action Name
                Visible = true,
                SystemName = this.PluginDescriptor.SystemName,
                RouteValues = new RouteValueDictionary() { },
            });
            parentNode.ChildNodes.Add(new SiteMapNode()
            {
                SystemName = BackupDefaults.SystemName,
                Title = "Backup List",
                ControllerName = "Backup",
                ActionName = "List",
                Visible = true,
                RouteValues = new RouteValueDictionary() { }
            });
            rootNode.ChildNodes.Add(parentNode);

            return Task.CompletedTask;
        }


        #endregion

        #region Properties

        /// <summary>
        /// Gets a value indicating whether to hide this plugin on the widget list page in the admin area
        /// </summary>
        public bool HideInWidgetList => false;

        #endregion
    }
}