using Eticaret.Business.Abstract;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eticaret.UI.Areas.ysadmin.TagHelpers
{
    [HtmlTargetElement("td", Attributes = "radioapi-Id")]
    [HtmlTargetElement("dd", Attributes = "radioapi-Id")]

    public class RadioApiTagHelper : TagHelper
    {
        private IRadioApiService _taghalperService;
        public RadioApiTagHelper(IRadioApiService taghalperService)
        {
            _taghalperService = taghalperService;

        }

        [HtmlAttributeName("radioapi-Id")]
        public int RadioApiId { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var RadioApi = _taghalperService.GetWebRadioBywebRadioId(RadioApiId);
            string html = string.Empty;
            if (RadioApi.Success)
            {
                html += $"<p style='margin-bottom:2px'> <span class='badge badge-primary btn-clean font-weight-bold'>  {RadioApi.Data.title} </span></p>";
            }
            if (html == string.Empty)
            {
                html = "<span class='badge badge-danger btn-clean font-weight-bold'> Bağlı Radyo Bulunmamaktadır. </span>";
            }
            output.Content.SetHtmlContent(html);
        }

    }
}
