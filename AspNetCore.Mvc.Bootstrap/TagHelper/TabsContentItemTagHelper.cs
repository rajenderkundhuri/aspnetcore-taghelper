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
    [HtmlTargetElement("bs-tab-pane")]
    public class TabsContentItemTagHelper : TagHelper
    {
        [HtmlAttributeName("active")]
        public bool Active { get; set; }

        [HtmlAttributeName("class")]
        public string Class { get; set; } = "";

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            string tabPaneClass = "tab-pane";
            output.Content.AppendHtml((await output.GetChildContentAsync()).GetContent());
            output.Attributes.SetAttribute("role", "tabpanel");
            if (this.Class.Length > 0)
                tabPaneClass = tabPaneClass + " " + this.Class;
            if (this.Active)
                tabPaneClass += " active";
            output.Attributes.SetAttribute("class", tabPaneClass);

            await base.ProcessAsync(context, output);
        }
    }
}