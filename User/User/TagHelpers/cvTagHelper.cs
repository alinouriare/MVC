using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace User.TagHelpers
{
    public class cvTagHelper: TagHelper
    {
        public bool test { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var p = new TagBuilder("ul");
            p.InnerHtml.Append("<li>1</li>");
            output.Content.AppendHtml(p);

           
        }
    }
}
