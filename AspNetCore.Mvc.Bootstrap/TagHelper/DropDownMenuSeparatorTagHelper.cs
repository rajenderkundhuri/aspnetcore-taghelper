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
    [HtmlTargetElement("bs-dropdown-menu-separator")]
    public class DropDownMenuSeparatorTagHelper : TagHelper
    {
        [HtmlAttributeName("class")]
        public string DropDownSeparatorClass { get; set; } = "divider";

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Content.AppendHtml(string.Format("<div class='{0}'></div>", this.DropDownSeparatorClass));
            output.Attributes.SetAttribute("role", "dropdown-menu");
            output.Attributes.SetAttribute("class", this.DropDownSeparatorClass);
            base.Process(context, output);
        }
    }
}