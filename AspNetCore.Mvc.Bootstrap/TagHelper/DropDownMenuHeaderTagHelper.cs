﻿/**********************************************************************
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
    [HtmlTargetElement("bs-dropdown-menu-header")]
    public class DropDownMenuHeaderTagHelper : TagHelper
    {
        [HtmlAttributeName("class")]
        public string DropDownMenuHeader { get; set; } = "";

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.Content.AppendHtml((await output.GetChildContentAsync()).GetContent());
            output.Attributes.SetAttribute("class", ("dropdown-header " + this.DropDownMenuHeader));

            await base.ProcessAsync(context, output);
        }
    }
}