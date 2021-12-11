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
    [HtmlTargetElement("showplayercards")]
    public class PlayerHandTagHelper : TagHelper
    {
        private ISession session { get; set; }
        public Player Player { get; set; }
        public PlayerHandTagHelper(IHttpContextAccessor accessor)
        {
            session = accessor.HttpContext.Session;
            Player = session.GetObject<Player>("player") ?? new Player();

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
   
            foreach (Card card in Player.Hand.Cards)
            {
                
                 content += "<img src='~/images/@(card.Name).svg' />";
            }        
            output.Content.SetHtmlContent(content);
        }
    }
}
