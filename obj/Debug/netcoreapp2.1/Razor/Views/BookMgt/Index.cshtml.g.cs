#pragma checksum "/home/lois/Desktop/ASP.NET Projects/selahseries/SelahSeries/Views/BookMgt/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "eac7387001afb3ef7b01eee354c34481553d6fd9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_BookMgt_Index), @"mvc.1.0.view", @"/Views/BookMgt/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/BookMgt/Index.cshtml", typeof(AspNetCore.Views_BookMgt_Index))]
namespace AspNetCore
{
    #line hidden
#line 3 "/home/lois/Desktop/ASP.NET Projects/selahseries/SelahSeries/Views/_ViewImports.cshtml"
using System;

#line default
#line hidden
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "/home/lois/Desktop/ASP.NET Projects/selahseries/SelahSeries/Views/_ViewImports.cshtml"
using SelahSeries;

#line default
#line hidden
#line 2 "/home/lois/Desktop/ASP.NET Projects/selahseries/SelahSeries/Views/_ViewImports.cshtml"
using SelahSeries.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eac7387001afb3ef7b01eee354c34481553d6fd9", @"/Views/BookMgt/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"84561363502251a09f83bf6d07149c1c007baf6b", @"/Views/_ViewImports.cshtml")]
    public class Views_BookMgt_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SelahSeries.Models.Book>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/NewFolder2/js/blogmgt.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary btn-lg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(44, 1, true);
            WriteLiteral("\n");
            EndContext();
#line 3 "/home/lois/Desktop/ASP.NET Projects/selahseries/SelahSeries/Views/BookMgt/Index.cshtml"
  
    ViewData["Title"] = "Index";
    ViewData["Add Navigation"] = "false";

