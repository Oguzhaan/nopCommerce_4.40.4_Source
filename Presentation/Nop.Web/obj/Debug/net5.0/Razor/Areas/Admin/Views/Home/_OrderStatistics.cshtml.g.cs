#pragma checksum "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\Home\_OrderStatistics.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "12fd376cd8f5920d77c1fb1b5c9acfb8b5a5a055"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Home__OrderStatistics), @"mvc.1.0.view", @"/Areas/Admin/Views/Home/_OrderStatistics.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"12fd376cd8f5920d77c1fb1b5c9acfb8b5a5a055", @"/Areas/Admin/Views/Home/_OrderStatistics.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"181066c519b5e3a88fbfc1b430cb86e3463f4c97", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Home__OrderStatistics : Nop.Web.Framework.Mvc.Razor.NopRazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\Home\_OrderStatistics.cshtml"
  
    Html.AppendScriptParts("~/lib_npm/chart.js/Chart.min.js");

    const string prefix = "order-statistics";
    const string hideCardAttributeName = "Reports.HideOrderStatisticsCard";
    var hideCard = await genericAttributeService.GetAttributeAsync<bool>(await workContext.GetCurrentCustomerAsync(), hideCardAttributeName);
    

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div");
            BeginWriteAttribute("class", " class=\"", 464, "\"", 546, 4);
            WriteAttributeValue("", 472, "card", 472, 4, true);
            WriteAttributeValue(" ", 476, "card-primary", 477, 13, true);
            WriteAttributeValue(" ", 489, "card-outline", 490, 13, true);
            WriteAttributeValue(" ", 502, new Microsoft.AspNetCore.Mvc.Razor.HelperResult(async(__razor_attribute_value_writer) => {
                PushWriter(__razor_attribute_value_writer);
#nullable restore
#line 12 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\Home\_OrderStatistics.cshtml"
                                            if (hideCard){

#line default
#line hidden
#nullable disable
                WriteLiteral("collapsed-card");
#nullable restore
#line 12 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\Home\_OrderStatistics.cshtml"
                                                                                     }

#line default
#line hidden
#nullable disable
                PopWriter();
            }
            ), 503, 43, false);
            EndWriteAttribute();
            BeginWriteAttribute("id", " id=\"", 547, "\"", 566, 2);
