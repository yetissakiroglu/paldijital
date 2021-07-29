using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Eticaret.UI.Areas.ysadmin.ViewModels
{
    public class SettingListViewModel
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
        [Display(Name = "Site Logosu : ")]
        public string logoPath { get; set; }
        [Display(Name = "Site Footer Logosu : ")]
        public string footerLogoPath { get; set; }
        public bool status { get; set; }

        //------------------
        public List<Setting> Settings { get; set; }
    }
}
