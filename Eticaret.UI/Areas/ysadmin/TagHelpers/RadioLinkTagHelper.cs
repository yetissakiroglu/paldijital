using Eticaret.UI.Areas.ysadmin.ViewModels;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eticaret.UI.Areas.ysadmin.TagHelpers
{
    [HtmlTargetElement("div", Attributes = "page-model")]

    public class RadioLinkTagHelper : TagHelper

    {
        public PagingInfo PageModel { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("<ul class='pagination'>");

            if (PageModel.CurrentPage > 1)
            {
                stringBuilder.AppendFormat("<li class='page-item {0}'>", 1 > PageModel.CurrentPage ? "active" : "");
                stringBuilder.AppendFormat("<a class='page-link' href='?page={0}'><span aria-hidden='true'>&laquo;</span></a>", 1);
                stringBuilder.Append("</li>");
            }

            for (int i = 1; i <= PageModel.TotalPages(); i++)
            {
                stringBuilder.AppendFormat("<li class='page-item {0}'>", i == PageModel.CurrentPage ? "active" : "");
                if (!string.IsNullOrEmpty(PageModel.CurrentCategory.ToString()))
                {
                    stringBuilder.AppendFormat("<a class='page-link' href='?page={0}'>{0}</a>", i);
                }
                else
                {
                    stringBuilder.AppendFormat("<a class='page-link' href='{0}?page={1}'>{1}</a>", PageModel.CurrentCategory, i);
                }
                stringBuilder.Append("</li>");
            }

            if (PageModel.CurrentPage < PageModel.TotalPages())
            {
                stringBuilder.AppendFormat("<li class='page-item {0}'>", PageModel.TotalPages() < PageModel.CurrentPage ? "active" : "");
                stringBuilder.AppendFormat("<a class='page-link' href='?page={0}'><span aria-hidden='true'>&raquo;</span></a>", PageModel.TotalPages().ToString());
                stringBuilder.Append("</li>");
            }


            output.Content.SetHtmlContent(stringBuilder.ToString());
            base.Process(context, output);

        }
    }
}
