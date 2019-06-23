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
    [HtmlTargetElement("bs-modal-fade")]
    public class ModalFadeTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            (await output.GetChildContentAsync()).GetContent();
            output.Attributes.SetAttribute("class", "modal");
            output.Attributes.SetAttribute("tabindex", "-1");
            output.Attributes.SetAttribute("role", "dialog");
            output.Attributes.SetAttribute("aria-labelledby", "myModalLabel");

            await base.ProcessAsync(context, output);
        }
    }
}