using Eticaret.Entities.ComplexTypes;
using Eticaret.Entities.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eticaret.UI.Areas.ysadmin.ViewModels
{
    public class NewsListViewModel
    {
        public string title { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }
        public IEnumerable<SelectListItem> RadiosApi { get; set; }

        public News News { get; set; }
        public List<News> Newsies { get; set; }

        public Seo Seo { get; set; }

        public NewsDetail NewsDetail { get; set; }
        public List<NewsDetail> NewsiesDetail { get; set; }

        public List<RadioApi> WebRadios { get; set; }

        public List<NewsRadio> SelectedWebRadios { get; set; }

        public PagingInfo PagingInfo { get; set; }

        public string Search { get; set; }
        public int Limit { get; set; }
        public int RadioApiId { get; set; }
        public int CategoryId { get; set; }

    }
}
