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
    [HtmlTargetElement("bs-panel-footer")]
    public class PanelFooterTagHelper : TagHelper
    {
        [HtmlAttributeName("class")]
        public string PanelFooterClass { get; set; } = "";

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.Content.AppendHtml((await output.GetChildContentAsync()).GetContent());
            output.Attributes.SetAttribute("class", ("panel-footer " + this.PanelFooterClass));

            await base.ProcessAsync(context, output);
        }
    }
}