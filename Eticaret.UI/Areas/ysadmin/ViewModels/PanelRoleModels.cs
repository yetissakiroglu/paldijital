using Eticaret.Core.Entities.Concrete;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Eticaret.UI.Areas.ysadmin.ViewModels
{
    public class RoleModel
    {
        [Required]
        [Display(Name = "Role İsme")]
        public string Name { get; set; }
        public string Id { get; set; }

    }

    public class RoleDetails
    {
        public IdentityRole Role { get; set; }
        public IEnumerable<AppUser> Members { get; set; }
        public IEnumerable<AppUser> NonMembers { get; set; }
    }

    public class RoleEditModel
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public string[] IdsToAdd { get; set; }
        public string[] IdsToDelete { get; set; }
    }

    public class RoleList
    {
        public string title { get; set; }

        public string Id { get; set; }
        public string Name { get; set; }

        public PagingInfo PagingInfo { get; set; }

        public string Search { get; set; }
        public int Limit { get; set; }

        public List<AppRole> roles { get; set; }
    }

    public class RoleClaimsAssignViewModel
    {
        public string Id { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
        public bool Exist { get; set; }
        public string RoleId { get; set; }
        public string Rolename { get; set; }

    }
}
