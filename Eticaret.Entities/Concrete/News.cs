using Eticaret.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Eticaret.Entities.Concrete
{
    public class News : IEntity
    {
        [Display(Name = "ID:")]
        public int newsId { get; set; }

        [ForeignKey("NewsCategory")]
        [Display(Name = "Kategori ID : ")]
        public int categoryId { get; set; }

        [Display(Name = "Haber Başlığı: ")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz.")]
        public string title { get; set; }

        [Display(Name = "Haber Kısı Detayı: ")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz.")]
        public string shortDetail { get; set; }
        [Display(Name = "Haber Detayı: ")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz.")]
        public string detail { get; set; }
        [Display(Name = "Haber Url: ")]
        public string url { get; set; }
        [Display(Name = "FOTOĞRAF YÜKLEME ALANI: ")]
        public string imgPath { get; set; }
        [Display(Name = "Ana Manşet Resim : ")]
        public string imgPathAm { get; set; }
        [Display(Name = "Ana Manşet Açıklama : ")]
        public string detailAm { get; set; }

        [Display(Name = "Facebook Paylaşım Resmi :")]
        public string imgPathFp { get; set; }
        [Display(Name = "Direkt Link: ")]
        public string dLink { get; set; }
        [Display(Name = "Ekleme Tarihi:")]
        public DateTime addTime { get; set; }
        public DateTime updateTime { get; set; }

        [Display(Name = "Okunma Sayısı:")]
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
        [Display(Name = "Yayınlama Durumu")]
        public bool status { get; set; }
        public virtual NewsCategory NewsCategory { get; set; }
        public List<NewsRadio> NewsRadios { get; set; }



    }
}
