#pragma checksum "C:\Users\HP\Source\Repos\E-Commerce-App\Bazar_App\Bazar_App\Views\Product\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "64a0653e0d02c46412133737cf1577470c00692b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_Details), @"mvc.1.0.view", @"/Views/Product/Details.cshtml")]
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
#line 2 "C:\Users\HP\Source\Repos\E-Commerce-App\Bazar_App\Bazar_App\Views\Product\Details.cshtml"
using Bazar_App.Models.DTO;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"64a0653e0d02c46412133737cf1577470c00692b", @"/Views/Product/Details.cshtml")]
    #nullable restore
    public class Views_Product_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProductDto>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div>\r\n    <h3>");
#nullable restore
#line 6 "C:\Users\HP\Source\Repos\E-Commerce-App\Bazar_App\Bazar_App\Views\Product\Details.cshtml"
   Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>
    <hr />
    <table border=1 class=""table"">
    <thead>
        <tr>
            <th>
                Id
            </th>
            <th>
                Name
            </th>
            <th>
                Price
            </th>
            <th>
                Description
            </th>
            <th>
                CategoryName
            </th>
            <th>
                Photo
            </th>
        </tr>
    </thead>
    <tbody>
     <tr>
            <td>
                ");
#nullable restore
#line 34 "C:\Users\HP\Source\Repos\E-Commerce-App\Bazar_App\Bazar_App\Views\Product\Details.cshtml"
           Write(Html.DisplayFor(modelItem => modelItem.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 37 "C:\Users\HP\Source\Repos\E-Commerce-App\Bazar_App\Bazar_App\Views\Product\Details.cshtml"
           Write(Html.DisplayFor(modelItem => modelItem.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 40 "C:\Users\HP\Source\Repos\E-Commerce-App\Bazar_App\Bazar_App\Views\Product\Details.cshtml"
           Write(Html.DisplayFor(modelItem => modelItem.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 43 "C:\Users\HP\Source\Repos\E-Commerce-App\Bazar_App\Bazar_App\Views\Product\Details.cshtml"
           Write(Html.DisplayFor(modelItem => modelItem.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 46 "C:\Users\HP\Source\Repos\E-Commerce-App\Bazar_App\Bazar_App\Views\Product\Details.cshtml"
           Write(Html.DisplayFor(modelItem => modelItem.CategoryName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                <img");
            BeginWriteAttribute("src", " src=\"", 1186, "\"", 1205, 1);
#nullable restore
#line 49 "C:\Users\HP\Source\Repos\E-Commerce-App\Bazar_App\Bazar_App\Views\Product\Details.cshtml"
WriteAttributeValue("", 1192, Model.ImgUrl, 1192, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"width:80px; height:80px\"/>\r\n            </td>\r\n     </tr>\r\n    </tbody>\r\n</table>\r\n</div>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProductDto> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
