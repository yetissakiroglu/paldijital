using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eticaret.UI.Areas.ysadmin.ViewModels
{
    public class NewsCategoryListViewModel
    {
        public string title { get; set; }
        public NewsCategory NewsCategory { get; set; }
        public List<NewsCategory> NewsCategorys { get; set; }

        public PagingInfo PagingInfo { get; set; }

    }
}
