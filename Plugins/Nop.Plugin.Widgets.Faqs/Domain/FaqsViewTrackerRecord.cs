using Nop.Core;

namespace Nop.Plugin.Widgets.Faqs.Models.Domain
{
    public class FaqsViewTrackerRecord : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Order { get; set; }
    }
}
