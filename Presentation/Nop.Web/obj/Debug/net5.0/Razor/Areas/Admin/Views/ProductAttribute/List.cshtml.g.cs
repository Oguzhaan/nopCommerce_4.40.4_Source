#pragma checksum "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\ProductAttribute\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "00cebf8a3933cee74313df300f9a57409516d5f9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_ProductAttribute_List), @"mvc.1.0.view", @"/Areas/Admin/Views/ProductAttribute/List.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
#nullable restore
#line 9 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\_ViewImports.cshtml"
using System.Text.Encodings.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Mvc.ViewFeatures;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\_ViewImports.cshtml"
using Microsoft.Extensions.Primitives;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\_ViewImports.cshtml"
using Nop.Core;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\_ViewImports.cshtml"
using Nop.Core.Domain.Common;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\_ViewImports.cshtml"
using Nop.Core.Events;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\_ViewImports.cshtml"
using Nop.Core.Infrastructure;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\_ViewImports.cshtml"
using Nop.Services.Common;

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\_ViewImports.cshtml"
using static Nop.Services.Common.NopLinksDefaults;

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\_ViewImports.cshtml"
using Nop.Web.Areas.Admin.Models.Affiliates;

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\_ViewImports.cshtml"
using Nop.Web.Areas.Admin.Models.Blogs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\_ViewImports.cshtml"
using Nop.Web.Areas.Admin.Models.Catalog;

#line default
#line hidden
#nullable disable
#nullable restore
#line 22 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\_ViewImports.cshtml"
using Nop.Web.Areas.Admin.Models.Cms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 23 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\_ViewImports.cshtml"
using Nop.Web.Areas.Admin.Models.Common;

#line default
#line hidden
#nullable disable
#nullable restore
#line 24 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\_ViewImports.cshtml"
using Nop.Web.Areas.Admin.Models.Customers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 25 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\_ViewImports.cshtml"
using Nop.Web.Areas.Admin.Models.Directory;

#line default
#line hidden
#nullable disable
#nullable restore
#line 26 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\_ViewImports.cshtml"
using Nop.Web.Areas.Admin.Models.Discounts;

#line default
#line hidden
#nullable disable
#nullable restore
#line 27 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\_ViewImports.cshtml"
using Nop.Web.Areas.Admin.Models.ExternalAuthentication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 28 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\_ViewImports.cshtml"
using Nop.Web.Areas.Admin.Models.Forums;

#line default
#line hidden
#nullable disable
#nullable restore
#line 29 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\_ViewImports.cshtml"
using Nop.Web.Areas.Admin.Models.Home;

#line default
#line hidden
#nullable disable
#nullable restore
#line 30 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\_ViewImports.cshtml"
using Nop.Web.Areas.Admin.Models.Localization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 31 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\_ViewImports.cshtml"
using Nop.Web.Areas.Admin.Models.Logging;

#line default
#line hidden
#nullable disable
#nullable restore
#line 32 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\_ViewImports.cshtml"
using Nop.Web.Areas.Admin.Models.Messages;

#line default
#line hidden
#nullable disable
#nullable restore
#line 33 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\_ViewImports.cshtml"
using Nop.Web.Areas.Admin.Models.MultiFactorAuthentication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 34 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\_ViewImports.cshtml"
using Nop.Web.Areas.Admin.Models.News;

#line default
#line hidden
#nullable disable
#nullable restore
#line 35 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\_ViewImports.cshtml"
using Nop.Web.Areas.Admin.Models.Orders;

#line default
#line hidden
#nullable disable
#nullable restore
#line 36 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\_ViewImports.cshtml"
using Nop.Web.Areas.Admin.Models.Payments;

#line default
#line hidden
#nullable disable
#nullable restore
#line 37 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\_ViewImports.cshtml"
using Nop.Web.Areas.Admin.Models.Plugins;

#line default
#line hidden
#nullable disable
#nullable restore
#line 38 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\_ViewImports.cshtml"
using Nop.Web.Areas.Admin.Models.Plugins.Marketplace;

#line default
#line hidden
#nullable disable
#nullable restore
#line 39 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\_ViewImports.cshtml"
using Nop.Web.Areas.Admin.Models.Polls;

#line default
#line hidden
#nullable disable
#nullable restore
#line 40 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\_ViewImports.cshtml"
using Nop.Web.Areas.Admin.Models.Reports;

#line default
#line hidden
#nullable disable
#nullable restore
#line 41 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\_ViewImports.cshtml"
using Nop.Web.Areas.Admin.Models.Security;

#line default
#line hidden
#nullable disable
#nullable restore
#line 42 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\_ViewImports.cshtml"
using Nop.Web.Areas.Admin.Models.Settings;

#line default
#line hidden
#nullable disable
#nullable restore
#line 43 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\_ViewImports.cshtml"
using Nop.Web.Areas.Admin.Models.Shipping;

#line default
#line hidden
#nullable disable
#nullable restore
#line 44 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\_ViewImports.cshtml"
using Nop.Web.Areas.Admin.Models.ShoppingCart;

