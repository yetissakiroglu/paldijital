using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eticaret.Core.Entities.Concrete;
using Eticaret.UI.Areas.ysadmin.ViewModels;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebUIStandart.Areas.ysadmin.ViewComponents
{
    [Authorize]
    public class Profil : ViewComponent
    {
        private UserManager<AppUser> _userManager;

        public Profil(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
            var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            UserProfilDetailModel _userProfilDetailModel = user.Adapt<UserProfilDetailModel>();
            return View(_userProfilDetailModel);

        }
    }
}