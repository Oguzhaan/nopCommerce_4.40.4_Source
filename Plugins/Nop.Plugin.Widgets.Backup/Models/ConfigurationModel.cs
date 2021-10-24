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

        public bool IsSqlBackupDirectoryPermission { get; set; }
        public bool IsBackupPermission { get; set; }
        public bool IsBulkStatementPermission { get; set; }
        public bool IsConnectedGoogleDrive { get; set; }

        [NopResourceDisplayName("Nop.Plugin.Widgets.Backup.Fields.Enabled")]
        public bool Enabled { get; set; }
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
        [NopResourceDisplayName("Nop.Plugin.Widgets.Backup.Fields.UploadToGoogleDrive")]
        public bool UploadToGoogleDrive { get; set; }
        [NopResourceDisplayName("Nop.Plugin.Widgets.Backup.Fields.GoogleDriveClientId")]
        public string GoogleDriveClientId { get; set; }
        [NopResourceDisplayName("Nop.Plugin.Widgets.Backup.Fields.GoogleDriveClientSecret")]
        public string GoogleDriveClientSecret { get; set; }
        [NopResourceDisplayName("Nop.Plugin.Widgets.Backup.Fields.GoogleDriveAPIKey")]
        public string GoogleDriveAPIKey { get; set; }
        [NopResourceDisplayName("Nop.Plugin.Widgets.Backup.Fields.RedirectURL")]
        public string RedirectURL { get; set; }

        public int ActiveStoreScopeConfiguration { get; set; }

      

        #endregion
    }
}