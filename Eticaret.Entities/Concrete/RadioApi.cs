using Eticaret.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eticaret.Entities.Concrete
{
    public class RadioApi:IEntity
    {
        public int radioApiId { get; set; }
        public string title { get; set; }
        public bool programStatus { get; set; }
        public bool topmusiclistStatus { get; set; }
        public bool podcastStatus { get; set; }
        public bool broadcastStatus { get; set; }
        public bool frequencyStatus { get; set; }
        public bool djStatus { get; set; }
        public bool status { get; set; }
        public string securitykey { get; set; }

        public List<NewsRadio> NewsRadioCategories { get; set; }

        public virtual List<Banner  > Banners { get; set; }
        public virtual List<Broadcast> Broadcasts { get; set; }
        public virtual List<Frequency> Frequencys { get; set; }
        public virtual List<Program> Programs { get; set; }
        public virtual List<TopMusicList> TopMusicLists { get; set; }


        public RadioApi()
        {
            Frequencys = new List<Frequency>();
            Programs = new List<Program>();
        }
    }
}
