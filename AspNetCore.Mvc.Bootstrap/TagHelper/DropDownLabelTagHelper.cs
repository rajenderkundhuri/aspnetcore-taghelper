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

namespace AspNetCore.Mvc.Bootstrap.TagHelpers
{
    [HtmlTargetElement("bs-dropdown-label")]
    public class DropDownLabelTagHelper : TagHelper
    {
        [HtmlAttributeName("id")]
        public string DropDownLabelId { get; set; }=  string.Empty;

        [HtmlAttributeName("type")]
        public string DropDownLabelType { get; set; } = "button";

        [HtmlAttributeName("class")]
        public string DropDownLabelClass { get; set; }=  string.Empty;

        [HtmlAttributeName("content")]
        public string DropDownLabelContent { get; set; }=  string.Empty;

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string encoded = this.DropDownLabelContent + "<span class='caret'></span>";
            output.Content.AppendHtml(encoded);
            output.Attributes.SetAttribute("id", this.DropDownLabelId);
            output.Attributes.SetAttribute("class", this.DropDownLabelClass);
            output.Attributes.SetAttribute("type", "button");
            output.Attributes.SetAttribute("data-toggle", "dropdown");
            output.Attributes.SetAttribute("aria-haspopup", "true");
            output.Attributes.SetAttribute("aria-expanded", "true");
            base.Process(context, output);
        }
    }
}