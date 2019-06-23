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
    [HtmlTargetElement("bs-alert-close")]
    public class AlertCloseTagHelper : TagHelper
    {
        [HtmlAttributeName("class")]
        public string AlertCloseClass { get; set; } = "";

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.Content.AppendHtml((await output.GetChildContentAsync()).GetContent());
            output.Attributes.SetAttribute("type", "button");
            output.Attributes.SetAttribute("class", ("close " + this.AlertCloseClass));
            output.Attributes.SetAttribute("data-dismiss", "alert");
            output.Attributes.SetAttribute("aria-label", "Close");
            await base.ProcessAsync(context, output);
        }
    }
}