#line default
#line hidden
#nullable disable
#nullable restore
#line 45 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\_ViewImports.cshtml"
using Nop.Web.Areas.Admin.Models.Stores;

#line default
#line hidden
#nullable disable
#nullable restore
#line 46 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\_ViewImports.cshtml"
using Nop.Web.Areas.Admin.Models.Tasks;

#line default
#line hidden
#nullable disable
#nullable restore
#line 47 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\_ViewImports.cshtml"
using Nop.Web.Areas.Admin.Models.Tax;

#line default
#line hidden
#nullable disable
#nullable restore
#line 48 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\_ViewImports.cshtml"
using Nop.Web.Areas.Admin.Models.Templates;

#line default
#line hidden
#nullable disable
#nullable restore
#line 49 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\_ViewImports.cshtml"
using Nop.Web.Areas.Admin.Models.Topics;

#line default
#line hidden
#nullable disable
#nullable restore
#line 50 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\_ViewImports.cshtml"
using Nop.Web.Areas.Admin.Models.Vendors;

#line default
#line hidden
#nullable disable
#nullable restore
#line 51 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\_ViewImports.cshtml"
using Nop.Web.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 52 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\_ViewImports.cshtml"
using Nop.Web.Framework;

#line default
#line hidden
#nullable disable
#nullable restore
#line 53 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\_ViewImports.cshtml"
using Nop.Web.Framework.Menu;

#line default
#line hidden
#nullable disable
#nullable restore
#line 54 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\_ViewImports.cshtml"
using Nop.Web.Framework.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 55 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\_ViewImports.cshtml"
using Nop.Web.Framework.Events;

#line default
#line hidden
#nullable disable
#nullable restore
#line 56 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\_ViewImports.cshtml"
using Nop.Web.Framework.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 57 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\_ViewImports.cshtml"
using Nop.Web.Framework.Infrastructure;

#line default
#line hidden
#nullable disable
#nullable restore
#line 58 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\_ViewImports.cshtml"
using Nop.Web.Framework.Models.DataTables;

#line default
#line hidden
#nullable disable
#nullable restore
#line 59 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\_ViewImports.cshtml"
using Nop.Web.Framework.Security.Captcha;

#line default
#line hidden
#nullable disable
#nullable restore
#line 60 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\_ViewImports.cshtml"
using Nop.Web.Framework.Security.Honeypot;

#line default
#line hidden
#nullable disable
#nullable restore
#line 61 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\_ViewImports.cshtml"
using Nop.Web.Framework.Themes;

