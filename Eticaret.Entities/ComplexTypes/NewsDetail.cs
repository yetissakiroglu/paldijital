using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Eticaret.Entities.ComplexTypes
{
  public  class NewsDetail
    {
        [Key]
        [Display(Name = "ID:")]
        public int newsId { get; set; }
        public int categoryId { get; set; }
        [Display(Name = "Kategori:")]
        public string categoryTitle { get; set; }
        public string categoryUrl { get; set; }
        [Display(Name = "Başlık:")]
        public string title { get; set; }
        public string keywords { get; set; }
        public string description { get; set; }
        public string shortDetail { get; set; }
        public string detail { get; set; }
        public string url { get; set; }
        public string imgPath { get; set; }
        [Display(Name = "Ana Manşet Resim : ")]
        public string imgPathAm { get; set; }

        [Display(Name = "Ana Manşet Açıklama : ")]
        public string detailAm { get; set; }

        [Display(Name = "Facebook Paylaşım Resmi :")]
        public string imgPathFp { get; set; }
        [Display(Name = "Direkt Link: ")]
        public string dLink { get; set; }
        [Display(Name = "Eklenme:")]
        public DateTime addTime { get; set; }
        public DateTime updateTime { get; set; }
        [Display(Name = "Hit:")]
        public int viewHit { get; set; }
        [Display(Name = "Ana Manşet:")]
        public bool aM { get; set; }
        [Display(Name = "Öne Çıkanlar:")]
        public bool oC { get; set; }
        [Display(Name = "Haber Bandı:")]
        public bool hB { get; set; }
        [Display(Name = "Son Dakika:")]
        public bool sD { get; set; }
        [Display(Name = "Özel Haber:")]
        public bool oH { get; set; }
        public int row { get; set; }
        [Display(Name = "Durumu:")]
        public bool status { get; set; }


        public virtual NewsCategory NewsCategory { get; set; }

    }
}
