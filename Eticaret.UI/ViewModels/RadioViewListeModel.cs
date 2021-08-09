using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eticaret.UI.ViewModels
{
    public class RadioViewListeModel
    {
        public string title { get; set; }
        public List<Radio> Radios { get; set; }

        //Ajax tanımlamaları
        public string streamUrl { get; set; }
        


    }
}
