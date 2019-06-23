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
    [HtmlTargetElement("bs-listgroup-item")]
    public class ListgroupItemTagHelper : TagHelper
    {
        [HtmlAttributeName("class")]
        public string ListGroupItemClass { get; set; }=  string.Empty;

        [HtmlAttributeName("type")]
        public string ItemType { get; set; }=  string.Empty;

        [HtmlAttributeName("href")]
        public string ItemHref { get; set; }=  string.Empty;

        [HtmlAttributeName("class")]
        public string ItemTarget { get; set; } = "_self";

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            string content = (await output.GetChildContentAsync()).GetContent();
            if (this.ItemType == "button")
                output.Content.AppendHtml("<button type=\"button\" class=\"list-group-item\"" + this.ListGroupItemClass + ">" + content + "</button>");
            else if (this.ItemHref.Length > 0)
            {
                output.Content.AppendHtml("<a href=" + this.ItemHref + " target=" + this.ItemTarget + "  class=\"list-group-item " + this.ListGroupItemClass + "\">" + content + "</a>");
            }
            else
            {
                output.Content.AppendHtml(content);
                output.Attributes.SetAttribute("class", ("list-group-item " + this.ListGroupItemClass));
            }

            await base.ProcessAsync(context, output);
        }
    }
}