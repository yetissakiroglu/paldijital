using Eticaret.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Eticaret.UI.Areas.ysadmin.ViewModels
{

    public class UserCreateModel
    {
        public string Avatar { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string RePassword { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        [DataType(DataType.Date)]
        public DateTimeOffset LockoutEnd { get; set; }
        public IEnumerable<string> SelectedRoles { get; set; }
    }
    public class UserEditModel
    {
        public string Id { get; set; }

        public string Avatar { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }

        [DataType(DataType.DateTime)]
        public DateTimeOffset LockoutEnd { get; set; }
        public IEnumerable<string> SelectedRoles { get; set; }

    }
    public class UserDetail
    {
        public string Id { get; set; }

        public string Avatar { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }
        public string PhoneNumber { get; set; }

        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
    }
    public class UserList
    {
        public string title { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string Search { get; set; }
        public int Limit { get; set; }
        public List<AppUser> users { get; set; }
    }
    public class RoleAssignViewModel
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public bool Exist { get; set; }
        public string UserId { get; set; }
    }

}
