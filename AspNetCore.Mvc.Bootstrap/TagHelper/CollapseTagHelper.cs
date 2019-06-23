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
    [HtmlTargetElement("bs-collapse")]
    public class CollapseTagHelper : TagHelper
    {
        [HtmlAttributeName("trigger")]
        public string CollapseTrigger { get; set; } = "";

        [HtmlAttributeName("id")]
        public string CollapseId { get; set; } = "";

        [HtmlAttributeName("class")]
        public string CollapseClass { get; set; } = "";

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            (await output.GetChildContentAsync()).GetContent();
            output.PostContent.AppendHtml("<script>$(function() { $('" + this.CollapseTrigger + "').on('click', function () { $('#" + this.CollapseId + "').collapse('toggle'); }); });</script>");
            output.Attributes.SetAttribute("class", ("collapse " + this.CollapseClass));
            output.Attributes.SetAttribute("id", this.CollapseId);

            await base.ProcessAsync(context, output);
        }
    }
}