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
            
        }
    }
}
