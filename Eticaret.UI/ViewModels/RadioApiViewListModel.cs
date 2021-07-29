using Eticaret.Entities.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Eticaret.UI.ViewModels
{
    public class RadioApiViewListModel
    {
        public string title { get; set; }
        public List<RadioApi> RadioApies { get; set; }
        public RadioApi RadioApi { get; set; }
        public IEnumerable<SelectListItem> RadiosApiSelectListItem { get; set; }
        public int RadioApiId { get; set; }



    }
}
