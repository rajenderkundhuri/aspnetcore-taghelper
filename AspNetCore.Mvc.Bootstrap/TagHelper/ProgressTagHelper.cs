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
    [HtmlTargetElement("bs-progress")]
    public class ProgressTagHelper : TagHelper
    {
        [HtmlAttributeName("class")]
        public string ProgressClass { get; set; }=  string.Empty;

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            (await output.GetChildContentAsync()).GetContent();
            output.Attributes.SetAttribute("class", ("progress " + this.ProgressClass));

            await base.ProcessAsync(context, output);
        }
    }
}