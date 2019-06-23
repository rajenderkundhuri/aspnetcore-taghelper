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
using System;
using System.Threading.Tasks;

namespace AspNetCore.Mvc.Bootstrap.TagHelpers
{
    [HtmlTargetElement("bs-button")]
    public class ButtonTagHelper : TagHelper
    {
        [HtmlAttributeName("element")]
        public string ButtonElement { get; set; } = "button";

        [HtmlAttributeName("id")]
        public string ButtonId { get; set; } = "";

        [HtmlAttributeName("autocomplete")]
        public string ButtonAutocomplete { get; set; } = "off";

        [HtmlAttributeName("loading-text")]
        public string ButtonLoadingText { get; set; } = "Loading";

        [HtmlAttributeName("class")]
        public string ButtonClass { get; set; } = "btn";

        [HtmlAttributeName("type")]
        public string ButtonType { get; set; } = "button";

        [HtmlAttributeName("option")]
        public string ButtonOption { get; set; } = "default";

        [HtmlAttributeName("size")]
        public string ButtonSize { get; set; } = "default";

        [HtmlAttributeName("active")]
        public bool ButtonActive { get; set; }

        [HtmlAttributeName("disabled")]
        public bool ButtonDisabled { get; set; }

        [HtmlAttributeName("block")]
        public bool ButtonBlock { get; set; }

        [HtmlAttributeName("value")]
        public string ButtonValue { get; set; } = "";

        [HtmlAttributeName("link")]
        public string ButtonLink { get; set; } = "#";

        [HtmlAttributeName("target")]
        public string ButtonTarget { get; set; } = "_self";

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            string content = (await output.GetChildContentAsync()).GetContent();
            string str1 = this.ButtonValue.Length <= 0 ? content : this.ButtonValue;
            string[] array1 = new string[3]
            {
        "a",
        "button",
        "input"
            };
            string[] array2 = new string[3]
            {
        "button",
        "submit",
        "reset"
            };
            string[] array3 = new string[7]
            {
        "default",
        "primary",
        "success",
        "info",
        "warning",
        "danger",
        "link"
            };
            string[] strArray = new string[4]
            {
        "default",
        "large",
        "small",
        "extrasmall"
            };
            string str2 = "btn-default";
            string str3 = "";
            if (Array.IndexOf<string>(array1, this.ButtonElement) == -1)
                throw new ArgumentException("Invalid element! Please, use one of the following HTML elements - 'a', 'button' or 'input'");
            if (Array.IndexOf<string>(array2, this.ButtonType) == -1)
                throw new ArgumentException("Invalid button type! Please, use one of the following types - 'button', 'submit' or 'reset'");
            if (Array.IndexOf<string>(array3, this.ButtonOption) == -1)
                throw new ArgumentException("Invalid button option! Please, use one of the following options - 'default', 'primary', 'success', 'info', 'warning', 'danger' or 'link'");
            str2 = "btn-" + this.ButtonOption;
            if (this.ButtonDisabled)
                str3 = !(this.ButtonElement == "a") ? "disabled='disabled'" : "disabled";
            string encoded;
            if (this.ButtonElement == "a")
                encoded = string.Format("<a href='{0}' target='{1}' role='{2}' class='{3}' id='{4}' autocomplete='{5}' data-loading-text='{6}'>{7}</a>", this.ButtonLink, this.ButtonTarget, this.ButtonType, this.ButtonClass, this.ButtonId, this.ButtonAutocomplete, this.ButtonLoadingText, str1);
            else if (this.ButtonElement == "input")
                encoded = string.Format("<input type='{0}' class='{1}' {2} value='{3}' id='{4}' autocomplete='{5}' data-loading-text='{6}'/>", this.ButtonType, this.ButtonClass, str3, str1, this.ButtonId, this.ButtonAutocomplete, this.ButtonLoadingText);
            else
                encoded = string.Format("<button type='{0}' class='{1}' {2}  id='{3}' autocomplete='{4}' data-loading-text='{5}'>{6}</button>", this.ButtonType, this.ButtonClass, str3, this.ButtonId, this.ButtonAutocomplete, this.ButtonLoadingText, str1);
            output.Content.AppendHtml(encoded);

            await base.ProcessAsync(context, output);
        }
    }
}