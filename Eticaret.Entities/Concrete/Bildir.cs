using Eticaret.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Eticaret.Entities.Concrete
{
  public  class Bildir:IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Adınız Soyadınız. : ", Prompt = "Adınız soyadınızı giriniz.")]
        [Required(ErrorMessage = "Bu alan boş burakılamaz.")]
        public string name { get; set; }

        [Display(Name = "E-Posta Adresiniz. : ", Prompt = "E-Posta adresini giriniz.")]
        [Required(ErrorMessage = "Bu alan boş burakılamaz.")]
        public string email { get; set; }
        [Display(Name = "Uygulama Hata Mesajı : ", Prompt = "Uygulamada oluşan hataları bildiriniz.")]
        [Required(ErrorMessage = "Bu alan boş burakılamaz.")]
        public string message { get; set; }
  
        public bool IsRead { get; set; }
        public bool IsEdited { get; set; }
        
    }
}
