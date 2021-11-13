using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Plugin.Widgets.Backup.Models
{
    /// <summary>
    /// Represents configuration model
    /// </summary>
    public record ConfigurationModel : BaseNopModel
    {
        #region Properties
        [NopResourceDisplayName("Nop.Plugin.Widgets.Backup.Fields.Enabled")]
        public string Enabled { get; set; }
        [NopResourceDisplayName("Nop.Plugin.Widgets.Backup.Fields.DatabaseName")]
        public string DatabaseName { get; set; }

        [NopResourceDisplayName("Nop.Plugin.Widgets.Backup.Fields.BackupType")]
        public BackupType BackupType { get; set; }



        [NopResourceDisplayName("Nop.Plugin.Widgets.Backup.Fields.BackupTime")]
        public string BackupTime { get; set; }
        [NopResourceDisplayName("Nop.Plugin.Widgets.Backup.Fields.DayOfWeek")]
        public string DayOfWeek { get; set; }
        [NopResourceDisplayName("Nop.Plugin.Widgets.Backup.Fields.DayOfMonth")]
        public string DayOfMonth { get; set; }

        public bool Enabled_OverrideForStore { get; set; }
        public bool BackupTime_OverrideForStore { get; set; }
        public bool DatabaseName_OverrideForStore { get; set; }
        public bool DayOfMonth_OverrideForStore { get; set; }
        public bool DayOfWeek_OverrideForStore { get; set; }
        public bool BackupType_OverrideForStore { get; set; }
        public int ActiveStoreScopeConfiguration { get; set; }



        #endregion
    }
}