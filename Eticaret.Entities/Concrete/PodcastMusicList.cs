using Eticaret.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Eticaret.Entities.Concrete
{
    public class PodcastMusicList :IEntity
    {
        [Display(Name = "Podcast Id: ")]
        public int podcastMusicListId { get; set; }
        [Display(Name = "Ait Olduğu Program: ")]
        [ForeignKey("Program")]
        public int programId { get; set; }
        [Display(Name = "Podcast Adı: ")]
        public string title { get; set; }
        [Display(Name = "Podcast Açıklaması: ")]
        public string detail { get; set; }
        [Display(Name = "Podcast Dosyası: ")]
        public string soundPath { get; set; }
        [Display(Name = "Podcast Yayınlama Tarihi: ")]
        public DateTime startingDate { get; set; }
        public int row { get; set; }
        public bool status { get; set; }
        public virtual ProgramList Program { get; set; }

    }
}
