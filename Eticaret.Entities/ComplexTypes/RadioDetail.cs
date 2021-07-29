using Eticaret.Core.Entities;
using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Eticaret.Entities.ComplexTypes
{
    public class RadioDetail : ICTypes
    {
        [Key]

        [Display(Name = "ID : ")]
        public int radioId { get; set; }

        [Display(Name = "KATEGORİ ID : ")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz.")]
        public int categoryId { get; set; }

        [Display(Name = "KATEGORİ:")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz.")]
        public string categoryTitle { get; set; }

        [Display(Name = "KATEGORİ URL : ")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz.")]
        public string categoryUrl { get; set; }

        [Display(Name = "RADYO ADI : ")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz.")]
        public string title { get; set; }
        [Display(Name = "RADYO SLOGAN: ")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz.")]
        public string slogan { get; set; }
        [Display(Name = "RADYO LOGOSU : ")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz.")]
        public string imgPath { get; set; }
        [Display(Name = "RADYO WEB SİTE : ")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz.")]
        public string webUrl { get; set; }
        [Display(Name = "RADYO E3U8 ADRESİ : ")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz.")]
        public string m3u8Url { get; set; }
        [Display(Name = "RADYO STREAM ADRESİ : ")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz.")]
        public string streamUrl { get; set; }
        [Display(Name = "RADYO SIRASI : ")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz.")]
        public int streamId { get; set; }
        [Display(Name = "RADYO SIRASI : ")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz.")]

        public int row { get; set; }
        [Display(Name = "WEB'DE GÖSTER : ")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz.")]
        public bool webstatus { get; set; }
        [Display(Name = "MOBİL'DE GÖSTER : ")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz.")]
        public bool mobilstatus { get; set; }

        public virtual RadioCategory RadioCategory { get; set; }

    }
}
