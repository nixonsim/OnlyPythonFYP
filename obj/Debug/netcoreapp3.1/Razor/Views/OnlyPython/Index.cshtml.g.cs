#pragma checksum "C:\Users\18021826\Desktop\FYP\myNoods2 (2)\myNoods2\Views\OnlyPython\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3a9108af4361a6f026e4922a18f93c9c2d901e68"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_OnlyPython_Index), @"mvc.1.0.view", @"/Views/OnlyPython/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ac9e5af40ae47b8d7aaae8487cb7227d86353340", @"/Views/OnlyPython/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"700859b778482795f1502a6e3d98ae1df827cbff", @"/Views/_ViewImports.cshtml")]
    public class Views_OnlyPython_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\18021826\Desktop\FYP\myNoods2 (2)\myNoods2\Views\OnlyPython\Index.cshtml"
  
    ViewBag.Title = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<span style=\"color:red\">");
#nullable restore
#line 7 "C:\Users\18021826\Desktop\FYP\myNoods2 (2)\myNoods2\Views\OnlyPython\Index.cshtml"
                   Write(TempData["Msg"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
<table class=""table table-bordered table-condensed table-hover table-striped"">
    <tr>
        <th scope=""col"" width=""75%"">Message of the day</th>

    </tr>
    <tr scope=""row"">
        <td width=""75%"">Welcome to OnlyPython</td>

    </tr>
</table>

<h2>All Questions</h2>
<span style=""color:red"">");
#nullable restore
#line 20 "C:\Users\18021826\Desktop\FYP\myNoods2 (2)\myNoods2\Views\OnlyPython\Index.cshtml"
                   Write(TempData["Msg"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
<table class=""table table-bordered table-condensed table-hover table-striped"">
    <tr>
        <th scope=""col"" width=""20%"">Question ID</th>
        <th scope=""col"" width=""20%"">Question</th>
        <th scope=""col"" width=""20%"">QuestionType</th>
        <th scope=""col"" wifth=""20%"">Topic</th>
    </tr>
");
#nullable restore
#line 27 "C:\Users\18037956\Documents\RP Year 3 Sem 2\FYP\myNoods2\Views\OnlyPython\Index.cshtml"
     foreach (Qnsbank b in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr scope=\"row\">\r\n            <td width=\"20%\">");
#nullable restore
#line 30 "C:\Users\18037956\Documents\RP Year 3 Sem 2\FYP\myNoods2\Views\OnlyPython\Index.cshtml"
                       Write(b.QnsId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td width=\"40%\">");
#nullable restore
#line 31 "C:\Users\18037956\Documents\RP Year 3 Sem 2\FYP\myNoods2\Views\OnlyPython\Index.cshtml"
                       Write(b.Question);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td width=\"40%\">");
#nullable restore
#line 32 "C:\Users\18037956\Documents\RP Year 3 Sem 2\FYP\myNoods2\Views\OnlyPython\Index.cshtml"
                       Write(b.QuestionType);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        </tr>\r\n");
#nullable restore
#line 34 "C:\Users\18037956\Documents\RP Year 3 Sem 2\FYP\myNoods2\Views\OnlyPython\Index.cshtml"
    }

");
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
