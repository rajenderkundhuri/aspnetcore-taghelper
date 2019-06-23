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
    [HtmlTargetElement("bs-tabs-nav")]
    public class TabsNavTagHelper : TagHelper
    {
        [HtmlAttributeName("id")]
        public string TabId { get; set; }=  string.Empty;

        [HtmlAttributeName("class")]
        public string TabClass { get; set; }=  string.Empty;

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.Content.AppendHtml((await output.GetChildContentAsync()).GetContent());
            output.Attributes.SetAttribute("class", "nav nav-tabs");
            output.Attributes.SetAttribute("id", this.TabId);
            output.Attributes.SetAttribute("role", "tablist");
            output.PostContent.AppendHtml("<script>\r\n                        var Tab = $.fn.tab.Constructor;\r\n                        var testedId='" + string.Format("{0}", this.TabId) + "';\r\n                        var testedElement = $('#'+testedId).find('[role=\\'presentation\\']')[0].nodeName;\r\n\r\n\r\nif(testedElement.toUpperCase()!='bs-TAB'){\r\n    $.fn.tab.Constructor = Tab;\r\n}else{\r\n                        Tab.prototype.show = function () {\r\n\r\n\r\n                     //   testedElement = this.element.context.parentNode.nodeName;\r\n                        if(testedElement.toUpperCase()!='bs-TAB') return TabOriginal.prototype.show;\r\n\r\n                            var $this    = this.element;\r\n\r\n                            var $ul      = $this.closest('bs-tabs-nav:not(.dropdown-menu)')\r\n                            var selector = $this.data('target')\r\n\r\n                            if (!selector) {\r\n                              selector = $this.attr('href')\r\n                              selector = selector && selector.replace(/.*(?=#[^\\s]*$)/, '') // strip for ie7\r\n                            }\r\n\r\n                            if ($this.parent('bs-tab').hasClass('active')) return\r\n\r\n                            var $previous = $ul.find('.active:last a')\r\n                            var hideEvent = $.Event('hide.bs.tab', {\r\n                              relatedTarget: $this[0]\r\n                            })\r\n                            var showEvent = $.Event('show.bs.tab', {\r\n                              relatedTarget: $previous[0]\r\n                            })\r\n\r\n                            $previous.trigger(hideEvent)\r\n                            $this.trigger(showEvent)\r\n\r\n                            if (showEvent.isDefaultPrevented() || hideEvent.isDefaultPrevented()) return\r\n\r\n                            var $target = $(selector)\r\n\r\n                            this.activate($this.closest('bs-tab'), $ul)\r\n                            this.activate($target, $target.parent(), function () {\r\n                              $previous.trigger({\r\n                                type: 'hidden.bs.tab',\r\n                                relatedTarget: $this[0]\r\n                              })\r\n                              $this.trigger({\r\n                                type: 'shown.bs.tab',\r\n                                relatedTarget: $previous[0]\r\n                              })\r\n                            })\r\n\r\n                      }\r\n\r\n}\r\n                    //  $.fn.tab.Constructor = Tab;\r\n\r\n                </script>");
            output.PostContent.AppendHtml("<script> $(function () { $('#" + this.TabId + " a').click(function (e) { e.preventDefault(); $(this).tab('show'); }); }); </script>");

            await base.ProcessAsync(context, output);
        }
    }
}