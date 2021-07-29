using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eticaret.Core.Entities.ComplexTypes;
using Microsoft.AspNetCore.Mvc;
using Eticaret.Core.Extensions;
using Eticaret.Core.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Mapster;
using Eticaret.UI.Areas.ysadmin.ViewModels;
using Microsoft.AspNetCore.Http;

namespace Eticaret.UI.Areas.ysadmin.Controllers
{
    [Area("ysadmin")]
    //[Authorize(Roles = "admin")]
    [Authorize]
    public class ProfilController : Controller
    {
        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;

        public ProfilController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;

        }


        public IActionResult hesabim()
        {

            var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            UserProfilDetailModel _userProfilDetailModel = user.Adapt<UserProfilDetailModel>();


            _userProfilDetailModel.Claims = User.Claims.ToList();

            //var entity = new UserProfilDetailModel()
            //{


            //}
            return View(_userProfilDetailModel);





        }
        public IActionResult InformationViewEdit()
        {
            var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            ProfilInformationViewEditModel _profilInformationViewEditModel = user.Adapt<ProfilInformationViewEditModel>();
            return View(_profilInformationViewEditModel);
        }
        [HttpPost]
        public async Task<IActionResult> InformationViewEdit(ProfilInformationViewEditModel model, IFormFile profile_avatar)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            AppUser user = _userManager.FindByNameAsync(User.Identity.Name).Result;

            user.UserName = model.UserName;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.PhoneNumber = model.PhoneNumber;
            user.Email = model.Email;
            var ImgFile = await DosyaCreateExtensions.ImgCreate(profile_avatar, "paneluser", model.UserName);
            user.Avatar = ImgFile;

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                TempData.Put("message", new ResultMessage()
                {
                    Title = "Başarılı",
                    Message = "Bilgileriniz Değişitirildi.",
                    Css = "primary"
                });
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }

            return View(model);

        }

        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ChangePassword(PasswordChangeViewModel passwordChangeViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(passwordChangeViewModel);
            }

            var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            if (user != null)
            {
                bool exist = _userManager.CheckPasswordAsync(user, passwordChangeViewModel.PasswordOld).Result;
                if (exist)
                {

                    var result = _userManager.ChangePasswordAsync(user, passwordChangeViewModel.PasswordOld, passwordChangeViewModel.RePasswordNew).Result;

                    if (result.Succeeded)
                    {

                        _userManager.UpdateSecurityStampAsync(user);
                        _signInManager.SignOutAsync();
                        _signInManager.PasswordSignInAsync(user, passwordChangeViewModel.PasswordNew, true, false);


                        TempData.Put("message", new ResultMessage()
                        {
                            Title = "Değişiklik Yapıldı",
                            Message = "Şifreniz Paşarılı Bir Şekilde Değiştirilmiştir.",
                            Css = "warning"
                        });
                    }
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Eski Şifreniz Doğru Değildir.");
                }
            }
            return View(passwordChangeViewModel);
        }

    }
}
