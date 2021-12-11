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
        public override void Process(TagHelperContext context,
        TagHelperOutput output)
        {
        output.TagName = "form";
  
        output.Attributes.SetAttribute("class", "col");
        output.TagMode = TagMode.StartTagAndEndTag;
        var content = "";


        
            if (NeedsDeal)
            {
                content += $"< button type="submit" class="btn btn-primary">Deal</button>";
            }
            else
            {
                <button type="submit" class="btn btn-primary" disabled>Deal</button>
            }

        
        }
    }
}
