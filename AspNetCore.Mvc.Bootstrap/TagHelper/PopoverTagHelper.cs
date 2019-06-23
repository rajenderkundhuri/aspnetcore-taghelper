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
    [HtmlTargetElement("div", Attributes = "bs-popover")]
    [HtmlTargetElement("img", Attributes = "bs-popover")]
    [HtmlTargetElement("span", Attributes = "bs-popover")]
    [HtmlTargetElement("nav", Attributes = "bs-popover")]
    [HtmlTargetElement("button", Attributes = "bs-popover")]
    [HtmlTargetElement("a", Attributes = "bs-popover")]
    [HtmlTargetElement("p", Attributes = "bs-popover")]
    [HtmlTargetElement("h1", Attributes = "bs-popover")]
    [HtmlTargetElement("h2", Attributes = "bs-popover")]
    [HtmlTargetElement("h3", Attributes = "bs-popover")]
    [HtmlTargetElement("h4", Attributes = "bs-popover")]
    [HtmlTargetElement("h5", Attributes = "bs-popover")]
    [HtmlTargetElement("h6", Attributes = "bs-popover")]
    [HtmlTargetElement("bs-button", Attributes = "bs-popover")]
    public class PopoverTagHelper : TagHelper
    {
        [HtmlAttributeName("bs-popover")]
        public string PopoverTitle { get; set; }=  string.Empty;

        [HtmlAttributeName("id")]
        public string PopoverId { get; set; }=  string.Empty;

        [HtmlAttributeName("static")]
        public bool PopoverStatic { get; set; }

        [HtmlAttributeName("placement")]
        public string PopoverPlacement { get; set; }=  string.Empty;

        [HtmlAttributeName("title")]
        public string PopoverTitle1 { get; set; }=  string.Empty;

        [HtmlAttributeName("content")]
        public string PopoverContent { get; set; }=  string.Empty;

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            (await output.GetChildContentAsync()).GetContent();
            if (!this.PopoverStatic)
            {
                if (this.PopoverTitle != "")
                    output.PostElement.AppendHtml("<script>$(function() {$('#" + this.PopoverId + "').popover();});</script>");
                output.Attributes.SetAttribute("data-toggle", "popover");
                output.Attributes.SetAttribute("title", this.PopoverTitle1);
                output.Attributes.SetAttribute("id", this.PopoverId);
            }
            else
            {
                output.Content.AppendHtml("<div class='arrow'></div> <h3 class='popover-title'>" + this.PopoverTitle1 + "</h3><div class='popover-content'><p>" + this.PopoverContent + "</p></div>");
                output.Attributes.SetAttribute("class", ("popover static " + this.PopoverPlacement));
                output.Attributes.SetAttribute("id", this.PopoverId);
            }

            await base.ProcessAsync(context, output);
        }
    }
}