using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eticaret.Core.Entities.ComplexTypes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Eticaret.Core.Extensions;
using Eticaret.Business.Abstract;
using Mapster;
using Eticaret.Core.Entities.Concrete;
using Pal.Core.EmailServices;
using Eticaret.UI.Areas.ysadmin.ViewModels;

namespace WebUIStandart.Areas.ysadmin.Controllers
{
    [Area("ysadmin")]

    public class AccountController : Controller
    {
        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;
        private IEmailSender _emailSender;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
        }

        public IActionResult Login(string ReturnUrl = null)
        {
            return View(new LoginViewModel()
            {
                ReturnUrl = ReturnUrl
            });
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel userloginModel)
        {
            if (!ModelState.IsValid)
            {
                return View(userloginModel);
            }


            var user = await _userManager.FindByEmailAsync(userloginModel.Email);

            if (user == null)
            {
                ModelState.AddModelError("", "Bu email ile daha önce hesap oluşturulmamış.");
                return View(userloginModel);
            }

            if (await _userManager.IsLockedOutAsync(user))
            {
                ModelState.AddModelError("", "Hesabının Güvenlik Açısından Bir Süreliğine Kilitlenmiştir.");
                return View(userloginModel);
            }

            var result = await _signInManager.PasswordSignInAsync(user, userloginModel.Password, userloginModel.RememberMe, false);
            if (result.Succeeded)
            {
                return Redirect(userloginModel.ReturnUrl ?? "~/ysadmin");
            }
            else
            {
                await _userManager.AccessFailedAsync(user);

                var fail = await _userManager.GetAccessFailedCountAsync(user);
                if (fail == 5)
                {
                    await _userManager.SetLockoutEndDateAsync(user, new System.DateTimeOffset(DateTime.Now.AddMinutes(20)));

                    ModelState.AddModelError("", "Hesabınız Birden Çok Başarısız Giriş Yaptığı İçin 20 Dakika Bloke Edilmiştir. 20 Dakika Sonra Tekrar Deneyinz.");
                }
                else
                {
                    ModelState.AddModelError("", "Geçersiz Email veya Parola yanlış");
                }
            }

            return View(userloginModel);

        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

               return Redirect("~/ysadmin");
        }
        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel forgotPasswordViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(forgotPasswordViewModel);
            }

            if (string.IsNullOrEmpty(forgotPasswordViewModel.Email))
            {
                TempData.Put("message", new ResultMessage()
                {
                    Title = "Forgot Password",
                    Message = "Bilgileriniz Hatalı",
                    Css = "danger"
                });

                return View();
            }

            var user = await _userManager.FindByEmailAsync(forgotPasswordViewModel.Email);

            if (user == null)
            {
                TempData.Put("message", new ResultMessage()
                {
                    Title = "Forgot Password",
                    Message = "Eposta adresi ile bir kullanıcı bulunamadı",
                    Css = "danger"
                });

                return View();
            }

            var code = await _userManager.GeneratePasswordResetTokenAsync(user);

            var callbackUrl = Url.Action("ResetPassword", "Account", new
            {
                userId = user.Id,
                token = code
            });

            // send email
            await _emailSender.SendEmailAsync(forgotPasswordViewModel.Email, "Reset Password", $"Parolanızı yenilemek için linke <a href='https://localhost:44351{callbackUrl}'>tıklayınız.</a>");

            TempData.Put("message", new ResultMessage()
            {
                Title = "Forgot Password",
                Message = "Parola yenilemek için hesabınıza mail gönderildi.",
                Css = "warning"
            });

            return RedirectToAction("Login", "Account");
        }
        public IActionResult Accessdenied()
        {
            return View();
        }
        public async Task<IActionResult> ResetPassword(string userId, string token)
        {
            if (token == null && userId == null)
            {
                return RedirectToAction("Home", "Index");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return RedirectToAction("Home", "Index");
            }

            var model = new ResetPasswordModel { UserId = userId, Token = token };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null)
            {
                return RedirectToAction("Home", "Index");
            }

            var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);

            if (result.Succeeded)
            {
                await _userManager.UpdateSecurityStampAsync(user);
                TempData.Put("message", new ResultMessage()
                {
                    Title = "Yenileme",
                    Message = "Şifreniz Paşarılı Bir Şekilde Değiştirilmiştir.",
                    Css = "danger"
                });

                return RedirectToAction("Login", "Account");
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

        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
            {
                TempData["message"] = "Geçersiz token.";
                return View();
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var result = await _userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {
                    TempData["message"] = "Hesabınız onaylandı";
                    return View();
                }
            }

            TempData["message"] = "Hesabınız onaylanmadı.";
            return View();
        }

    }
}