using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Eticaret.UI.Areas.ysadmin.ViewModels
{
    public class PasswordChangeViewModel
    {
        [Display(Name = "Eski Şifreniz : ", Prompt = "Eski Şifrenizi Giriniz")]
        [Required(ErrorMessage = "Şifre alını geçersizdir.")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Şifre en az 6 karakterli olmalıdır.")]
        public string PasswordOld { get; set; }

        [Display(Name = "Yeni Şifreniz : ", Prompt = "Yeni Şifrenizi Giriniz")]
        [Required(ErrorMessage = "Şifre alını geçersizdir.")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Şifre en az 6 karakterli olmalıdır.")]
        public string PasswordNew { get; set; }

        [Display(Name = "Yeni Tekrar Şifreniz : ", Prompt = "Yeni Şifrenizi Tekrar Giriniz")]
        [Required(ErrorMessage = "Şifre alını geçersizdir.")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Şifre en az 6 karakterli olmalıdır.")]
        [Compare("PasswordNew", ErrorMessage = "Yeni Şifreniz Onay Şifrenizle aynı değildir.")]
        public string RePasswordNew { get; set; }
    }
}
