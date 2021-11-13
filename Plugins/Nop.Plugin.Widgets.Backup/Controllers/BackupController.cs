using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
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
        private readonly IWebHostEnvironment _webHostEnvironment;

        public static Thread _thread;
        public static ManualResetEvent _shutdownEvent = new ManualResetEvent(false);

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
                IWebHostEnvironment webHostEnvironment,
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
            _webHostEnvironment = webHostEnvironment;
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
                Enabled = widgetSettings.Enabled,
                DatabaseName = dbName,
                BackupTime = widgetSettings.BackupTime,
                DayOfWeek = widgetSettings.DayOfWeek,
                DayOfMonth = widgetSettings.DayOfMonth,
                ActiveStoreScopeConfiguration = storeId
            };


            return View("~/Plugins/Widgets.Backup/Views/Configure.cshtml", model);
        }
        public async Task<IActionResult> List()
        {
            string path = _hostingEnvironment.WebRootPath.Replace("\\wwwroot", "") + "\\Plugins\\Widgets.Backup\\Backup\\";
            DirectoryInfo di = new DirectoryInfo(path);
            FileInfo[] fiArr = di.GetFiles();
            List<FileInfoModel> fileList = new List<FileInfoModel>();
            foreach (FileInfo f in fiArr)
            {
                FileInfoModel fIM = new FileInfoModel();
                fIM.fileName = f.Name;
                fIM.Length = f.Length;
                fIM.fileUrl = path + "\\" + f.Name;
                fileList.Add(fIM);
            }
            return View("~/Plugins/Widgets.Backup/Views/List.cshtml", fileList);
        }

        public PhysicalFileResult DownloadFile(string fileName)
        {
            //Determine the Content Type of the File.
            string contentType = "application/sql";
            string pathMain = _hostingEnvironment.WebRootPath.Replace("\\wwwroot", "") + "\\Plugins\\Widgets.Backup\\";
            //Build the File Path.
            string path = Path.Combine(pathMain, "Backup/") + fileName;

            //Send the File to Download.
            return new PhysicalFileResult(path, contentType);
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
            settings.Enabled = model.Enabled;
            settings.BackupType = model.BackupType;
            settings.DatabaseName = DataSettingsManager.LoadSettings().ConnectionString.Split(";")[1].Split("=")[1];
            settings.DayOfMonth = model.DayOfMonth;
            settings.DayOfWeek = model.DayOfWeek;
            /* We do not clear cache after each setting update.
             * This behavior can increase performance because cached settings will not be cleared 
             * and loaded from database after each update */
            await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.BackupTime, model.BackupTime_OverrideForStore, storeScope, false);
            await _settingService.SaveSettingOverridablePerStoreAsync(settings, x => x.Enabled, model.Enabled_OverrideForStore, storeScope, false);
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
        public async Task<string> RunBackup()
        {
            var result = new SetBackup().Set(_hostingEnvironment);
            return result;
        }
        public async void ProcessTask()
        {
            try
            {
                var storeScope = await _storeContext.GetActiveStoreScopeConfigurationAsync();
                var settings = await _settingService.LoadSettingAsync<BackupSettings>(storeScope);
                while (!_shutdownEvent.WaitOne(0, true))
                {
                    if (settings.Enabled == "1")
                    {
                        TimeSpan time = await GetTime();
                        try
                        {
                            new SetBackup().Set(_hostingEnvironment);
                        }
                        catch (Exception)
                        {
                        }
                        Thread.Sleep(time);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> StartProcess()
        {
            _thread = new Thread(new ThreadStart(ProcessTask));
            _thread.Start();
            return Ok(true);
        }

        [HttpPost]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> AbortProcess()
        {
            _thread.Abort();
            return Ok(true);
        }


        public async Task<TimeSpan> GetTime()
        {
            var storeScope = await _storeContext.GetActiveStoreScopeConfigurationAsync();
            var settings = await _settingService.LoadSettingAsync<BackupSettings>(storeScope);
            DateTime? threadSleepTime = null;
            if (settings != null && !string.IsNullOrEmpty(settings.BackupTime))
            {
                if (settings.BackupType == BackupType.daily)
                {
                    if (!string.IsNullOrEmpty(settings.BackupTime) && settings.BackupTime.IndexOf(":") > -1)
                    {
                        var newDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.AddDays(1).Day, Convert.ToInt32(settings.BackupTime.Split(':')[0]), Convert.ToInt32(settings.BackupTime.Split(':')[1]), 0);
                        threadSleepTime = newDate;
                    }
                }
                else if (settings.BackupType == BackupType.weekly)
                {
                    DateTime today = DateTime.Now;
                    DayOfWeek dayOfWeek = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), settings.DayOfWeek, true);
                    int delta = (dayOfWeek - today.DayOfWeek) + 7;
                    var newDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.AddDays(delta).Day, Convert.ToInt32(settings.BackupTime.Split(':')[0]), Convert.ToInt32(settings.BackupTime.Split(':')[1]), 0);
                    threadSleepTime = newDate;
                }
                else if (settings.BackupType == BackupType.monthly)
                {
                    var newDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, Convert.ToInt32(settings.DayOfMonth), Convert.ToInt32(settings.BackupTime.Split(':')[0]), Convert.ToInt32(settings.BackupTime.Split(':')[1]), 0);
                    threadSleepTime = newDate;
                }
            }
            TimeSpan returntimespan = Convert.ToDateTime(threadSleepTime) - DateTime.Now;
            return returntimespan;
        }
        #endregion
    }
}