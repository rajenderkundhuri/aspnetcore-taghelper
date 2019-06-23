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
    [HtmlTargetElement("bs-thumbnail")]
    public class ThumbnailTagHelper : TagHelper
    {
        [HtmlAttributeName("class")]
        public string ThumbnailClass { get; set; }=  string.Empty;

        [HtmlAttributeName("href")]
        public string ThumbnailHref { get; set; }=  string.Empty;

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.Content.AppendHtml((await output.GetChildContentAsync()).GetContent());
            output.Attributes.SetAttribute("class", ("thumbnail " + this.ThumbnailClass));
            if (this.ThumbnailHref.Length > 0)
            {
                output.TagName = "a";
                output.Attributes.SetAttribute("href", this.ThumbnailHref);
            }

            await base.ProcessAsync(context, output);
        }
    }
}