#pragma checksum "C:\Users\18021826\Desktop\FYP\myNoods2 (2)\myNoods2\Views\Template\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9b220b4d1f7a89f2ac3fd4387e65dc7b9a3476ce"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Template_Index), @"mvc.1.0.view", @"/Views/Template/Index.cshtml")]
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
#line 1 "C:\Users\18021826\Desktop\FYP\myNoods2 (2)\myNoods2\Views\_ViewImports.cshtml"
using System.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\18021826\Desktop\FYP\myNoods2 (2)\myNoods2\Views\_ViewImports.cshtml"
using OnlyPythonFYP.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6ebacb850237230b1712302f9da5770bac974814", @"/Views/Template/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"700859b778482795f1502a6e3d98ae1df827cbff", @"/Views/_ViewImports.cshtml")]
    public class Views_Template_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\18021826\Desktop\FYP\myNoods2 (2)\myNoods2\Views\Template\Index.cshtml"
  
    ViewBag.Title = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>All Questions</h2>\r\n<span style=\"color:red\">");
#nullable restore
#line 8 "C:\Users\18021826\Desktop\FYP\myNoods2 (2)\myNoods2\Views\Template\Index.cshtml"
                   Write(TempData["Msg"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n<table class=\"table table-bordered table-condensed table-hover table-striped\">\r\n    <tr>\r\n        <th scope=\"col\" width=\"5%\">Questions</th>\r\n    </tr>\r\n");
#nullable restore
#line 13 "C:\Users\18037956\Documents\RP Year 3 Sem 2\FYP\myNoods2\Views\Template\Index.cshtml"
     foreach (Qntemplate b in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr scope=\"row\">\r\n            <td width=\"40%\">");
#nullable restore
#line 16 "C:\Users\18037956\Documents\RP Year 3 Sem 2\FYP\myNoods2\Views\Template\Index.cshtml"
                       Write(b.Questions);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        </tr>\r\n");
#nullable restore
#line 18 "C:\Users\18037956\Documents\RP Year 3 Sem 2\FYP\myNoods2\Views\Template\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</table>\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
