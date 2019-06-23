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
    [HtmlTargetElement("bs-carousel-indicator")]
    public class CarouselIndicatorTagHelper : TagHelper
    {
        [HtmlAttributeName("active")]
        public bool CarouselIndicatorActive { get; set; }

        [HtmlAttributeName("class")]
        public string CarouselIndicatorClass { get; set; } = "";

        [HtmlAttributeName("slide-to")]
        public string CarouselIndicatorSlideTo { get; set; } = "0";

        [HtmlAttributeName("target")]
        public string CarouselIndicatorTarget { get; set; } = "";

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.Content.AppendHtml((await output.GetChildContentAsync()).GetContent());
            if (this.CarouselIndicatorActive)
                output.Attributes.SetAttribute("class", (this.CarouselIndicatorClass + " active"));
            else
                output.Attributes.SetAttribute("class", this.CarouselIndicatorClass);
            output.Attributes.SetAttribute("data-slide-to", this.CarouselIndicatorSlideTo);
            output.Attributes.SetAttribute("data-target", this.CarouselIndicatorTarget);

            await base.ProcessAsync(context, output);
        }
    }
}