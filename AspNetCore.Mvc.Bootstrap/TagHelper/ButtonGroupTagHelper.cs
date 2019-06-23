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
    [HtmlTargetElement("bs-button-group")]
    public class ButtonGroupTagHelper : TagHelper
    {
        [HtmlAttributeName("class")]
        public string ButtonGroupClass { get; set; }=  string.Empty;

        [HtmlAttributeName("orientation")]
        public string ButtonGroupOrientation { get; set; } = "horizontal";

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            string content = (await output.GetChildContentAsync()).GetContent();
            string str = "btn-group";
            if (this.ButtonGroupOrientation == "vertical")
                str = "btn-group-vertical";
            output.Content.AppendHtml(content);
            output.Attributes.SetAttribute("class", (str + " " + this.ButtonGroupClass));
            output.Attributes.SetAttribute("data-toggle", "buttons");
            output.Attributes.SetAttribute("role", "group");

            await base.ProcessAsync(context, output);
        }
    }
}