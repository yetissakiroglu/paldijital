using Eticaret.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Eticaret.Entities.Concrete
{
    public class Setting : IEntity
    {
        public int settingId { get; set; }

        [Display(Name = "Site Adı : ")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz.")]
        public string title { get; set; }

        [Display(Name = "Site Slogan : ")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz.")]
        public string slogan { get; set; }

        [Display(Name = "Site Etiket : ")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz.")]
        public string keywords { get; set; }

        [Display(Name = "Site Açıklaması : ")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz.")]
        public string description { get; set; }
        public string logoPath { get; set; }
        public string footerLogoPath { get; set; }
        public bool status { get; set; }

        public virtual List<SocialMedia> SocialMedia { get; set; }

        public Setting()
        {
            SocialMedia = new List<SocialMedia>();
        }

    }

}
