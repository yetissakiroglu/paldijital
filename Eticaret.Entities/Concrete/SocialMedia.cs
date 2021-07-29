using Eticaret.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Eticaret.Entities.Concrete
{
   public class SocialMedia:IEntity

    {
        public int Id { get; set; }
        public int settingId { get; set; }
        [Display(Name = "Sosyal Medya Iconu : ")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz.")]
        public string icon { get; set; }
        [Display(Name = "Sosyal Medya Url : ")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz.")]
        public string url { get; set; }
        public int row { get; set; }
        public bool status { get; set; }

        public virtual Setting Setting { get; set; }

    }
}
