using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Nop.Web.Framework;
using Nop.Web.Framework.Mvc.Routing;

namespace Nop.Plugin.Widgets.Faqs.Infrastructure
{
    /// <summary>
    /// Represents the plugin route provider
    /// </summary>
    public class RouteProvider : IRouteProvider
    {
        /// <summary>
        /// Register routes
        /// </summary>
        /// <param name="endpointRouteBuilder">Route builder</param>
        public void RegisterRoutes(IEndpointRouteBuilder endpointRouteBuilder)
        {
            endpointRouteBuilder.MapControllerRoute(FaqsDefaults.ConfigurationRouteName, "Plugins/Faqs/Configure", new { controller = "Faqs", action = "Configure", area = AreaNames.Admin });
            endpointRouteBuilder.MapControllerRoute(FaqsDefaults.ConfigurationRouteName, "Plugins/Faqs/List", new { controller = "Faqs", action = "List", area = AreaNames.Admin });
            endpointRouteBuilder.MapControllerRoute(FaqsDefaults.ConfigurationRouteName, "Plugins/Faqs/Add", new { controller = "Faqs", action = "Add", area = AreaNames.Admin });
            endpointRouteBuilder.MapControllerRoute(FaqsDefaults.ConfigurationRouteName, "faqs", new { controller = "FaqsView", action = "index" });
        }

        /// <summary>
        /// Gets a priority of route provider
        /// </summary>
        public int Priority => 0;
    }
}