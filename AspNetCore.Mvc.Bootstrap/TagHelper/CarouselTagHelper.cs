/**********************************************************************
 * Copyright (c) 2019
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 *
 * ##URL##
 *
**********************************************************************/

using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace AspNetCore.Mvc.Bootstrap.TagHelpers
{
    [HtmlTargetElement("bs-carousel")]
    public class CarouselTagHelper : TagHelper
    {
        [HtmlAttributeName("class")]
        public string CarouselClass { get; set; }=  string.Empty;

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.Content.AppendHtml((await output.GetChildContentAsync()).GetContent());
            output.Attributes.SetAttribute("class", (this.CarouselClass + " carousel"));
            output.Attributes.SetAttribute("data-ride", "carousel");

            await base.ProcessAsync(context, output);
        }
    }
}