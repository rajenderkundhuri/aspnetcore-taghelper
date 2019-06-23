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
    [HtmlTargetElement("iframe", Attributes = "bs-embed-responsive")]
    [HtmlTargetElement("object", Attributes = "bs-embed-responsive")]
    [HtmlTargetElement("embed", Attributes = "bs-embed-responsive")]
    [HtmlTargetElement("video", Attributes = "bs-embed-responsive")]
    public class EmbedResponsiveTagHelper : TagHelper
    {
        [HtmlAttributeName("bs-embed-responsive")]
        public string embedType { get; set; } = "16by9";

        [HtmlAttributeName("class")]
        public string EmbedClass { get; set; } = "";

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.Content.AppendHtml((await output.GetChildContentAsync()).GetContent());
            output.PreElement.AppendHtml("<bs-embed-responsive class='embed-responsive embed-responsive-" + this.embedType + "'>");
            output.PostElement.AppendHtml("</bs-embed-responsive>");
            output.Attributes.SetAttribute("class", ("embed-responsive-item " + this.EmbedClass));

            await base.ProcessAsync(context, output);
        }
    }
}