#line default
#line hidden
#nullable disable
#nullable restore
#line 62 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\_ViewImports.cshtml"
using Nop.Web.Framework.UI;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"00cebf8a3933cee74313df300f9a57409516d5f9", @"/Areas/Admin/Views/ProductAttribute/List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"181066c519b5e3a88fbfc1b430cb86e3463f4c97", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_ProductAttribute_List : Nop.Web.Framework.Mvc.Razor.NopRazorPage<ProductAttributeSearchModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-button-id", "delete-selected", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-alert-id", "deleteSelectedFailed", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Nop.Web.Framework.TagHelpers.Admin.NopActionConfirmationTagHelper __Nop_Web_Framework_TagHelpers_Admin_NopActionConfirmationTagHelper;
        private global::Nop.Web.Framework.TagHelpers.Admin.NopDocReferenceTagHelper __Nop_Web_Framework_TagHelpers_Admin_NopDocReferenceTagHelper;
        private global::Nop.Web.Framework.TagHelpers.Admin.NopAlertTagHelper __Nop_Web_Framework_TagHelpers_Admin_NopAlertTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\ProductAttribute\List.cshtml"
  
    //page title
    ViewBag.PageTitle = T("Admin.Catalog.Attributes.ProductAttributes").Text;
    //active menu item (system name)
    Html.SetActiveMenuItemSystemName("Product attributes");

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div class=\"content-header clearfix\">\r\n    <h1 class=\"float-left\">\r\n        ");
#nullable restore
#line 13 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\ProductAttribute\List.cshtml"
   Write(T("Admin.Catalog.Attributes.ProductAttributes"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </h1>\r\n    <div class=\"float-right\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "00cebf8a3933cee74313df300f9a57409516d5f917787", async() => {
                WriteLiteral("\r\n            <i class=\"fas fa-plus-square\"></i>\r\n            ");
#nullable restore
#line 18 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\ProductAttribute\List.cshtml"
       Write(T("Admin.Common.AddNew"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        ");
#nullable restore
#line 20 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\ProductAttribute\List.cshtml"
   Write(await Component.InvokeAsync("AdminWidget", new { widgetZone = AdminWidgetZones.ProductAttributeListButtons }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        <button type=\"button\" id=\"delete-selected\" class=\"btn btn-danger\">\r\n            <i class=\"far fa-trash-alt\"></i>\r\n            ");
#nullable restore
#line 23 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\ProductAttribute\List.cshtml"
       Write(T("Admin.Common.Delete.Selected"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </button>\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("nop-action-confirmation", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "00cebf8a3933cee74313df300f9a57409516d5f920195", async() => {
            }
            );
            __Nop_Web_Framework_TagHelpers_Admin_NopActionConfirmationTagHelper = CreateTagHelper<global::Nop.Web.Framework.TagHelpers.Admin.NopActionConfirmationTagHelper>();
            __tagHelperExecutionContext.Add(__Nop_Web_Framework_TagHelpers_Admin_NopActionConfirmationTagHelper);
            __Nop_Web_Framework_TagHelpers_Admin_NopActionConfirmationTagHelper.ButtonId = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n</div>\r\n\r\n<section class=\"content\">\r\n    <div class=\"container-fluid\">\r\n    <div class=\"cards-group\">\r\n        <div class=\"card card-default\">\r\n            <div class=\"card-body\">\r\n                <p>\r\n                    ");
#nullable restore
#line 35 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\ProductAttribute\List.cshtml"
               Write(T("Admin.Catalog.Attributes.ProductAttributes.Description"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("nop-doc-reference", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "00cebf8a3933cee74313df300f9a57409516d5f921983", async() => {
            }
            );
            __Nop_Web_Framework_TagHelpers_Admin_NopDocReferenceTagHelper = CreateTagHelper<global::Nop.Web.Framework.TagHelpers.Admin.NopDocReferenceTagHelper>();
            __tagHelperExecutionContext.Add(__Nop_Web_Framework_TagHelpers_Admin_NopDocReferenceTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 36 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\ProductAttribute\List.cshtml"
                                                WriteLiteral(T("Admin.Documentation.Reference.ProductAttributes", Docs.ProductAttributes + Utm.OnAdmin));

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Nop_Web_Framework_TagHelpers_Admin_NopDocReferenceTagHelper.StringResource = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-string-resource", __Nop_Web_Framework_TagHelpers_Admin_NopDocReferenceTagHelper.StringResource, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 36 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\ProductAttribute\List.cshtml"
__Nop_Web_Framework_TagHelpers_Admin_NopDocReferenceTagHelper.AddWrapper = false;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-add-wrapper", __Nop_Web_Framework_TagHelpers_Admin_NopDocReferenceTagHelper.AddWrapper, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </p>\r\n                ");
#nullable restore
#line 38 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\ProductAttribute\List.cshtml"
           Write(await Html.PartialAsync("Table", new DataTablesModel
                {
                    Name = "products-grid",
                    UrlRead = new DataUrl("List", "ProductAttribute", null),
                    Length = Model.PageSize,
                    LengthMenu = Model.AvailablePageSizes,
                    ColumnCollection = new List<ColumnProperty>
                    {
                         new ColumnProperty(nameof(ProductAttributeModel.Id))
                        {
                            IsMasterCheckBox = true,
                            Render = new RenderCheckBox("checkbox_productattributes"),
                            ClassName =  NopColumnClassDefaults.CenterAll,
                            Width = "50"
                        },
                        new ColumnProperty(nameof(ProductAttributeModel.Name))
                        {
                            Title = T("Admin.Catalog.Attributes.ProductAttributes.Fields.Name").Text
                        },
                        new ColumnProperty(nameof(ProductAttributeModel.Id))
                        {
                            Title = T("Admin.Common.Edit").Text,
                            Width = "100",
                            ClassName =  NopColumnClassDefaults.Button,
                            Render = new RenderButtonEdit(new DataUrl("Edit"))
                        }
                    }
                }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

                <script>
                    $(document).ready(function () {
                        $('#delete-selected-action-confirmation-submit-button').bind('click', function () {
                            var postData = {
                                selectedIds: selectedIds
                            };
                            addAntiForgeryToken(postData);
                            $.ajax({
                                cache: false,
                                type: ""POST"",
                                url: """);
#nullable restore
#line 77 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\ProductAttribute\List.cshtml"
                                  Write(Url.Action("DeleteSelected", "ProductAttribute"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@""",
                                data: postData,
                                error: function (jqXHR, textStatus, errorThrown) {
                                    $('#deleteSelectedFailed-info').text(errorThrown);
                                    $('#deleteSelectedFailed').click();
                                },
                                complete: function (jqXHR, textStatus) {
                                    updateTable('#products-grid');
                                }
                            });
                            $('#delete-selected-action-confirmation').modal('toggle');
                            return false;
                        });
                    });
                </script>
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("nop-alert", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "00cebf8a3933cee74313df300f9a57409516d5f927699", async() => {
            }
            );
            __Nop_Web_Framework_TagHelpers_Admin_NopAlertTagHelper = CreateTagHelper<global::Nop.Web.Framework.TagHelpers.Admin.NopAlertTagHelper>();
            __tagHelperExecutionContext.Add(__Nop_Web_Framework_TagHelpers_Admin_NopAlertTagHelper);
            __Nop_Web_Framework_TagHelpers_Admin_NopAlertTagHelper.AlertId = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n</section>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IWorkContext workContext { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IGenericAttributeService genericAttributeService { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProductAttributeSearchModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