#line default
#line hidden
            DefineSection("AddToEnd", async() => {
                BeginContext(144, 5, true);
                WriteLiteral("\n    ");
                EndContext();
                BeginContext(149, 50, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7f0466f9c2c74e85b992e0f186fb7627", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(199, 1, true);
                WriteLiteral("\n");
                EndContext();
            }
            );
            BeginContext(202, 197, true);
            WriteLiteral("<div style=\"color: #ffcc00; background-color:black;\" class=\"jumbotron text-center\">\n    <h1>Book Management Page <br /> (List of Books)</h1>\n    <p> Add, Delete, and Edit Books Here...</p>\n</div>\n\n");
            EndContext();
            BeginContext(400, 43, false);
#line 15 "/home/lois/Desktop/ASP.NET Projects/selahseries/SelahSeries/Views/BookMgt/Index.cshtml"
Write(await Html.PartialAsync("AlertViewPartial"));

#line default
#line hidden
            EndContext();
            BeginContext(443, 9, true);
            WriteLiteral("\n<p>\n    ");
            EndContext();
            BeginContext(452, 70, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "eb2a69f608674eefa586b3963227d1e5", async() => {
                BeginContext(506, 12, true);
                WriteLiteral("Add New Book");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(522, 178, true);
            WriteLiteral("\n</p>\n<table style=\"width:100%; text-align:center;\" class=\"table table-striped table-responsive\">\n    <thead>\n        <tr>\n            <th></th>\n            <th>\n                ");
            EndContext();
            BeginContext(701, 41, false);
#line 24 "/home/lois/Desktop/ASP.NET Projects/selahseries/SelahSeries/Views/BookMgt/Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Title));

#line default
#line hidden
            EndContext();
            BeginContext(742, 52, true);
            WriteLiteral("\n            </th>\n            <th>\n                ");
            EndContext();
            BeginContext(795, 42, false);
#line 27 "/home/lois/Desktop/ASP.NET Projects/selahseries/SelahSeries/Views/BookMgt/Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Author));

#line default
#line hidden
            EndContext();
            BeginContext(837, 53, true);
            WriteLiteral("\n            </th>\n            <th>\n\n                ");
            EndContext();
            BeginContext(891, 46, false);
#line 31 "/home/lois/Desktop/ASP.NET Projects/selahseries/SelahSeries/Views/BookMgt/Index.cshtml"
           Write(Html.DisplayNameFor(model => model.CategoryId));

#line default
#line hidden
            EndContext();
            BeginContext(937, 52, true);
            WriteLiteral("\n            </th>\n            <th>\n                ");
            EndContext();
            BeginContext(990, 44, false);
#line 34 "/home/lois/Desktop/ASP.NET Projects/selahseries/SelahSeries/Views/BookMgt/Index.cshtml"
           Write(Html.DisplayNameFor(model => model.ImageUrl));

#line default
#line hidden
            EndContext();
            BeginContext(1034, 52, true);
            WriteLiteral("\n            </th>\n            <th>\n                ");
            EndContext();
            BeginContext(1087, 46, false);
#line 37 "/home/lois/Desktop/ASP.NET Projects/selahseries/SelahSeries/Views/BookMgt/Index.cshtml"
           Write(Html.DisplayNameFor(model => model.IsHardBook));

#line default
#line hidden
            EndContext();
            BeginContext(1133, 52, true);
            WriteLiteral("\n            </th>\n            <th>\n                ");
            EndContext();
            BeginContext(1186, 41, false);
#line 40 "/home/lois/Desktop/ASP.NET Projects/selahseries/SelahSeries/Views/BookMgt/Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Price));

#line default
#line hidden
            EndContext();
            BeginContext(1227, 58, true);
            WriteLiteral("\n            </th>\n        </tr>\n    </thead>\n    <tbody>\n");
            EndContext();
#line 45 "/home/lois/Desktop/ASP.NET Projects/selahseries/SelahSeries/Views/BookMgt/Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
            BeginContext(1332, 106, true);
            WriteLiteral("            <tr>\n                <td>\n                    <div class=\"btn-group\">\n                        ");
            EndContext();
            BeginContext(1438, 78, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f5b7cfa04b4e4e24892c4b932e52ac39", async() => {
                BeginContext(1508, 4, true);
                WriteLiteral("Edit");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 50 "/home/lois/Desktop/ASP.NET Projects/selahseries/SelahSeries/Views/BookMgt/Index.cshtml"
                                                                    WriteLiteral(item.BookId);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1516, 25, true);
            WriteLiteral("\n                        ");
            EndContext();
            BeginContext(1541, 84, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c33583d66ea24814a64701acd925d13d", async() => {
                BeginContext(1615, 6, true);
                WriteLiteral("Delete");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 51 "/home/lois/Desktop/ASP.NET Projects/selahseries/SelahSeries/Views/BookMgt/Index.cshtml"
                                                                        WriteLiteral(item.BookId);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1625, 91, true);
            WriteLiteral("\n                    </div>\n                </td>\n                <td>\n                    ");
            EndContext();
            BeginContext(1717, 40, false);
#line 55 "/home/lois/Desktop/ASP.NET Projects/selahseries/SelahSeries/Views/BookMgt/Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Title));

#line default
#line hidden
            EndContext();
            BeginContext(1757, 64, true);
            WriteLiteral("\n                </td>\n                <td>\n                    ");
            EndContext();
            BeginContext(1822, 41, false);
#line 58 "/home/lois/Desktop/ASP.NET Projects/selahseries/SelahSeries/Views/BookMgt/Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Author));

#line default
#line hidden
            EndContext();
            BeginContext(1863, 23, true);
            WriteLiteral("\n                </td>\n");
            EndContext();
#line 60 "/home/lois/Desktop/ASP.NET Projects/selahseries/SelahSeries/Views/BookMgt/Index.cshtml"
                 if (item.CategoryId == 1)
                {

#line default
#line hidden
            BeginContext(1947, 36, true);
            WriteLiteral("                    <td>Sports</td>\n");
            EndContext();
#line 63 "/home/lois/Desktop/ASP.NET Projects/selahseries/SelahSeries/Views/BookMgt/Index.cshtml"
                }
                else if (item.CategoryId == 2)
                {

#line default
#line hidden
            BeginContext(2066, 84, true);
            WriteLiteral("                    <td>\n                        Politics\n                    </td>\n");
            EndContext();
#line 69 "/home/lois/Desktop/ASP.NET Projects/selahseries/SelahSeries/Views/BookMgt/Index.cshtml"
                }
                else if (item.CategoryId == 3)
                {

#line default
#line hidden
            BeginContext(2233, 55, true);
            WriteLiteral("                    <td>Relationship and Marriage</td>\n");
            EndContext();
#line 73 "/home/lois/Desktop/ASP.NET Projects/selahseries/SelahSeries/Views/BookMgt/Index.cshtml"
                }
                else if (item.CategoryId == 4)
                {

#line default
#line hidden
            BeginContext(2371, 36, true);
            WriteLiteral("                    <td>Career</td>\n");
            EndContext();
#line 77 "/home/lois/Desktop/ASP.NET Projects/selahseries/SelahSeries/Views/BookMgt/Index.cshtml"
                }
                else if (item.CategoryId == 5)
                {

#line default
#line hidden
            BeginContext(2490, 37, true);
            WriteLiteral("                    <td>General</td>\n");
            EndContext();
#line 81 "/home/lois/Desktop/ASP.NET Projects/selahseries/SelahSeries/Views/BookMgt/Index.cshtml"
                }
                else
                {

#line default
#line hidden
            BeginContext(2584, 37, true);
            WriteLiteral("                    <td>Unknown</td>\n");
            EndContext();
#line 85 "/home/lois/Desktop/ASP.NET Projects/selahseries/SelahSeries/Views/BookMgt/Index.cshtml"
                }

#line default
#line hidden
            BeginContext(2639, 41, true);
            WriteLiteral("                <td>\n                    ");
            EndContext();
            BeginContext(2681, 43, false);
#line 87 "/home/lois/Desktop/ASP.NET Projects/selahseries/SelahSeries/Views/BookMgt/Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.ImageUrl));

#line default
#line hidden
            EndContext();
            BeginContext(2724, 64, true);
            WriteLiteral("\n                </td>\n                <td>\n                    ");
            EndContext();
            BeginContext(2789, 45, false);
#line 90 "/home/lois/Desktop/ASP.NET Projects/selahseries/SelahSeries/Views/BookMgt/Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.IsHardBook));

#line default
#line hidden
            EndContext();
            BeginContext(2834, 66, true);
            WriteLiteral("\n                </td>\n                <td>\n                    ₦ ");
            EndContext();
            BeginContext(2901, 40, false);
#line 93 "/home/lois/Desktop/ASP.NET Projects/selahseries/SelahSeries/Views/BookMgt/Index.cshtml"
                 Write(Html.DisplayFor(modelItem => item.Price));

#line default
#line hidden
            EndContext();
            BeginContext(2941, 41, true);
            WriteLiteral("\n                </td>\n            </tr>\n");
            EndContext();
#line 96 "/home/lois/Desktop/ASP.NET Projects/selahseries/SelahSeries/Views/BookMgt/Index.cshtml"
        }

#line default
#line hidden
            BeginContext(2992, 173, true);
            WriteLiteral("    </tbody>\n</table>\n\n<div style=\"color: #ffcc00; background-color:black; margin-bottom:0;\" class=\" text-center\">\n    <h1>Selah Series</h1>\n    <p> &copy; 2020</p>\n</div>\n\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<SelahSeries.Models.Book>> Html { get; private set; }
    }
}
#pragma warning restore 1591
