using Eticaret.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Eticaret.Entities.Concrete
{
    public class Seo:IEntity
    {
        public int seoId { get; set; }

        [Display(Name = "Seo Başlığı: ")]
        public string title { get; set; }

        [Display(Name = "Seo Keywords: ")]
        public string keywords { get; set; }

        [Display(Name = "Seo Description: ")]
        public string description { get; set; }

        public int seoType { get; set; }
        public int seoPageId { get; set; }

        public bool status { get; set; }

    }
}
