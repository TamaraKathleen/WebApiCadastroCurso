#pragma checksum "/Users/Tamara/Documents/Projetos/WebApiCadastroCurso/Views/Teste/Create.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2ce8511868221ed41b8eccbb2b1d84e71df11f11"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Teste_Create), @"mvc.1.0.view", @"/Views/Teste/Create.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2ce8511868221ed41b8eccbb2b1d84e71df11f11", @"/Views/Teste/Create.cshtml")]
    public class Views_Teste_Create : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebApiCadastroCurso.Models.Course>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "/Users/Tamara/Documents/Projetos/WebApiCadastroCurso/Views/Teste/Create.cshtml"
  
    ViewData["Title"] = "Create";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>Create</h1>

<h4>Course</h4>
<hr />
<div class=""row"">
    <div class=""col-md-4"">
        <form asp-action=""Create"">
            <div asp-validation-summary=""ModelOnly"" class=""text-danger""></div>
            <div class=""form-group"">
                <label asp-for=""Titulo"" class=""control-label""></label>
                <input asp-for=""Titulo"" class=""form-control"" />
                <span asp-validation-for=""Titulo"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <label asp-for=""Duracao"" class=""control-label""></label>
                <input asp-for=""Duracao"" class=""form-control"" />
                <span asp-validation-for=""Duracao"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <label asp-for=""Status"" class=""control-label""></label>
                <input asp-for=""Status"" class=""form-control"" />
                <span asp-validation-for=""Status"" class=""text-danger""></span>
          ");
            WriteLiteral("  </div>\r\n            <div class=\"form-group\">\r\n                <input type=\"submit\" value=\"Create\" class=\"btn btn-primary\" />\r\n            </div>\r\n        </form>\r\n    </div>\r\n</div>\r\n\r\n<div>\r\n    <a asp-action=\"Index\">Back to List</a>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 42 "/Users/Tamara/Documents/Projetos/WebApiCadastroCurso/Views/Teste/Create.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
#nullable disable
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebApiCadastroCurso.Models.Course> Html { get; private set; }
    }
}
#pragma warning restore 1591
