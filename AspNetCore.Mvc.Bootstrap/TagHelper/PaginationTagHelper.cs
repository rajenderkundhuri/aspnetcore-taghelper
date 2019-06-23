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
    [HtmlTargetElement("bs-pagination")]
    public class PaginationTagHelper : TagHelper
    {
        [HtmlAttributeName("class")]
        public string PaginationClass { get; set; }=  string.Empty;

        [HtmlAttributeName("type")]
        public string PaginationType { get; set; } = "pagination";

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.Content.AppendHtml((await output.GetChildContentAsync()).GetContent());
            output.PreElement.AppendHtml("<bs-pagination-nav>");
            output.PostElement.AppendHtml("</bs-pagination-nav>");
            output.Attributes.SetAttribute("class", (this.PaginationType + " " + this.PaginationClass));

            await base.ProcessAsync(context, output);
        }
    }
}