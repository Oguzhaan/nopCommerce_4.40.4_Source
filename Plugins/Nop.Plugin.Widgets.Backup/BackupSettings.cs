using Nop.Core.Configuration;
using Nop.Plugin.Widgets.Backup.Models;

namespace Nop.Plugin.Widgets.Backup
{
    /// <summary>
    /// Represents plugin settings
    /// </summary>
    public class BackupSettings : ISettings
    {

        public string DatabaseName { get; set; }
        public string BackupTime { get; set; }
        public BackupType BackupType { get; set; }
        public string DayOfWeek { get; set; }
        public string DayOfMonth { get; set; }
        public string WidgetZone { get; set; }


    }
}