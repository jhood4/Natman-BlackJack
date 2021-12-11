using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;

namespace BlackJack.TagHelperComponents
{
    [HtmlTargetElement("showdealerbutton")]
    public class ButtonDealerTagHelper : TagHelper
    {
        private ISession session { get; set; }
        private int? DealNeeded { get; set; }
        public ButtonDealerTagHelper(IHttpContextAccessor accessor)
        {
            session = accessor.HttpContext.Session;
            DealNeeded = session.GetInt32("deal") ?? 1;
        }

        public override void Process(TagHelperContext context,
        TagHelperOutput output)
        {
            output.TagName = "div";

            output.Attributes.SetAttribute("class", "col-2 offset-3");
            output.TagMode = TagMode.StartTagAndEndTag;
            var content = "<form asp-action='Deal' method='post' class='col'>";

            if (DealNeeded == 1) 
            {
                content += "<button type='submit' class='btn btn-primary'>Deal</button>";
            }
            else
            {
                content += "<button type='submit' class='btn btn-primary' disabled>Deal</button>";
            }
            content += "</form>";
            output.Content.SetHtmlContent(content);
        }
    }
}
