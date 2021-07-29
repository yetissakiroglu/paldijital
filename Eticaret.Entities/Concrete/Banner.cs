using Eticaret.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Eticaret.Entities.Concrete
{
    public class Banner : IEntity
    {
        [Display(Name = "Banner Id : ")]
        public int bannerId { get; set; }
        [ForeignKey("RadioApi")]
        [Display(Name = "Radio ID : ")]
        public int radioApiId { get; set; }

        [Display(Name = "Banner Adı : ")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz.")]
        public string title { get; set; }

        [Display(Name = "Banner Detayı : ")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz.")]
        public string detail { get; set; }

        [Display(Name = "Banner Logo : ")]
        public string imgPath { get; set; }

        [Display(Name = "Banner Url : ")]
        public string url { get; set; }

        [Display(Name = "Banner Sıralama : ")]
        public int row { get; set; }

        [Display(Name = "Banner Durumu : ")]
        public bool status { get; set; }

        public virtual RadioApi RadioApi { get; set; }



    }
}
