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

namespace AspNetCore.Mvc.Bootstrap.TagHelpers
{
    [HtmlTargetElement(Attributes = "bs-toggle-modal")]
    public class ModalToggleTagHelper : TagHelper
    {
        [HtmlAttributeName("bs-toggle-modal")]
        public string ToggleModal { get; set; }=  string.Empty;

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.SetAttribute("data-toggle", "modal");
            output.Attributes.SetAttribute("data-target", string.Format("#{0}", this.ToggleModal));
        }
    }
}