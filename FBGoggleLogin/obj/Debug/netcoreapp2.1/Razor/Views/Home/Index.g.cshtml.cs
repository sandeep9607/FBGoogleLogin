#pragma checksum "E:\PROJECT\FBGoggleLogin\FBGoggleLogin\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "950299819537edb981f95ba5487c1d7eaa166c69"
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
#line 1 "E:\PROJECT\FBGoggleLogin\FBGoggleLogin\Views\_ViewImports.cshtml"
using FBGoggleLogin;

#line default
#line hidden
#line 2 "E:\PROJECT\FBGoggleLogin\FBGoggleLogin\Views\_ViewImports.cshtml"
using FBGoggleLogin.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"950299819537edb981f95ba5487c1d7eaa166c69", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dbb73910edda8fdff345e581aa6308196e53fb93", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "E:\PROJECT\FBGoggleLogin\FBGoggleLogin\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
            BeginContext(45, 59, true);
            WriteLiteral("<div class=\"jumbotron\">\r\n    <h2>FB and Google Login</h2>\r\n");
            EndContext();
#line 6 "E:\PROJECT\FBGoggleLogin\FBGoggleLogin\Views\Home\Index.cshtml"
     if (User.Identity.IsAuthenticated)
    {

#line default
#line hidden
            BeginContext(152, 17, true);
            WriteLiteral("        <p>Hello ");
            EndContext();
            BeginContext(170, 18, false);
#line 8 "E:\PROJECT\FBGoggleLogin\FBGoggleLogin\Views\Home\Index.cshtml"
            Write(User.Identity.Name);

#line default
#line hidden
            EndContext();
            BeginContext(188, 6, true);
            WriteLiteral("</p>\r\n");
            EndContext();
#line 9 "E:\PROJECT\FBGoggleLogin\FBGoggleLogin\Views\Home\Index.cshtml"
    }
    else
    {

#line default
#line hidden
            BeginContext(218, 68, true);
            WriteLiteral("        <p>Sign-in with one of the available social providers.</p>\r\n");
            EndContext();
#line 13 "E:\PROJECT\FBGoggleLogin\FBGoggleLogin\Views\Home\Index.cshtml"
    }

#line default
#line hidden
            BeginContext(293, 6, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591