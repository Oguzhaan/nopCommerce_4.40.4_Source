using Nop.Core.Configuration;
using Nop.Plugin.Widgets.Backup.Models;

namespace Nop.Plugin.Widgets.Backup
{
    /// <summary>
    /// Represents plugin settings
    /// </summary>
    public class BackupSettings : ISettings
    {
        /// <summary>
        /// Gets or sets a widget zone name to place a widget
        /// </summary>
        public string WidgetZone { get; set; }

        public bool IsSqlBackupDirectoryPermission { get; set; }
        public bool IsBackupPermission { get; set; }
        public bool IsBulkStatementPermission { get; set; }
        public bool IsConnectedGoogleDrive { get; set; }

        public bool Enabled { get; set; }
        public string DatabaseName { get; set; }
        public string BackupTime { get; set; }
        public string DayOfWeek { get; set; }
        public string DayOfMonth { get; set; }

        public bool UploadToGoogleDrive { get; set; }
        public string GoogleDriveClientId { get; set; }
        public string GoogleDriveClientSecret { get; set; }
        public string GoogleDriveAPIKey { get; set; }
        public string RedirectURL { get; set; }

    }
}