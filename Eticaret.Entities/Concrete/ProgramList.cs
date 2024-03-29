﻿using Eticaret.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Eticaret.Entities.Concrete
{
    public class ProgramList:IEntity
    {
        [Key]
        [Display(Name = "Id : ")]
        public int programId { get; set; }

        [ForeignKey("RadioApi")]
        [Display(Name = "Radio ID : ")]
        public int radioApiId { get; set; }
        [Display(Name = "Program Adı: ")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz.")]
        public string title { get; set; }
        [Display(Name = "Program Etiketleri: ")]
        public string keywords { get; set; }
        [Display(Name = "Program Açıklaması: ")]
        public string description { get; set; }

        [Display(Name = "Program İçerik Açıklaması: ")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz.")]
        public string detail { get; set; }
        [Display(Name = "Program İçerik Bilgisi: ")]
        public string infoDetail { get; set; }
        public string url { get; set; }
        public string imgPath { get; set; }
        [Display(Name = "Program Sunucu & Dj Adı: ")]
        public string djName { get; set; }
        [Display(Name = "Sıralama: ")]
        public int row { get; set; }
        [Display(Name = "Durumu: ")]
        public bool status { get; set; }

        public virtual List<PodcastMusicList> PodcastMusicLists { get; set; }

        public ProgramList()
        {
            PodcastMusicLists = new List<PodcastMusicList>();
        }

        public virtual RadioApi RadioApi { get; set; }

    }
}
