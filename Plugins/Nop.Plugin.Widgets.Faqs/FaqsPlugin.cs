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

namespace Nop.Plugin.Widgets.Faqs
{
    /// <summary>
    /// Represents the plugin implementation
    /// </summary>
    public class FaqsPlugin : BasePlugin, IWidgetPlugin, IAdminMenuPlugin
    {
        #region Fields

        private readonly FaqsSettings _faqsSettings;
        private readonly IActionContextAccessor _actionContextAccessor;
        private readonly ILocalizationService _localizationService;
        private readonly ISettingService _settingService;
        private readonly IStoreService _storeService;
        private readonly IUrlHelperFactory _urlHelperFactory;


        #endregion

        #region Ctor

        public FaqsPlugin(FaqsSettings faqsSettings,
            IActionContextAccessor actionContextAccessor,
            ILocalizationService localizationService,
            ISettingService settingService,
            IStoreService storeService,
            IUrlHelperFactory urlHelperFactory)
        {
            _faqsSettings = faqsSettings;
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
            return _urlHelperFactory.GetUrlHelper(_actionContextAccessor.ActionContext).RouteUrl(FaqsDefaults.ConfigurationRouteName);
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
            return Task.FromResult<IList<string>>(new List<string> { _faqsSettings.WidgetZone });
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

            return FaqsDefaults.VIEW_COMPONENT;
        }

        /// <summary>
        /// Install plugin
        /// </summary>
        /// <returns>A task that represents the asynchronous operation</returns>
        public override async Task InstallAsync()
        {
            await _settingService.SaveSettingAsync(new FaqsSettings
            {
                WidgetZone = PublicWidgetZones.HeaderLinksAfter
            });

            await _localizationService.AddLocaleResourceAsync(new Dictionary<string, string>
            {
                ["Plugins.Widgets.Faqs.WidgetZone"] = "Widget Zone",
                ["Plugins.Widgets.Faqs.ViewZone"] = "View Zone",
                ["Plugins.Widgets.Faqs.HeaderAfter"] = "Header After",
                ["Plugins.Widgets.Faqs.Add"] = "Widget Zone",
                ["Plugins.Widgets.Faqs.EditWherePlugin"] = "Edit where the plugin appears",
                ["Plugins.Widgets.Faqs.AddFaqStr"] = "Please click to add new FAQ",
                ["Plugins.Widgets.Faqs.EditWherePlugin"] = "Please click to add new FAQ",
                ["Plugins.Widgets.Faqs.EditFaqList"] = "Faq Add & Edit",
                ["Plugins.Widgets.Faqs.FaqsViewText"] = "Faqs",
                ["Plugins.Widgets.Faqs.FaqsListDeleteButton"] = "Delete",
                ["Plugins.Widgets.Faqs.FaqsListHeaderTitle"] = "Faq List",
                ["Plugins.Widgets.Faqs.FaqsListTitle"] = "Title",
                ["Plugins.Widgets.Faqs.FaqsListDescription"] = "Description",
                ["Plugins.Widgets.Faqs.FaqsListOrder"] = "Order",
                ["Plugins.Widgets.Faqs.Settings"] = "Settings",
                ["Plugins.Widgets.Faqs.FaqsListUpdateButton"] = "Edit",
                ["Plugins.Widgets.Faqs.FaqsListSaveButton"] = "Save",
            });


            await base.InstallAsync();
        }

        /// <summary>
        /// Uninstall plugin
        /// </summary>
        /// <returns>A task that represents the asynchronous operation</returns>
        public override async Task UninstallAsync()
        {
            await _settingService.DeleteSettingAsync<FaqsSettings>();

            var stores = await _storeService.GetAllStoresAsync();
            var storeIds = new List<int> { 0 }.Union(stores.Select(store => store.Id));
            foreach (var storeId in storeIds)
            {
                var widgetSettings = await _settingService.LoadSettingAsync<WidgetSettings>(storeId);
                widgetSettings.ActiveWidgetSystemNames.Remove(FaqsDefaults.SystemName);
                await _settingService.SaveSettingAsync(widgetSettings);
            }

            await _localizationService.DeleteLocaleResourcesAsync("Plugins.Widgets.Faqs");

            await base.UninstallAsync();
        }

        public Task ManageSiteMapAsync(SiteMapNode rootNode)
        {

            var parentNode = new SiteMapNode()
            {
                SystemName = this.PluginDescriptor.SystemName,
                Title = "Faqs",
                IconClass = "fas fa-question",
                Visible = true,
                RouteValues = new RouteValueDictionary() { { "area", null } },
            };
            parentNode.ChildNodes.Add(new SiteMapNode()
            {
                Title = "Configure",
                ControllerName = "Faqs", // Your controller Name
                ActionName = "Configure", // Action Name
                Visible = true,
                SystemName = this.PluginDescriptor.SystemName,
                RouteValues = new RouteValueDictionary() { },
            });
            parentNode.ChildNodes.Add(new SiteMapNode()
            {
                SystemName = FaqsDefaults.SystemName,
                Title = "Faq Add",
                ControllerName = "Faqs",
                ActionName = "Add",
                Visible = true,
                RouteValues = new RouteValueDictionary() { }
            });
            parentNode.ChildNodes.Add(new SiteMapNode()
            {
                SystemName = FaqsDefaults.SystemName,
                Title = "Faq List",
                ControllerName = "Faqs",
                ActionName = "List",
                Visible = true,
                RouteValues = new RouteValueDictionary() {   }
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