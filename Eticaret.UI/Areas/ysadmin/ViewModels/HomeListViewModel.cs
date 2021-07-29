using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eticaret.UI.Areas.ysadmin.ViewModels
{
    public class HomeListViewModel
    {
        public int NewsCount { get; set; }
        public List<News> Newses { get; set; }

    }
}
