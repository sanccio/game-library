#pragma checksum "D:\Programming\Csharp\GameLibrary\Web\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cfb676a92aba16444367e22f9e58c2d493896486"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "D:\Programming\Csharp\GameLibrary\Web\Views\_ViewImports.cshtml"
using Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Programming\Csharp\GameLibrary\Web\Views\_ViewImports.cshtml"
using Web.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Programming\Csharp\GameLibrary\Web\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cfb676a92aba16444367e22f9e58c2d493896486", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"80222651a8e439f0615b550d43d8ad4ddc288500", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Programming\Csharp\GameLibrary\Web\Views\Home\Index.cshtml"
   ViewData["Title"] = "Home Page"; 

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Programming\Csharp\GameLibrary\Web\Views\Home\Index.cshtml"
 if (User.Identity.IsAuthenticated)
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Programming\Csharp\GameLibrary\Web\Views\Home\Index.cshtml"
     if (User.IsInRole("admin"))
    {


#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <!--<div>
            <img src=""https://i.ibb.co/NjzwK78/close-up-of-calendar-on-yellow-background-planning-for-business-meeting-or-travel-planning-concept.jpg"" style=""opacity: 0.5; filter: blur(6px); -moz-opacity: 0.5; filter: alpha(opacity=50) black; -khtml-opacity: 0.5; background-color: #000; left: 0; width:100%; height:100%; top:0; position: absolute;"" />
        </div>
        <br><div style=""margin: 280px 0 0 50px; position:relative; opacity: 0.8; font-family: 'Roboto', sans-serif;"">
            <h1 style=""font-size: 64px;"">CONSULTATION</h1>
            <p style=""font-size:30px;"">
                Convenient and interactive website for creating consultations
            </p>-->
");
            WriteLiteral("        <!--</div>-->\r\n");
#nullable restore
#line 18 "D:\Programming\Csharp\GameLibrary\Web\Views\Home\Index.cshtml"

    }
    else if (User.IsInRole("user"))
    {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 31 "D:\Programming\Csharp\GameLibrary\Web\Views\Home\Index.cshtml"
                
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 32 "D:\Programming\Csharp\GameLibrary\Web\Views\Home\Index.cshtml"
     
}
else
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 36 "D:\Programming\Csharp\GameLibrary\Web\Views\Home\Index.cshtml"
     if (!User.Identity.IsAuthenticated)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <h1>Please, login or register to get started</h1>\r\n");
#nullable restore
#line 39 "D:\Programming\Csharp\GameLibrary\Web\Views\Home\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 39 "D:\Programming\Csharp\GameLibrary\Web\Views\Home\Index.cshtml"
     
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IAuthorizationService AuthorizationService { get; private set; }
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
