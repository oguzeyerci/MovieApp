#pragma checksum "C:\Users\oguze\Desktop\filmapp\filmapp.webui\Views\Admin\MovieList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "61e60c1b44ba428498c7797e0f268355f229d71b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_MovieList), @"mvc.1.0.view", @"/Views/Admin/MovieList.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 3 "C:\Users\oguze\Desktop\filmapp\filmapp.webui\Views\_ViewImports.cshtml"
using filmapp.entity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"61e60c1b44ba428498c7797e0f268355f229d71b", @"/Views/Admin/MovieList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fec9706ebc5bbd81dbd28f21ab53eba3ade9504f", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_MovieList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Movie>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("80"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-sm btn-outline-secondary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("~/admin/delete"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "POST", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("display:inline;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\oguze\Desktop\filmapp\filmapp.webui\Views\Admin\MovieList.cshtml"
 if(TempData["message"]!=null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <script >\r\n    alertify.alert(\'Movie App\',\'");
#nullable restore
#line 6 "C:\Users\oguze\Desktop\filmapp\filmapp.webui\Views\Admin\MovieList.cshtml"
                           Write(TempData["message"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\');\r\n    </script>\r\n");
#nullable restore
#line 8 "C:\Users\oguze\Desktop\filmapp\filmapp.webui\Views\Admin\MovieList.cshtml"

}

#line default
#line hidden
#nullable disable
            DefineSection("Css", async() => {
                WriteLiteral("\r\n    \r\n    <link rel=\"stylesheet\" href=\"https://cdn.datatables.net/1.10.21/css/dataTables.bootstrap4.min.css\">\r\n");
            }
            );
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script src=""//cdn.datatables.net/1.10.21/js/jquery.dataTables.min.js""></script>
    <script src=""https://cdn.datatables.net/1.10.21/js/dataTables.bootstrap4.min.js""></script>
    <script>
        $(document).ready( function () {
        $('#myTable').DataTable();
        });
    </script>
");
            }
            );
            WriteLiteral(@"

    <h1 class=""text-white"">Admin Listesi</h1>
    <hr>
    <table id=""myTable"" class=""table text-white"">
        <thead class=""thead-dark"">
            <tr>
            <th scope=""col"">#</th>
            <th scope=""col"">Resim</th>
            <th scope=""col"">Film Adı</th>
            <th scope=""col"">Kategori</th>            
            <th scope=""col"">Oyuncular</th>
            <th scope=""col"">Yönetmen</th>
            <th scope=""col"">İnceleme</th>
            <th style=""width: 130px;"" scope=""col""></th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 43 "C:\Users\oguze\Desktop\filmapp\filmapp.webui\Views\Admin\MovieList.cshtml"
             if(Model.Count>0){
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 44 "C:\Users\oguze\Desktop\filmapp\filmapp.webui\Views\Admin\MovieList.cshtml"
                 foreach(var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr style=\"text-align: center;\r\n                       vertical-align: middle;\">\r\n                <th scope=\"row\">");
#nullable restore
#line 48 "C:\Users\oguze\Desktop\filmapp\filmapp.webui\Views\Admin\MovieList.cshtml"
                           Write(item.MovieId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                <td>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "61e60c1b44ba428498c7797e0f268355f229d71b7765", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1456, "~/images/", 1456, 9, true);
#nullable restore
#line 49 "C:\Users\oguze\Desktop\filmapp\filmapp.webui\Views\Admin\MovieList.cshtml"
AddHtmlAttributeValue("", 1465, item.ImageUrl, 1465, 14, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 50 "C:\Users\oguze\Desktop\filmapp\filmapp.webui\Views\Admin\MovieList.cshtml"
               Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 51 "C:\Users\oguze\Desktop\filmapp\filmapp.webui\Views\Admin\MovieList.cshtml"
               Write(item.Category);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td> \r\n                <td>");
#nullable restore
#line 52 "C:\Users\oguze\Desktop\filmapp\filmapp.webui\Views\Admin\MovieList.cshtml"
               Write(item.Stars);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 53 "C:\Users\oguze\Desktop\filmapp\filmapp.webui\Views\Admin\MovieList.cshtml"
               Write(item.Director);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>  \r\n");
#nullable restore
#line 54 "C:\Users\oguze\Desktop\filmapp\filmapp.webui\Views\Admin\MovieList.cshtml"
                 if(item.Review.Length>100)
                {         

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td>");
#nullable restore
#line 56 "C:\Users\oguze\Desktop\filmapp\filmapp.webui\Views\Admin\MovieList.cshtml"
               Write(Html.Raw(item.Review.Substring(0,100)+"..."));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 57 "C:\Users\oguze\Desktop\filmapp\filmapp.webui\Views\Admin\MovieList.cshtml"
                }         
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td>");
#nullable restore
#line 60 "C:\Users\oguze\Desktop\filmapp\filmapp.webui\Views\Admin\MovieList.cshtml"
               Write(Html.Raw(item.Review));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 61 "C:\Users\oguze\Desktop\filmapp\filmapp.webui\Views\Admin\MovieList.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td>\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "61e60c1b44ba428498c7797e0f268355f229d71b11646", async() => {
                WriteLiteral("Edit");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1993, "~/admin/Edit/", 1993, 13, true);
#nullable restore
#line 63 "C:\Users\oguze\Desktop\filmapp\filmapp.webui\Views\Admin\MovieList.cshtml"
AddHtmlAttributeValue("", 2006, item.MovieId, 2006, 13, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "61e60c1b44ba428498c7797e0f268355f229d71b13274", async() => {
                WriteLiteral("\r\n                    <input type=\"hidden\" name=\"movieId\"");
                BeginWriteAttribute("value", " value=\"", 2217, "\"", 2238, 1);
#nullable restore
#line 65 "C:\Users\oguze\Desktop\filmapp\filmapp.webui\Views\Admin\MovieList.cshtml"
WriteAttributeValue("", 2225, item.MovieId, 2225, 13, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                    <button type=\"submit\" class=\"btn btn-sm btn-outline-danger\">Delete</button>\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 70 "C:\Users\oguze\Desktop\filmapp\filmapp.webui\Views\Admin\MovieList.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 70 "C:\Users\oguze\Desktop\filmapp\filmapp.webui\Views\Admin\MovieList.cshtml"
                  
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("            e\r\n                   \r\n        </tbody>\r\n    </table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Movie>> Html { get; private set; }
    }
}
#pragma warning restore 1591
