using Eticaret.Core.Entities;
using Eticaret.Entities.ComplexTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Eticaret.Entities.Concrete
{
   public class RadioCategory : IEntity
    {
        [Key]

        [Display(Name = "Kategori ID : ")]
        public int categoryId { get; set; }
        [Display(Name = "Kategori Adı : ")]
        public string title { get; set; }
        [Display(Name = "Kategori Seo Etiket : ")]
        public string keywords { get; set; }
        [Display(Name = "Kategori Seo Açıklaması : ")]
        public string description { get; set; }
        [Display(Name = "Kategori Kapak Resmi : ")]
        public string imgPath { get; set; }
        public string url { get; set; }
        [Display(Name = "Sıralama : ")]
        public int row { get; set; }
        [Display(Name = "Durum : ")]
        public bool status { get; set; }

        public virtual List<Radio> Radios { get; set; }
        public virtual List<RadioDetail> RadiosDetail { get; set; }

        public RadioCategory()
        {
            RadiosDetail = new List<RadioDetail>();

            Radios = new List<Radio>();
        }

    }
}
