using Nop.Core.Configuration;
using Nop.Plugin.Widgets.Faqs.Models;
using System.Collections.Generic;

namespace Nop.Plugin.Widgets.Faqs
{
    /// <summary>
    /// Represents plugin settings
    /// </summary>
    public class FaqsSettings : ISettings
    {
        /// <summary>
        /// Gets or sets a widget zone name to place a widget
        /// </summary>
        public string WidgetZone { get; set; }
    }
}