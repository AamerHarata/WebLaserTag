#pragma checksum "D:\GitFolders\Programming\Twente\FinalProjcet\WebLaserTag\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8e273ce129affb61a13a49d443919d7ebc35709b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
#line 1 "D:\GitFolders\Programming\Twente\FinalProjcet\WebLaserTag\Views\_ViewImports.cshtml"
using WebLaserTag;

#line default
#line hidden
#line 2 "D:\GitFolders\Programming\Twente\FinalProjcet\WebLaserTag\Views\_ViewImports.cshtml"
using WebLaserTag.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8e273ce129affb61a13a49d443919d7ebc35709b", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"488dabd58696d28c67ef0522b0dd51193e755856", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "D:\GitFolders\Programming\Twente\FinalProjcet\WebLaserTag\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
            BeginContext(47, 349, true);
            WriteLiteral(@"
<div class=""text-center"">
    <h1 class=""display-4"">Welcome to Laser Tag Web server</h1>
    <p><a href=""#"">UT - Group 2 - Final Project</a>.</p>
    <div class=""display-4"" style=""color: gray; font-size: 2.5rem""><p>The server is ready to receive data</p></div>
</div>
<hr/>
<div class=""text-center""><button class=""text-center btn btn-danger""");
            EndContext();
            BeginWriteAttribute("onclick", "onclick=\"", 396, "\"", 456, 5);
            WriteAttributeValue("", 405, "location.href", 405, 13, true);
            WriteAttributeValue(" ", 418, "=", 419, 2, true);
            WriteAttributeValue(" ", 420, "\'", 421, 2, true);
#line 12 "D:\GitFolders\Programming\Twente\FinalProjcet\WebLaserTag\Views\Home\Index.cshtml"
WriteAttributeValue("", 422, Url.Action("DeleteData", "Home"), 422, 33, false);

#line default
#line hidden
            WriteAttributeValue("", 455, "\'", 455, 1, true);
            EndWriteAttribute();
            BeginContext(457, 113, true);
            WriteLiteral(">Delete Everything</button></div>\r\n<br/>\r\n<div class=\"text-center\" id=\"data-container\">\r\n    \r\n</div>\r\n\r\n\r\n\r\n\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(589, 517, true);
                WriteLiteral(@"
    <script>
        $(document).ready(function() {
            
            const gameId = $(""#gameId"").val();

            setInterval(function() { getData() }, 300);


            function getData() {
                $.ajax({
                    type: ""GET"",
                    url: ""/LiveGame/"",
                    success: function(response) {
                        $(""#data-container"").html(response);
                    }
                });
            }

        });
    </script>
");
                EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
