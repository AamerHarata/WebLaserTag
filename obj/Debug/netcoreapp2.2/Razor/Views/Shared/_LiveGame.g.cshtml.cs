#pragma checksum "D:\GitFolders\Programming\Twente\FinalProjcet\WebLaserTag\Views\Shared\_LiveGame.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "29cb125ac908a16073f8eafcf3553c4b87b81d24"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__LiveGame), @"mvc.1.0.view", @"/Views/Shared/_LiveGame.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_LiveGame.cshtml", typeof(AspNetCore.Views_Shared__LiveGame))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"29cb125ac908a16073f8eafcf3553c4b87b81d24", @"/Views/Shared/_LiveGame.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"488dabd58696d28c67ef0522b0dd51193e755856", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__LiveGame : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Game>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(26, 29, true);
            WriteLiteral("\r\n<div class=\"text-center\">\r\n");
            EndContext();
#line 4 "D:\GitFolders\Programming\Twente\FinalProjcet\WebLaserTag\Views\Shared\_LiveGame.cshtml"
     if (!Model.Any())
    {
        

#line default
#line hidden
            BeginContext(96, 225, true);
            WriteLiteral("        <div class=\"text-center\">\r\n            <p class=\"display-4\" style=\"color: gray; font-size: 2.5rem;\">No games yet! Please open the app, create one on your phone! And invite your friends to join ..</p>\r\n        </div>\r\n");
            EndContext();
#line 10 "D:\GitFolders\Programming\Twente\FinalProjcet\WebLaserTag\Views\Shared\_LiveGame.cshtml"
    }
    else
    {

#line default
#line hidden
            BeginContext(345, 84, true);
            WriteLiteral("        <table class=\"table table-striped\">\r\n            <thead>\r\n            <tr>\r\n");
            EndContext();
            BeginContext(512, 478, true);
            WriteLiteral(@"                <th>#</th>
                <th>Short Id</th>
                <th>Host</th>
                <th>Start X</th>
                <th>Start Y</th>
                <th>Flag X</th>
                <th>Flag Y</th>
                <th>Flag Holder</th>
                <th>Status</th>
                <th>Password</th>
                <th>Players</th>
                <th>Live Data</th>
                <th>Delete</th>
            </tr>
            </thead>
");
            EndContext();
#line 32 "D:\GitFolders\Programming\Twente\FinalProjcet\WebLaserTag\Views\Shared\_LiveGame.cshtml"
               var i = 1;

#line default
#line hidden
            BeginContext(1018, 12, true);
            WriteLiteral("            ");
            EndContext();
#line 33 "D:\GitFolders\Programming\Twente\FinalProjcet\WebLaserTag\Views\Shared\_LiveGame.cshtml"
             foreach (var game in Model)
            {

#line default
#line hidden
            BeginContext(1075, 46, true);
            WriteLiteral("                <tr>\r\n                    <td>");
            EndContext();
            BeginContext(1122, 1, false);
#line 36 "D:\GitFolders\Programming\Twente\FinalProjcet\WebLaserTag\Views\Shared\_LiveGame.cshtml"
                   Write(i);

#line default
#line hidden
            EndContext();
            BeginContext(1123, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(1155, 21, false);
#line 37 "D:\GitFolders\Programming\Twente\FinalProjcet\WebLaserTag\Views\Shared\_LiveGame.cshtml"
                   Write(game.Id.Split("-")[0]);

#line default
#line hidden
            EndContext();
            BeginContext(1176, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(1208, 13, false);
#line 38 "D:\GitFolders\Programming\Twente\FinalProjcet\WebLaserTag\Views\Shared\_LiveGame.cshtml"
                   Write(game.HostName);

#line default
#line hidden
            EndContext();
            BeginContext(1221, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(1253, 11, false);
#line 39 "D:\GitFolders\Programming\Twente\FinalProjcet\WebLaserTag\Views\Shared\_LiveGame.cshtml"
                   Write(game.StartX);

#line default
#line hidden
            EndContext();
            BeginContext(1264, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(1296, 11, false);
#line 40 "D:\GitFolders\Programming\Twente\FinalProjcet\WebLaserTag\Views\Shared\_LiveGame.cshtml"
                   Write(game.StartY);

#line default
#line hidden
            EndContext();
            BeginContext(1307, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(1339, 10, false);
#line 41 "D:\GitFolders\Programming\Twente\FinalProjcet\WebLaserTag\Views\Shared\_LiveGame.cshtml"
                   Write(game.FlagX);

#line default
#line hidden
            EndContext();
            BeginContext(1349, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(1381, 10, false);
#line 42 "D:\GitFolders\Programming\Twente\FinalProjcet\WebLaserTag\Views\Shared\_LiveGame.cshtml"
                   Write(game.FlagY);

#line default
#line hidden
            EndContext();
            BeginContext(1391, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(1423, 15, false);
#line 43 "D:\GitFolders\Programming\Twente\FinalProjcet\WebLaserTag\Views\Shared\_LiveGame.cshtml"
                   Write(game.FlagHolder);

#line default
#line hidden
            EndContext();
            BeginContext(1438, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
#line 44 "D:\GitFolders\Programming\Twente\FinalProjcet\WebLaserTag\Views\Shared\_LiveGame.cshtml"
                         if(game.Ended){

#line default
#line hidden
            BeginContext(1485, 18, true);
            WriteLiteral("<span>Ended</span>");
            EndContext();
#line 44 "D:\GitFolders\Programming\Twente\FinalProjcet\WebLaserTag\Views\Shared\_LiveGame.cshtml"
                                                          }else{

#line default
#line hidden
            BeginContext(1509, 24, true);
            WriteLiteral("<span>In Progress</span>");
            EndContext();
#line 44 "D:\GitFolders\Programming\Twente\FinalProjcet\WebLaserTag\Views\Shared\_LiveGame.cshtml"
                                                                                        }

#line default
#line hidden
            BeginContext(1534, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(1566, 13, false);
#line 45 "D:\GitFolders\Programming\Twente\FinalProjcet\WebLaserTag\Views\Shared\_LiveGame.cshtml"
                   Write(game.Password);

#line default
#line hidden
            EndContext();
            BeginContext(1579, 59, true);
            WriteLiteral("</td>\r\n                    <td><button class=\"btn btn-info\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 1638, "\"", 1692, 3);
            WriteAttributeValue("", 1648, "window.open(\'/home/players?gameId=", 1648, 34, true);
#line 46 "D:\GitFolders\Programming\Twente\FinalProjcet\WebLaserTag\Views\Shared\_LiveGame.cshtml"
WriteAttributeValue("", 1682, game.Id, 1682, 8, false);

#line default
#line hidden
            WriteAttributeValue("", 1690, "\')", 1690, 2, true);
            EndWriteAttribute();
            BeginContext(1693, 76, true);
            WriteLiteral(">Players</button></td>\r\n                    <td><button class=\"btn btn-dark\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 1769, "\"", 1826, 3);
            WriteAttributeValue("", 1779, "window.open(\'/home/PlayerData?gameId=", 1779, 37, true);
#line 47 "D:\GitFolders\Programming\Twente\FinalProjcet\WebLaserTag\Views\Shared\_LiveGame.cshtml"
WriteAttributeValue("", 1816, game.Id, 1816, 8, false);

#line default
#line hidden
            WriteAttributeValue("", 1824, "\')", 1824, 2, true);
            EndWriteAttribute();
            BeginContext(1827, 80, true);
            WriteLiteral(">Live Data</button></td>\r\n                    <td><button class=\"btn btn-danger\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 1907, "\"", 1991, 5);
            WriteAttributeValue("", 1917, "location.href", 1917, 13, true);
            WriteAttributeValue(" ", 1930, "=", 1931, 2, true);
            WriteAttributeValue(" ", 1932, "\'", 1933, 2, true);
#line 48 "D:\GitFolders\Programming\Twente\FinalProjcet\WebLaserTag\Views\Shared\_LiveGame.cshtml"
WriteAttributeValue("", 1934, Url.Action("DeleteGame", "Home", new{gameId = game.Id}), 1934, 56, false);

#line default
#line hidden
            WriteAttributeValue("", 1990, "\'", 1990, 1, true);
            EndWriteAttribute();
            BeginContext(1992, 46, true);
            WriteLiteral(">Delete</button></td>\r\n                </tr>\r\n");
            EndContext();
#line 50 "D:\GitFolders\Programming\Twente\FinalProjcet\WebLaserTag\Views\Shared\_LiveGame.cshtml"
                i++;
            }

#line default
#line hidden
            BeginContext(2075, 32, true);
            WriteLiteral("            \r\n        </table>\r\n");
            EndContext();
#line 54 "D:\GitFolders\Programming\Twente\FinalProjcet\WebLaserTag\Views\Shared\_LiveGame.cshtml"
    }

#line default
#line hidden
            BeginContext(2114, 6, true);
            WriteLiteral("</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Game>> Html { get; private set; }
    }
}
#pragma warning restore 1591
