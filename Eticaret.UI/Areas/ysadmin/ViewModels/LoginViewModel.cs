using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Eticaret.UI.Areas.ysadmin.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "Email Adresiniz : ", Prompt = "Email Adresinizi Giriniz.")]
        [Required(ErrorMessage = "Email alını gereklidir.")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Şifreniz : ", Prompt = "Şifrenizi Giriniz.")]
        [Required(ErrorMessage = "Şifre alını geçersizdir.")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Şifre en az 6 karakterli olmalıdır.")]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }
}
