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
    [HtmlTargetElement("bs-progress-bar")]
    public class ProgressBarTagHelper : TagHelper
    {
        [HtmlAttributeName("class")]
        public string ProgressBarClass { get; set; }=  string.Empty;

        [HtmlAttributeName("value")]
        public string ProgressVal { get; set; } = "0";

        [HtmlAttributeName("valuemin")]
        public string ProgressValMin { get; set; } = "0";

        [HtmlAttributeName("valuemax")]
        public string ProgressValMax { get; set; } = "100";

        [HtmlAttributeName("minwidth")]
        public string ProgressMinWidth { get; set; }=  string.Empty;

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            string content = (await output.GetChildContentAsync()).GetContent();
            string str=  string.Empty;
            if (this.ProgressMinWidth.Length > 0)
                str = "min-width: " + this.ProgressMinWidth + ";";
            output.Content.AppendHtml(content);
            output.Attributes.SetAttribute("class", ("progress-bar " + this.ProgressBarClass));
            output.Attributes.SetAttribute("style", ("width: " + this.ProgressVal + "%; " + str));
            output.Attributes.SetAttribute("aria-valuenow", this.ProgressVal);
            output.Attributes.SetAttribute("aria-valuemin", this.ProgressValMin);
            output.Attributes.SetAttribute("aria-valuemax", this.ProgressValMax);

            await base.ProcessAsync(context, output);
        }
    }
}