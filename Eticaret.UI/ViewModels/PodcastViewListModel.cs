using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eticaret.UI.ViewModels
{
    public class PodcastViewListModel
    {
        public string title { get; set; }

        public ProgramList Program { get; set; }
        public List<ProgramList> Programs { get; set; }

        //Ajax 
        public string soundPath { get; set; }
    }
}
