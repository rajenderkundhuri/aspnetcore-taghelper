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
    [HtmlTargetElement("bs-carousel-item")]
    public class CarouselItemTagHelper : TagHelper
    {
        [HtmlAttributeName("active")]
        public bool CarouselItemActive { get; set; }

        [HtmlAttributeName("class")]
        public string CarouselItemClass { get; set; }=  string.Empty;

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.Content.AppendHtml((await output.GetChildContentAsync()).GetContent());
            if (this.CarouselItemActive)
                output.Attributes.SetAttribute("class", ("item active " + this.CarouselItemClass));
            else
                output.Attributes.SetAttribute("class", ("item " + this.CarouselItemClass));

            await base.ProcessAsync(context, output);
        }
    }
}