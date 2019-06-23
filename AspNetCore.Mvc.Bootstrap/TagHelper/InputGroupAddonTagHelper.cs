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
    [HtmlTargetElement("bs-input-group-addon")]
    public class InputGroupAddonTagHelper : TagHelper
    {
        [HtmlAttributeName("class")]
        public string InputGroupAddonClass { get; set; }=  string.Empty;

        [HtmlAttributeName("type")]
        public string InputGroupAddonType { get; set; }=  string.Empty;

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            string content = (await output.GetChildContentAsync()).GetContent();
            string str = "input-group-addon";
            if (this.InputGroupAddonType == "button")
                str = "input-group-btn";
            output.Content.AppendHtml(content);
            if (this.InputGroupAddonClass.Length > 0)
                output.Attributes.SetAttribute("class", (str + " " + this.InputGroupAddonClass));
            else
                output.Attributes.SetAttribute("class", str);

            await base.ProcessAsync(context, output);
        }
    }
}