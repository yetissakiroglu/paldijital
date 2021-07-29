using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eticaret.UI.Areas.ysadmin.ViewModels
{
    public class RadioCategoryListViewModel
    {
        public RadioCategory RadioCategory { get; set; }
        public List<RadioCategory> RadioCategorys { get; set; }

        public PagingInfo PagingInfo { get; set; }


    }



}
