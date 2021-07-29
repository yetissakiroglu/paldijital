using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eticaret.UI.ViewModels
{
    public class BildirViewListModel
    {
        

        public string title { get; set; }

        public Bildir Bildir { get; set; }

        public List<Bildir> Bildirs { get; set; }

    }
}
