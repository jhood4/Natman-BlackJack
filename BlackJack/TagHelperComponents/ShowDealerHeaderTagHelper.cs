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
    [HtmlTargetElement("showdealerheader")]
    public class ShowDealerHeaderTagHelper : TagHelper
    {
        private ISession session { get; set; }
        public Dealer Dealer { get; set; }
        public ShowDealerHeaderTagHelper(IHttpContextAccessor accessor)
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
            string dealerHeader = "Dealer";

            if(Dealer.MustShowCards) 
            {
                dealerHeader = Dealer.Hand.Total.ToString();
            }

            output.TagName = "h5";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Content.SetContent(dealerHeader);
        }
    }
}
