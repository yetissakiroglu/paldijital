using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Eticaret.UI.Areas.ysadmin.ViewModels
{
    public class UserProfilDetailModel
    {
        public string UserId { get; set; }

        public string Avatar { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }
        public string PhoneNumber { get; set; }

        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }

        public List<System.Security.Claims.Claim> Claims { get; set; }

    }
    public class ProfilInformationViewEditModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Avatar { get; set; }
    }
}
