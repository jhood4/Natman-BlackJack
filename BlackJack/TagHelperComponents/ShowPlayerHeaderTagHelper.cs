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
    [HtmlTargetElement("showplayerheader")]
    public class ShowPlayerHeaderTagHelper : TagHelper
    {
        private ISession session { get; set; }
        public Player Player { get; set; }
        public ShowPlayerHeaderTagHelper(IHttpContextAccessor accessor)
        {
            session = accessor.HttpContext.Session;
            Player = session.GetObject<Player>("dealer") ?? new Player();

        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewCtx { get; set; }

        public override void Process(TagHelperContext context,
        TagHelperOutput output)
        {
            string playerHeader = "Player";

            if (Player.Hand.HasCards)
            {
                playerHeader = Player.Hand.Total.ToString();
            }

            output.TagName = "h5";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Content.SetContent(playerHeader);
        }
    }
}
