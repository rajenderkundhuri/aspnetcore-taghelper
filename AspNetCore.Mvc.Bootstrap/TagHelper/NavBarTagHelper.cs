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
    [HtmlTargetElement("bs-nav-bar")]
    public class NavBarTagHelper : TagHelper
    {
        [HtmlAttributeName("class")]
        public string NavBarClass { get; set; } = "";

        [HtmlAttributeName("container")]
        public string NavBarContainer { get; set; } = "container";

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            string content = (await output.GetChildContentAsync()).GetContent();
            string str = "navbar";
            output.Content.AppendHtml("<div class='" + this.NavBarContainer + "'>" + content + "</div>");
            if (this.NavBarClass.Length > 0)
                output.Attributes.SetAttribute("class", (str + " " + this.NavBarClass));
            else
                output.Attributes.SetAttribute("class", (str + " navbar navbar-default"));

            await base.ProcessAsync(context, output);
        }
    }
}