using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eticaret.UI.Areas.ysadmin.ViewModels
{
    public class RadioApiListeViewModel
    {
        public string title { get; set; }
        public RadioApi RadioApi { get; set; }
        public List<RadioApi> RadiosApi { get; set; }

        public PagingInfo PagingInfo { get; set; }
    }
}
