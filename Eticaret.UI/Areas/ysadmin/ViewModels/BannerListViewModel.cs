using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eticaret.UI.Areas.ysadmin.ViewModels
{
    public class BannerListViewModel
    {
        public Banner Banner { get; set; }
        public List<Banner> Banners { get; set; }
        public PagingInfo PagingInfo { get; set; }

    }
}
