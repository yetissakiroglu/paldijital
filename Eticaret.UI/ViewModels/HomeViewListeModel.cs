using Eticaret.Entities.ComplexTypes;
using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eticaret.UI.ViewModels
{
    public class HomeViewListeModel
    {
        public List<NewsDetail> Mansetler { get; set; }
        public List<NewsDetail> Oncikanlar { get; set; }

        public List<RadioApi> RadiosApiProgram { get; set; }

        public List<Radio> Radios { get; set; }

        public List<Dj> Djs { get; set; }

        public List<TopMusicList> TopMusicLists { get; set; }


    }
}
