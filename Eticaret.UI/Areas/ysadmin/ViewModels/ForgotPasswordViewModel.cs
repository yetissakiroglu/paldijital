using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Eticaret.UI.Areas.ysadmin.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Display(Name = "Şifremi Unuttum ?", Prompt = "Kayıtlı Emaili Giriniz.")]
        [Required(ErrorMessage = "Email alını gereklidir.")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
    }
}
