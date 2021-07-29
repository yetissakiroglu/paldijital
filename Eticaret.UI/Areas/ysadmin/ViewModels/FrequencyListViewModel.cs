using Eticaret.Entities.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eticaret.UI.Areas.ysadmin.ViewModels
{
    public class FrequencyListViewModel
    {
        public string title { get; set; }
        public Frequency Frequency { get; set; }
        public List<Frequency> Frequencys { get; set; }

        public IEnumerable<SelectListItem> RadiosApi { get; set; }

        public PagingInfo PagingInfo { get; set; }

        public string Search { get; set; }
        public int Limit { get; set; }
        public int RadioApiId { get; set; }
    }
}
