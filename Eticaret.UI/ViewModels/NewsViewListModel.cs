using Eticaret.Entities.ComplexTypes;
using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eticaret.UI.ViewModels
{
    public class NewsViewListModel
    {
        public string title { get; set; }
        public List<News> Newsies { get; set; }
        public List<NewsCategory> NewsCategories { get; set; }

        public News Detail { get; set; }
        public NewsCategory NewsCategory { get; set; }
    }
}
