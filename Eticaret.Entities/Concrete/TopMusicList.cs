using Eticaret.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Eticaret.Entities.Concrete
{
    public class TopMusicList :IEntity
    {
        [Key]
        [Display(Name = "Top Liste Id : ")]
        public int topmusicListId { get; set; }
        [ForeignKey("RadioApi")]
        [Display(Name = "Radio ID : ")]
        public int radioApiId { get; set; }
        [Display(Name = "Liste Adı : ")]
        public string title { get; set; }
        [Display(Name = "Liste Etiketi : ")]
        public string keywords { get; set; }
        [Display(Name = "Liste Description : ")]
        public string description { get; set; }
        [Display(Name = "Liste Url : ")]
        public string url { get; set; }
        [Display(Name = "Liste Başlama Tarihi : ")]
        public DateTime startDate { get; set; }
        [Display(Name = "Liste Bitiş Tarihi : ")]
        public DateTime finishDate { get; set; }
        [Display(Name = "Liste Sıralaması : ")]
        public int row { get; set; }
        [Display(Name = "Liste Durumu : ")]
        public bool status { get; set; }

        public virtual List<MusicList> MusicLists { get; set; }
        public TopMusicList()
        {
            MusicLists = new List<MusicList>();
        }

        public virtual RadioApi RadioApi { get; set; }


    }
}
