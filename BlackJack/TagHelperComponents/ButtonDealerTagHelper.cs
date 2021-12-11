using BlackJack.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJack.TagHelperComponents
{
    [HtmlTargetElement("showdealerbutton")]
    public class ButtonDealerTagHelper : TagHelper
    {
        private ISession session { get; set; }
        public bool NeedsDeal { get; set; }
        public ButtonDealerTagHelper(IHttpContextAccessor accessor)
        {
            session = accessor.HttpContext.Session;
            NeedsDeal = Convert.ToBoolean(session.GetInt32("deal"));
        }

        public override void Process(TagHelperContext context,
        TagHelperOutput output)
        {
            output.TagName = "form";

            output.Attributes.SetAttribute("class", "col-2 offset-3");
            output.TagMode = TagMode.StartTagAndEndTag;
            var content = "";



            if (NeedsDeal)
            {
                content += $"< button type='submit' class='btn btn-primary'>Deal</button>";
            }
            else
            {
                content += "<button type='submit' class='btn btn-primary' disabled>Deal</button>";
            }
            output.Content.SetHtmlContent(content);
        }
    }
}
