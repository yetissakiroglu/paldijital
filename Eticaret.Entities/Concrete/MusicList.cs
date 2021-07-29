using Eticaret.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Eticaret.Entities.Concrete
{
    public class MusicList:IEntity
    {
        [Display(Name = "Müzik Id : ")]
        public int musicListId { get; set; }
        [ForeignKey("TopMusicList")]
        public int topmusicListId { get; set; }
        [Display(Name = "Kapak Resmi : ")]
        public string imgPath { get; set; }
        [Display(Name = "Mp3 Dosyası : ")]
        public string filePath { get; set; }
        [Display(Name = "Şarkı Adı : ")]
        public string songName { get; set; }
        [Display(Name = "Sanatçı Adı : ")]
        public string singerName { get; set; }
        [Display(Name = "Sıralaması : ")]
        public int row { get; set; }
        [Display(Name = "Değerlendirme : ")]
        public int rating { get; set; }
        [Display(Name = "Bu Hafta : ")]
        public int thisWeek { get; set; }
        [Display(Name = "Geçtiğimiz Hafta : ")]
        public int lastWeek { get; set; }
         public bool status { get; set; }
        public virtual TopMusicList TopMusicList { get; set; }
    }
}