#nullable restore
#line 12 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\Home\_OrderStatistics.cshtml"
WriteAttributeValue("", 552, prefix, 552, 9, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 561, "-card", 561, 5, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n    <div class=\"card-header with-border\">\r\n        <h3 class=\"card-title\">\r\n            <i class=\"fas fa-shopping-cart\"></i>\r\n            ");
#nullable restore
#line 16 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\Home\_OrderStatistics.cshtml"
       Write(T("Admin.SalesReport.OrderStatistics"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </h3>\r\n        <div class=\"card-tools float-right\">\r\n            <button class=\"btn btn-xs btn-info btn-flat margin-r-5\" ");
#nullable restore
#line 19 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\Home\_OrderStatistics.cshtml"
                                                                     if (hideCard) { 

#line default
#line hidden
#nullable disable
            WriteLiteral(" disabled=\"disabled\" ");
#nullable restore
#line 19 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\Home\_OrderStatistics.cshtml"
                                                                                                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(" data-chart-role=\"toggle-chart\" data-chart-period=\"year\">");
#nullable restore
#line 19 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\Home\_OrderStatistics.cshtml"
                                                                                                                                                                             Write(T("Admin.SalesReport.OrderStatistics.Year"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</button>\r\n            <button class=\"btn btn-xs btn-info btn-flat margin-r-5\" ");
#nullable restore
#line 20 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\Home\_OrderStatistics.cshtml"
                                                                     if (hideCard) { 

#line default
#line hidden
#nullable disable
            WriteLiteral(" disabled=\"disabled\" ");
#nullable restore
#line 20 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\Home\_OrderStatistics.cshtml"
                                                                                                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(" data-chart-role=\"toggle-chart\" data-chart-period=\"month\">");
#nullable restore
#line 20 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\Home\_OrderStatistics.cshtml"
                                                                                                                                                                              Write(T("Admin.SalesReport.OrderStatistics.Month"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</button>\r\n            <button class=\"btn btn-xs btn-info btn-flat\" ");
#nullable restore
#line 21 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\Home\_OrderStatistics.cshtml"
                                                          if (hideCard) { 

#line default
#line hidden
#nullable disable
            WriteLiteral(" disabled=\"disabled\" ");
#nullable restore
#line 21 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\Home\_OrderStatistics.cshtml"
                                                                                                             }

#line default
#line hidden
#nullable disable
            WriteLiteral(" data-chart-role=\"toggle-chart\" data-chart-period=\"week\">");
#nullable restore
#line 21 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\Home\_OrderStatistics.cshtml"
                                                                                                                                                                  Write(T("Admin.SalesReport.OrderStatistics.Week"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</button>\r\n            <button type=\"button\" class=\"btn btn-tool margin-l-10\" data-card-widget=\"collapse\">\r\n");
#nullable restore
#line 23 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\Home\_OrderStatistics.cshtml"
                 if (hideCard)
                {
                    

#line default
#line hidden
#nullable disable
            WriteLiteral("<i class=\"fas fa-plus\"></i>");
#nullable restore
#line 25 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\Home\_OrderStatistics.cshtml"
                                                            
                }
                else
                {
                    

#line default
#line hidden
#nullable disable
            WriteLiteral("<i class=\"fas fa-minus\"></i>");
#nullable restore
#line 29 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\Home\_OrderStatistics.cshtml"
                                                             
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </button>\r\n        </div>\r\n    </div>\r\n    <div class=\"card-body\">\r\n        <div class=\"chart\" style=\"height: 300px;\">\r\n            <canvas");
            BeginWriteAttribute("id", " id=\"", 2003, "\"", 2023, 2);
#nullable restore
#line 36 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\Home\_OrderStatistics.cshtml"
WriteAttributeValue("", 2008, prefix, 2008, 9, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2017, "-chart", 2017, 6, true);
            EndWriteAttribute();
            WriteLiteral(" height=\"300\"></canvas>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n<script>\r\n    $(document).ready(function () {\r\n        var osCurrentPeriod;\r\n\r\n        $(\'#");
#nullable restore
#line 45 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\Home\_OrderStatistics.cshtml"
        Write(prefix);

#line default
#line hidden
#nullable disable
            WriteLiteral("-card\').on(\'click\', \'button[data-card-widget=\"collapse\"]\', function () {\r\n            var collapsed = !$(\'#");
#nullable restore
#line 46 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\Home\_OrderStatistics.cshtml"
                             Write(prefix);

#line default
#line hidden
#nullable disable
            WriteLiteral("-card\').hasClass(\'collapsed-card\');\r\n            saveUserPreferences(\'");
#nullable restore
#line 47 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\Home\_OrderStatistics.cshtml"
                             Write(Url.Action("SavePreference", "Preferences"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\', \'");
#nullable restore
#line 47 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\Home\_OrderStatistics.cshtml"
                                                                              Write(hideCardAttributeName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\', collapsed);\r\n            \r\n            if (!collapsed) {\r\n                $(\'#");
#nullable restore
#line 50 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\Home\_OrderStatistics.cshtml"
                Write(prefix);

#line default
#line hidden
#nullable disable
            WriteLiteral("-card button[data-chart-role=\"toggle-chart\"]\').removeAttr(\'disabled\');\r\n                if (!osCurrentPeriod) {\r\n                    $(\'#");
#nullable restore
#line 52 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\Home\_OrderStatistics.cshtml"
                    Write(prefix);

#line default
#line hidden
#nullable disable
            WriteLiteral("-card button[data-chart-role=\"toggle-chart\"][data-chart-period=\"week\"]\').trigger(\'click\');\r\n                }\r\n            } else {\r\n                $(\'#");
#nullable restore
#line 55 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\Home\_OrderStatistics.cshtml"
                Write(prefix);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"-card button[data-chart-role=""toggle-chart""]').attr('disabled', 'disabled');
            }
        });

        var osConfig = {
            type: 'line',
            data: {
                labels: [],
                datasets: [
                    {
                        label: """);
#nullable restore
#line 65 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\Home\_OrderStatistics.cshtml"
                           Write(T("Admin.SalesReport.OrderStatistics"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@""",
                        fillColor: ""rgba(60,141,188,0.9)"",
                        strokeColor: ""rgba(60,141,188,0.8)"",
                        pointColor: ""#3b8bba"",
                        pointStrokeColor: ""rgba(60,141,188,1)"",
                        pointHighlightFill: ""#fff"",
                        pointHighlightStroke: ""rgba(60,141,188,1)"",
                        borderColor: 'rgba(60, 141, 188, 0.7)',
                        backgroundColor: 'rgba(44, 152, 214, 0.5)',
                        pointBorderColor: 'rgba(37, 103, 142, 0.9)',
                        pointBackgroundColor: 'rgba(60, 141, 188, 0.4)',
                        pointBorderWidth: 1,
                        data: []
                    }
                ]
            },
            options: {
                legend: {
                    display: false
                },
                scales: {
                    xAxes: [{
                        display: true,
                        ticks: {
        ");
            WriteLiteral(@"                    userCallback: function (dataLabel, index) {
                                if (window.orderStatistics && window.orderStatistics.config.data.labels.length > 12) {
                                    return index % 5 === 0 ? dataLabel : '';
                                }
                                return dataLabel;
                            }
                        }
                    }],
                    yAxes: [{
                        display: true,
                        ticks: {
                            userCallback: function (dataLabel, index) {
                                return (dataLabel ^ 0) === dataLabel ? dataLabel : '';
                            },
                            min: 0
                        }
                    }]
                },
                showScale: true,
                scaleShowGridLines: false,
                scaleGridLineColor: ""rgba(0,0,0,.05)"",
                scaleGridLineWidth: 1,
             ");
            WriteLiteral(@"   scaleShowHorizontalLines: true,
                scaleShowVerticalLines: true,
                bezierCurve: true,
                pointDot: false,
                pointDotRadius: 4,
                pointDotStrokeWidth: 1,
                pointHitDetectionRadius: 20,
                datasetStroke: true,
                datasetFill: true,
                maintainAspectRatio: false,
                responsive: true
            }
        };

        function changeOsPeriod(period) {
            var osLabels = [];
            var osData = [];

            $.ajax({
                cache: false,
                type: ""GET"",
                url: """);
#nullable restore
#line 132 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\Home\_OrderStatistics.cshtml"
                 Write(Url.Action("LoadOrderStatistics", "Order"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@""",
                data: {
                    period: period
                },
                success: function (data, textStatus, jqXHR) {
                    for (var i = 0; i < data.length; i++) {
                        osLabels.push(data[i].date);
                        osData.push(data[i].value);
                    }

                    if (!window.orderStatistics) {
                        osConfig.data.labels = osLabels;
                        osConfig.data.datasets[0].data = osData;
                        osConfig.data.scales =
                        window.orderStatistics = new Chart(document.getElementById(""");
#nullable restore
#line 146 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\Home\_OrderStatistics.cshtml"
                                                                               Write(prefix);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"-chart"").getContext(""2d""), osConfig);
                    } else {
                        window.orderStatistics.config.data.labels = osLabels;
                        window.orderStatistics.config.data.datasets[0].data = osData;
                        window.orderStatistics.update();
                    }
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    $(""#loadOrderStatisticsAlert"").click();
                }
            });
        }

        $('#");
#nullable restore
#line 159 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\Home\_OrderStatistics.cshtml"
        Write(prefix);

#line default
#line hidden
#nullable disable
            WriteLiteral("-card button[data-chart-role=\"toggle-chart\"]\').on(\'click\', function () {\r\n            var period = $(this).attr(\'data-chart-period\');\r\n            osCurrentPeriod = period;\r\n            changeOsPeriod(period);\r\n            $(\'#");
#nullable restore
#line 163 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\Home\_OrderStatistics.cshtml"
            Write(prefix);

#line default
#line hidden
#nullable disable
            WriteLiteral("-card button[data-chart-role=\"toggle-chart\"]\').removeClass(\'bg-light-blue\');\r\n            $(this).addClass(\'bg-light-blue\');\r\n        });\r\n\r\n");
#nullable restore
#line 167 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\Home\_OrderStatistics.cshtml"
         if (!hideCard)
        {
            
            

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                $(\'#");
#nullable restore
#line 171 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\Home\_OrderStatistics.cshtml"
                Write(prefix);

#line default
#line hidden
#nullable disable
            WriteLiteral("-card button[data-chart-role=\"toggle-chart\"][data-chart-period=\"week\"]\').trigger(\'click\');\r\n            ");
#nullable restore
#line 172 "C:\Users\oguzh\Desktop\nopCommerce_4.40.4_Source\Presentation\Nop.Web\Areas\Admin\Views\Home\_OrderStatistics.cshtml"
                   
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    });\r\n</script>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IWorkContext workContext { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Nop.Services.Common.IGenericAttributeService genericAttributeService { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
