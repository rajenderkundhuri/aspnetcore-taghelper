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
    [HtmlTargetElement("bs-carousel-control")]
    public class CarouselControlTagHelper : TagHelper
    {
        [HtmlAttributeName("type")]
        public string CollapseCarouselType { get; set; } = "right";

        [HtmlAttributeName("slide")]
        public string CollapseCarouselSlide { get; set; } = "next";

        [HtmlAttributeName("class")]
        public string CarouselControlClass { get; set; }=  string.Empty;

        [HtmlAttributeName("target")]
        public string CollapseCarouselTarget { get; set; }=  string.Empty;

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.Content.AppendHtml((await output.GetChildContentAsync()).GetContent());
            output.Attributes.SetAttribute("class", (this.CollapseCarouselType + " carousel-control " + this.CarouselControlClass));
            output.Attributes.SetAttribute("href", this.CollapseCarouselTarget);
            output.Attributes.SetAttribute("role", "button");
            output.Attributes.SetAttribute("data-slide", this.CollapseCarouselSlide);

            await base.ProcessAsync(context, output);
        }
    }
}