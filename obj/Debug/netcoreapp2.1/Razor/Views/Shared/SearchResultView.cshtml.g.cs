#pragma checksum "/home/lois/Desktop/ASP.NET Projects/selahseries/SelahSeries/Views/Shared/SearchResultView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9e84e5f65625425c4b834c5f84eeee20271cbe7f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_SearchResultView), @"mvc.1.0.view", @"/Views/Shared/SearchResultView.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/SearchResultView.cshtml", typeof(AspNetCore.Views_Shared_SearchResultView))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9e84e5f65625425c4b834c5f84eeee20271cbe7f", @"/Views/Shared/SearchResultView.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"84561363502251a09f83bf6d07149c1c007baf6b", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_SearchResultView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SelahSeries.ViewModels.SearchViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/NewFolder2/styles/main_styles.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/NewFolder2/styles/responsive.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("https://unsplash.com/"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "/home/lois/Desktop/ASP.NET Projects/selahseries/SelahSeries/Views/Shared/SearchResultView.cshtml"
  
    ViewData["Title"] = "SearchResultView";

#line default
#line hidden
            DefineSection("AddToHead", async() => {
                BeginContext(115, 5, true);
                WriteLiteral("\n    ");
                EndContext();
                BeginContext(120, 82, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "3a98fa53e0ce46f696849b8f1e0395e6", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(202, 5, true);
                WriteLiteral("\n    ");
                EndContext();
                BeginContext(207, 81, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "b58839a9a2204beab78803d98f98c835", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(288, 1, true);
                WriteLiteral("\n");
                EndContext();
            }
            );
            BeginContext(291, 224, true);
            WriteLiteral("<h2 style=\"text-align:center; color:#ad001c; padding:10px; margin-top:99px\"> Search Result </h2>\n<div class=\"container\">\n    <div class=\"row \">\n        <div class=\"col-lg-2\"> </div>\n        <div class=\" col-sm-12 col-lg-8\">\n");
            EndContext();
#line 14 "/home/lois/Desktop/ASP.NET Projects/selahseries/SelahSeries/Views/Shared/SearchResultView.cshtml"
             if (Model.Posts != null)
            {

#line default
#line hidden
            BeginContext(567, 106, true);
            WriteLiteral("                <div class=\"section_title\">Articles</div>\n                <div class=\"section_content\">\n\n\n");
            EndContext();
#line 20 "/home/lois/Desktop/ASP.NET Projects/selahseries/SelahSeries/Views/Shared/SearchResultView.cshtml"
                     foreach (var item in Model.Posts)
                    {

#line default
#line hidden
            BeginContext(750, 24, true);
            WriteLiteral("                        ");
            EndContext();
            BeginContext(774, 1019, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "91bcaebca8a24fd6a969b7904aefccdc", async() => {
                BeginContext(839, 302, true);
                WriteLiteral(@"
                            <!-- Small Card With Image -->
                            <div class=""searchItem "">
                                <div class=""row search-item"">
                                    <div class=""col-md-4 col-lg-4 search-item-image"">
                                        ");
                EndContext();
                BeginContext(1141, 110, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "e01f72dcd01a4c5cb87cac52976f1aaf", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.SingleQuotes);
                AddHtmlAttributeValue("", 1160, "~/Uploads/", 1160, 10, true);
#line 27 "/home/lois/Desktop/ASP.NET Projects/selahseries/SelahSeries/Views/Shared/SearchResultView.cshtml"
AddHtmlAttributeValue("", 1170, Html.DisplayFor(modelItem => item.TitleImageUrl), 1170, 49, false);

#line default
#line hidden
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1251, 171, true);
                WriteLiteral("\n                                    </div>\n                                    <div class=\"col-md-8 col-lg-8  search-item-title\">\n                                        ");
                EndContext();
                BeginContext(1423, 40, false);
#line 30 "/home/lois/Desktop/ASP.NET Projects/selahseries/SelahSeries/Views/Shared/SearchResultView.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.Title));

#line default
#line hidden
                EndContext();
                BeginContext(1463, 93, true);
                WriteLiteral("\n                                        <br>\n                                        <span> ");
                EndContext();
                BeginContext(1557, 41, false);
#line 32 "/home/lois/Desktop/ASP.NET Projects/selahseries/SelahSeries/Views/Shared/SearchResultView.cshtml"
                                          Write(Html.DisplayFor(modelItem => item.Author));

#line default
#line hidden
                EndContext();
                BeginContext(1598, 1, true);
                WriteLiteral(" ");
                EndContext();
                BeginContext(1600, 45, false);
#line 32 "/home/lois/Desktop/ASP.NET Projects/selahseries/SelahSeries/Views/Shared/SearchResultView.cshtml"
                                                                                     Write(Html.DisplayFor(modelItem => item.ModifiedAt));

#line default
#line hidden
                EndContext();
                BeginContext(1645, 144, true);
                WriteLiteral("\n                                    </div>\n\n                                </div>\n\n                            </div>\n                        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 783, "~/blog/post/", 783, 12, true);
#line 22 "/home/lois/Desktop/ASP.NET Projects/selahseries/SelahSeries/Views/Shared/SearchResultView.cshtml"
AddHtmlAttributeValue("", 795, Html.DisplayFor(modelItem => item.PostId), 795, 42, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1793, 1, true);
            WriteLiteral("\n");
            EndContext();
#line 39 "/home/lois/Desktop/ASP.NET Projects/selahseries/SelahSeries/Views/Shared/SearchResultView.cshtml"

                    }

#line default
#line hidden
            BeginContext(1817, 24, true);
            WriteLiteral("\n                </div>\n");
            EndContext();
#line 43 "/home/lois/Desktop/ASP.NET Projects/selahseries/SelahSeries/Views/Shared/SearchResultView.cshtml"

            }

#line default
#line hidden
            BeginContext(1856, 1, true);
            WriteLiteral("\n");
            EndContext();
#line 46 "/home/lois/Desktop/ASP.NET Projects/selahseries/SelahSeries/Views/Shared/SearchResultView.cshtml"
             if (Model.Books != null)
            {

#line default
#line hidden
            BeginContext(1909, 103, true);
            WriteLiteral("                <div class=\"section_title\">Books</div>\n                <div class=\"section_content\">\n\n\n");
            EndContext();
#line 52 "/home/lois/Desktop/ASP.NET Projects/selahseries/SelahSeries/Views/Shared/SearchResultView.cshtml"
                     foreach (var item in Model.Posts)
                    {

#line default
#line hidden
            BeginContext(2089, 24, true);
            WriteLiteral("                        ");
            EndContext();
            BeginContext(2113, 1019, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0666889408ac4e84bf0a3f84ab162884", async() => {
                BeginContext(2178, 302, true);
                WriteLiteral(@"
                            <!-- Small Card With Image -->
                            <div class=""searchItem "">
                                <div class=""row search-item"">
                                    <div class=""col-md-4 col-lg-4 search-item-image"">
                                        ");
                EndContext();
                BeginContext(2480, 110, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "b6530798935a4490a9433d2b583854f5", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.SingleQuotes);
                AddHtmlAttributeValue("", 2499, "~/Uploads/", 2499, 10, true);
#line 59 "/home/lois/Desktop/ASP.NET Projects/selahseries/SelahSeries/Views/Shared/SearchResultView.cshtml"
AddHtmlAttributeValue("", 2509, Html.DisplayFor(modelItem => item.TitleImageUrl), 2509, 49, false);

#line default
#line hidden
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2590, 171, true);
                WriteLiteral("\n                                    </div>\n                                    <div class=\"col-md-8 col-lg-8  search-item-title\">\n                                        ");
                EndContext();
                BeginContext(2762, 40, false);
#line 62 "/home/lois/Desktop/ASP.NET Projects/selahseries/SelahSeries/Views/Shared/SearchResultView.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.Title));

#line default
#line hidden
                EndContext();
                BeginContext(2802, 93, true);
                WriteLiteral("\n                                        <br>\n                                        <span> ");
                EndContext();
                BeginContext(2896, 41, false);
#line 64 "/home/lois/Desktop/ASP.NET Projects/selahseries/SelahSeries/Views/Shared/SearchResultView.cshtml"
                                          Write(Html.DisplayFor(modelItem => item.Author));

#line default
#line hidden
                EndContext();
                BeginContext(2937, 1, true);
                WriteLiteral(" ");
                EndContext();
                BeginContext(2939, 45, false);
#line 64 "/home/lois/Desktop/ASP.NET Projects/selahseries/SelahSeries/Views/Shared/SearchResultView.cshtml"
                                                                                     Write(Html.DisplayFor(modelItem => item.ModifiedAt));

#line default
#line hidden
                EndContext();
                BeginContext(2984, 144, true);
                WriteLiteral("\n                                    </div>\n\n                                </div>\n\n                            </div>\n                        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 2122, "~/blog/post/", 2122, 12, true);
#line 54 "/home/lois/Desktop/ASP.NET Projects/selahseries/SelahSeries/Views/Shared/SearchResultView.cshtml"
AddHtmlAttributeValue("", 2134, Html.DisplayFor(modelItem => item.PostId), 2134, 42, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3132, 1, true);
            WriteLiteral("\n");
            EndContext();
#line 71 "/home/lois/Desktop/ASP.NET Projects/selahseries/SelahSeries/Views/Shared/SearchResultView.cshtml"

                    }

#line default
#line hidden
            BeginContext(3156, 24, true);
            WriteLiteral("\n                </div>\n");
            EndContext();
#line 75 "/home/lois/Desktop/ASP.NET Projects/selahseries/SelahSeries/Views/Shared/SearchResultView.cshtml"


            }

#line default
#line hidden
            BeginContext(3196, 1961, true);
            WriteLiteral(@"        </div>
        <div class=""col-lg-2""> </div>

    </div>
</div>

<style>
    .row {
        width: 100%;
        max-width: 100%;
    }

    .searchItem {
        margin: 10px;
        width: 100%;
        max-width: 100%;
    }

        .searchItem:hover {
            background-color: rgba(255, 216, 0, 0.1)
        }

    .search-item {
        border-bottom: 1px solid #007bff;
    }

    .search-item-image img {
        max-width: 100%;
    }

    .search-item-title {
        text-align: center;
        font-weight: bold;
        color: black;
    }

        .search-item-title span {
            font-size: small;
            font-weight: normal;
            color: #808080;
            align-items: baseline;
        }

    .search-item-image, .search-item-title {
        padding: 5px;
        display: flex;
        flex-direction: column;
        align-self: center;
    }

    .contain {
        position: relative;
        text-align: center;
    }


    .centered {
        position: absolute;
     ");
            WriteLiteral(@"   top: 50%;
        left: 50%;
        transform: translate(-50%, -50%);
    }

    .text-block {
        background-color: black;
        color: white;
        padding: 40px;
        opacity: 0.8;
        font-size: 40px
    }

    .section_title {
        font-family: 'Ubuntu', sans-serif;
        font-size: 18px;
        font-weight: 700;
        color: #ad001c;
        padding-bottom: 10px;
        white-space: nowrap;
        -webkit-transform: translateY(3px);
        -moz-transform: translateY(3px);
        -ms-transform: translateY(3px);
        -o-transform: translateY(3px);
        transform: translateY(3px);
    }

    .containe {
        background-color: #F2F2F2;
        padding: 62px;
    }

    .books .carousel-inner {
        height: 320px;
    }

    .line-clamp {
        display: -webkit-box;
        -webkit-line-clamp: 2;
        -webkit-box-orient: vertical;
        overflow: no-content;
    }
</style>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SelahSeries.ViewModels.SearchViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591