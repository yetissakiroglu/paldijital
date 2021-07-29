using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Eticaret.DataAccess.Abstract;
using Eticaret.Core.Entities.Concrete;
using Eticaret.UI.Areas.ysadmin.ViewModels;
using Mapster;

namespace WebUIStandart.Areas.ysadmin.ViewComponents
{
    [Authorize]
    public class PanelHeader : ViewComponent
    {
        private UserManager<AppUser> _userManager;

        public PanelHeader(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IViewComponentResult Invoke()
        {
            if (User.Identity.Name != null)
            {
                var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
                if (user != null)
                {
                    UserProfilDetailModel _userProfilDetailModel = user.Adapt<UserProfilDetailModel>();
                    return View(_userProfilDetailModel);
                }
            }
            return View();
        }
    }
}