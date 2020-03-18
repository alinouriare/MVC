using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViewAndHelper.TagHelpers
{
    [HtmlTargetElement(Attributes = "aro-alert")]
    public class DivTagHelper : TagHelper
    {
        public bool AroAlert { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (AroAlert)
            {

                if (DateTime.Now.Hour > 9)
                {
                    output.SuppressOutput();
                }
                else
                {
                    output.TagName = "p";
                    output.Attributes.Add("Class", "alert alert-danger");
                }


            }

        }
    }

    //[HtmlTargetElement(tag: "div", Attributes = "aro-card")]

    public class CardTagHelper : TagHelper
    {
        public string HeaderText { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var card = new TagBuilder("div");
            card.AddCssClass("card");
            var header = new TagBuilder("div");

            header.AddCssClass("card-header");
            header.InnerHtml.Append(HeaderText);
            var body = new TagBuilder("div");
            body.AddCssClass("card-body");

            body.InnerHtml.Append("aaa");

            card.InnerHtml.AppendHtml(header);
            card.InnerHtml.AppendHtml(body);

            output.SuppressOutput();

            output.Content.AppendHtml(card);
        }
    }
}
