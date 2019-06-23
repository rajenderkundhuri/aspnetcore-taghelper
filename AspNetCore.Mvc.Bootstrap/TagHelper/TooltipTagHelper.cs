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
    [HtmlTargetElement("div", Attributes = "bs-tooltip")]
    [HtmlTargetElement("img", Attributes = "bs-tooltip")]
    [HtmlTargetElement("span", Attributes = "bs-tooltip")]
    [HtmlTargetElement("nav", Attributes = "bs-tooltip")]
    [HtmlTargetElement("button", Attributes = "bs-tooltip")]
    [HtmlTargetElement("a", Attributes = "bs-tooltip")]
    [HtmlTargetElement("p", Attributes = "bs-tooltip")]
    [HtmlTargetElement("h1", Attributes = "bs-tooltip")]
    [HtmlTargetElement("h2", Attributes = "bs-tooltip")]
    [HtmlTargetElement("h3", Attributes = "bs-tooltip")]
    [HtmlTargetElement("h4", Attributes = "bs-tooltip")]
    [HtmlTargetElement("h5", Attributes = "bs-tooltip")]
    [HtmlTargetElement("h6", Attributes = "bs-tooltip")]
    [HtmlTargetElement("bs-button", Attributes = "bs-tooltip")]
    public class TooltipTagHelper : TagHelper
    {
        [HtmlAttributeName("bs-tooltip-toggle")]
        public string TooltipToggle { get; set; } = "";

        [HtmlAttributeName("bs-tooltip")]
        public string TooltipTitle { get; set; } = "";

        [HtmlAttributeName("static")]
        public bool TooltipStatic { get; set; }

        [HtmlAttributeName("placement")]
        public string TooltipPlacement { get; set; } = "left";

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            string content = (await output.GetChildContentAsync()).GetContent();
            if (!this.TooltipStatic)
            {
                if (this.TooltipToggle == "")
                    this.TooltipToggle = this.TooltipTitle;
                if (this.TooltipTitle != "")
                {
                    output.PostElement.AppendHtml("<script>$(function() {$('[data-toggle=\"" + this.TooltipToggle + "\"]').tooltip();});</script>");
                    output.Attributes.SetAttribute("title", this.TooltipTitle);
                }
                output.Attributes.SetAttribute("data-toggle", this.TooltipToggle);
            }
            else
                output.Content.AppendHtml($"<div class=\"tooltip fade { this.TooltipPlacement}  in static\" style=\"z-index:0;\" role=\"tooltip\"><div class=\"tooltip-arrow\"></div><div class=\"tooltip-inner\">{ content}</div></div>");

            await base.ProcessAsync(context, output);
        }
    }
}