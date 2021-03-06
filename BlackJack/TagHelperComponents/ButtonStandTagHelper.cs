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
    [HtmlTargetElement("showstandbutton")]
    public class ButtonStandTagHelper : TagHelper
    {
        private ISession session { get; set; }
        public bool NeedsDeal { get; set; }
        public ButtonStandTagHelper(IHttpContextAccessor accessor)
        {
            session = accessor.HttpContext.Session;
            NeedsDeal = Convert.ToBoolean(session.GetInt32("stand"));
        }

        public override void Process(TagHelperContext context,
        TagHelperOutput output)
        {
            output.TagName = "form";

            output.Attributes.SetAttribute("class", "col-2");
            output.TagMode = TagMode.StartTagAndEndTag;
            var content = "<form asp-action='Stand' method='post' class='col'>";



            if (!NeedsDeal)
            {
                content += $"<button type='submit' class='btn btn-primary'>Stand</button>";
            }
            else
            {
                content += "<button type='submit' class='btn btn-primary' disabled>Stand</button>";
            }
            content += "</form>";
            output.Content.SetHtmlContent(content);
        }
    }
}
