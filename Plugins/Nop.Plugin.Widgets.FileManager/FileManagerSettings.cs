using Nop.Core.Configuration;
using Nop.Web.Framework.Infrastructure;
using System.Collections.Generic;

namespace Nop.Plugin.Widgets.FileManager
{
    /// <summary>
    /// Represents plugin settings
    /// </summary>
    public class FileManagerSettings : ISettings
    {
        /// <summary>
        /// Gets or sets a widget zone name to place a widget
        /// </summary>
        public string WidgetZone { get; set; } 
    }
}