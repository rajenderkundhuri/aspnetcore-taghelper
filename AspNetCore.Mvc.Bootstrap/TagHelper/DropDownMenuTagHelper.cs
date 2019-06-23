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
    [HtmlTargetElement("bs-dropdown-menu")]
    public class DropDownMenuTagHelper : TagHelper
    {
        [HtmlAttributeName("labelledby")]
        public string LabelledById { get; set; } = "";

        [HtmlAttributeName("class")]
        public string DropDownMenuClass { get; set; } = "";

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.Content.AppendHtml((await output.GetChildContentAsync()).GetContent());
            output.Attributes.SetAttribute("class", ("dropdown-menu " + this.DropDownMenuClass));
            output.Attributes.SetAttribute("aria-labelledby", this.LabelledById);

            await base.ProcessAsync(context, output);
        }
    }
}