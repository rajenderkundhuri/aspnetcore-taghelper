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
    [HtmlTargetElement("bs-tab")]
    public class TabsNavItemTagHelper : TagHelper
    {
        [HtmlAttributeName("active")]
        public bool Active { get; set; }

        [HtmlAttributeName("class")]
        public string TabClass { get; set; }=  string.Empty;

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.Content.AppendHtml((await output.GetChildContentAsync()).GetContent());
            output.Attributes.SetAttribute("role", "presentation");
            if (this.Active)
                output.Attributes.SetAttribute("class", ("active " + this.TabClass));
            else
                output.Attributes.SetAttribute("class", this.TabClass);

            await base.ProcessAsync(context, output);
        }
    }
}