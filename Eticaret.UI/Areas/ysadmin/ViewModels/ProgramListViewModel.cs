using Eticaret.Entities.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eticaret.UI.Areas.ysadmin.ViewModels
{
    public class ProgramListViewModel
    {
        public string title { get; set; }
        public Eticaret.Entities.Concrete.ProgramList Program { get; set; }
        public List<Eticaret.Entities.Concrete.ProgramList> Programs { get; set; }

        public IEnumerable<SelectListItem> RadiosApi { get; set; }

        public PagingInfo PagingInfo { get; set; }

        public string Search { get; set; }
        public int Limit { get; set; }
        public int RadioApiId { get; set; }
    }
}
