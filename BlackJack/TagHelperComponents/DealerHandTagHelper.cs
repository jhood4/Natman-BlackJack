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
    [HtmlTargetElement("showdealercards")]
    public class DealerHandTagHelper : TagHelper
    {
        private ISession session { get; set; }
        public Dealer Dealer { get; set; }
        public DealerHandTagHelper(IHttpContextAccessor accessor)
        {
            session = accessor.HttpContext.Session;
            Dealer = session.GetObject<Dealer>("dealer") ?? new Dealer();

        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewCtx { get; set; }

        public override void Process(TagHelperContext context,
        TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.SetAttribute("class", "hand mb-4");
            output.TagMode = TagMode.StartTagAndEndTag;
            var content = "";
            for(int i = 0; i < Dealer.Hand.Count; i++)
            {
                if(i == 0 && Dealer.Hand.HideHoleCard)
                {
                    content += "<img src='images/back.svg' class='img-fluid' />";
                }
                else
                {
                    Card card = Dealer.Hand.Cards[i];
                    content += $"<img src='images/{card.Name}.svg' class='img-fluid' />";
                }
            }
            output.Content.SetHtmlContent(content);
        }
    }
}
