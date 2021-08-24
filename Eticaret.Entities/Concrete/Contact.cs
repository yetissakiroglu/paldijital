using Eticaret.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Eticaret.Entities.Concrete
{
    public class Contact: IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Adınız Soyadınız. : ", Prompt = "Adınız soyadınızı giriniz.")]
        [Required(ErrorMessage = "Bu alan boş burakılamaz.")]
        public string name { get; set; }
        [Display(Name = "E-Posta Adresiniz. : ", Prompt = "E-Posta adresini giriniz.")]
        [Required(ErrorMessage = "Bu alan boş burakılamaz.")]
        public string email { get; set; }
        [Display(Name = "Konu : ", Prompt = "Bizimle iletişime geçmek istediğiniz konu.")]
        [Required(ErrorMessage = "Bu alan boş burakılamaz.")]
        public string subject { get; set; }
        [Display(Name = "Mesajınız : ", Prompt = "Bizimle iletişime geçmek istediğiniz mesajınız.")]
        [Required(ErrorMessage = "Bu alan boş burakılamaz.")]
        public string message { get; set; }


    }
}
