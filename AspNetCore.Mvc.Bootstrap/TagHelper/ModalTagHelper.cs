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
    [HtmlTargetElement("bs-modal")]
    public class ModalTagHelper : TagHelper
    {
        [HtmlAttributeName("id")]
        public string ModalId { get; set; } = "";

        [HtmlAttributeName("size")]
        public string ModalSize { get; set; } = "";

        [HtmlAttributeName("class")]
        public string ModalClass { get; set; } = "";

        [HtmlAttributeName("role")]
        public string Role { get; set; } = "";

        [HtmlAttributeName("tabindex")]
        public string TabIndex { get; set; } = "";

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            string content = (await output.GetChildContentAsync()).GetContent();
            string str = "modal-dialog";
            if (this.ModalSize == "sm" || this.ModalSize == "lg")
                str = "modal-dialog modal-" + this.ModalSize;
            output.Content.AppendHtml($"<bs-modal-dialog class='{ str }'  role='document'><bs-modal-content class='modal-content'>{content }</bs-modal-content></bs-modal-dialog>");
            output.Attributes.SetAttribute("id", this.ModalId);
            output.Attributes.SetAttribute("class", this.ModalClass);
            output.Attributes.SetAttribute("tabindex", this.TabIndex ?? "-1");
            output.Attributes.SetAttribute("role", this.Role);
            output.Attributes.SetAttribute("aria-labelledby", "myModalLabel");

            await base.ProcessAsync(context, output);
        }
    }
}