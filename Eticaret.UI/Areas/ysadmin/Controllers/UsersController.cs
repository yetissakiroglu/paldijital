using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Eticaret.Business.Abstract;
using Eticaret.Core.Entities.ComplexTypes;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Eticaret.Core.Extensions;
using Eticaret.Core.Utilities.Messages;
using Eticaret.UI.Areas.ysadmin.ViewModels;
using Eticaret.Core.Entities.Concrete;

namespace WebUIStandart.Areas.ysadmin.Controllers
{
    [Area("ysadmin")]
    //[Authorize(Roles = "Admin")]
    //[Authorize]

    public class UsersController : Controller
    {
        private UserManager<AppUser> _userManager { get; }
        private RoleManager<AppRole> _roleManager { get; }

        public UsersController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }



        public IActionResult Index(int limit, string metin, int page = 1)
        {
            if (limit == 0)
            {
                limit = 10;
            }
            var user = _userManager.Users.ToList();

            var models = new UserList()
            {
                title = "Kullanıcılar",
                users = user,
                //RadiosApi = new SelectList(_radioApiService.ListWebRadio().Data, "radioApiId", "title"),
                PagingInfo = new PagingInfo()
                {
                    CurrentPage = page,
                    ItemsPerPage = limit,
                    TotalItems = user.Count,
                    //CurrentCategory = radioApiId
                }
            };

            if (!string.IsNullOrEmpty(metin))
            {
                models.Search = metin;
            }

            return View(models);
          
        }

        public IActionResult Create()
        {
            UserCreateModel model = new UserCreateModel();


            var roles = _roleManager.Roles.Select(i => i.Name);
            ViewBag.Roles = roles;
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Create(UserCreateModel model, IFormFile profile_avatar, string[] selectedRoles)
        {
            if (!ModelState.IsValid)
            {
                var roleas = _roleManager.Roles.Select(i => i.Name);
                ViewBag.Roles = roleas;
                return View(model);
            }

            var usermodel = new AppUser
            {
                UserName = model.UserName,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                EmailConfirmed = model.EmailConfirmed,
                LockoutEnd = model.LockoutEnd
            };
            var ImgFile = await DosyaCreateExtensions.ImgCreate(profile_avatar, "avatar", model.UserName);
            usermodel.Avatar = ImgFile;
            var result = await _userManager.CreateAsync(usermodel, model.Password);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(model.UserName);
                if (user != null)
                {
                    var userRoles = await _userManager.GetRolesAsync(user);
                    selectedRoles = selectedRoles ?? new string[] { };
                    await _userManager.AddToRolesAsync(user, selectedRoles.Except(userRoles).ToArray<string>());
                    TempData.Put("message", new ResultMessage()
                    {
                        Title = "Ekleme Başarılı",
                        Message = $"{user.FirstName} {user.LastName}  isimli Kullanıcı eklendi.",
                        Css = "primary"
                    });
                    return RedirectToAction("Index", "Users");
                }
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }

            var roles = _roleManager.Roles.Select(i => i.Name);
            ViewBag.Roles = roles;
            return View(model);


        }


        public async Task<IActionResult> Edit(string Id)
        {
            var user = await _userManager.FindByIdAsync((string)Id);
            if (user != null)
            {
                var selectedRoles = await _userManager.GetRolesAsync(user);
                var roles = _roleManager.Roles.Select(i => i.Name);

                ViewBag.Roles = roles;

                UserEditModel entity = user.Adapt<UserEditModel>();
                entity.SelectedRoles = selectedRoles;
                return View(entity);
            }
            else
            {
                TempData.Put("message", new ResultMessage()
                {
                    Title = "Hata",
                    Message = "Kayıt Bulunamadı.",
                    Css = "warning"
                });

                return View("Index");
            }

        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserEditModel model, IFormFile profile_avatar, string[] selectedRoles)
        {
            if (ModelState.IsValid)
            {


                var user = await _userManager.FindByIdAsync(model.Id);
                if (user != null)
                {
                    user.UserName = model.UserName;
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    user.PhoneNumber = model.PhoneNumber;
                    user.Email = model.Email;
                    user.LockoutEnd = model.LockoutEnd;

                    if (profile_avatar != null)
                    {
                        var ImgFile = await DosyaCreateExtensions.ImgCreate(profile_avatar, "avatar", model.UserName);
                        user.Avatar = ImgFile;
                    }
                    else
                    {
                        user.Avatar = model.Avatar;
                    }

                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {

                        var userRoles = await _userManager.GetRolesAsync(user);
                        selectedRoles = selectedRoles ?? new string[] { };
                        await _userManager.AddToRolesAsync(user, selectedRoles.Except(userRoles).ToArray<string>());
                        await _userManager.RemoveFromRolesAsync(user, userRoles.Except(selectedRoles).ToArray<string>());

                        TempData.Put("message", new ResultMessage()
                        {
                            Title = "Güncelleme Başarılı",
                            Message = $"{user.FirstName} {user.LastName}  isimli Kullanıcı Güncellendi.",
                            Css = "success"
                        });
                        return RedirectToAction("Index", "Users");
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
                    TempData.Put("message", new ResultMessage()
                    {
                        Title = "Hata",
                        Message = "Kayıt Bulunamadı.",
                        Css = "warning"
                    });
                    return RedirectToAction("Index", "Users");

                }
                var roles = _roleManager.Roles.Select(i => i.Name);
                ViewBag.Roles = roles;
                return View(model);
            }
            else
            {

                var roles = _roleManager.Roles.Select(i => i.Name);
                ViewBag.Roles = roles;
                return View(model);
            }

        }

        public IActionResult Detail(string Id)
        {
            var user = _userManager.FindByIdAsync((string)Id).Result;

            if (user != null)
            {
                UserDetail _userDetail = user.Adapt<UserDetail>();
                return PartialView("Detail", _userDetail);
            }
            else
            {
                return RedirectToAction("Users");
            }
        }


        [HttpPost]
        public IActionResult UserDelete(string Id)
        {
            var urser = _userManager.FindByIdAsync(Id).Result;
            if (urser != null)
            {
                var result = _userManager.DeleteAsync(urser).Result;
                if (result.Succeeded)
                {
                    TempData.Put("message", new ResultMessage()
                    {
                        Title = "BAŞARILI",
                        Message = "Silme İşlemi Gerçekleşmiştir.",
                        Css = "success"
                    });
                    return RedirectToAction("Index", "Users");
                }
                else
                {
                    ViewBag.ErrorMessage = "Bir Hata Oluştu. Lütfen Tekrar Deneyiniz.";
                    return RedirectToAction("Index", "Users");
                }
            }
            else
            {
                TempData.Put("message", new ResultMessage()
                {
                    Title = "Hata",
                    Message = "Kullanıcı Bulunmamaktadır.",
                    Css = "warning"
                });

            }
            return RedirectToAction("Index", "Users");
        }

        //Önemli benzer kodlama yapabilirim
        public IActionResult RoleAssign(string Id)
        {
            var user = _userManager.FindByIdAsync((string)Id).Result;

            IQueryable<AppRole> roles = _roleManager.Roles;
            List<string> userroles = _userManager.GetRolesAsync(user).Result as List<string>;

            List<RoleAssignViewModel> roleAssignViewModels = new List<RoleAssignViewModel>();
            foreach (var role in roles)
            {
                RoleAssignViewModel r = new RoleAssignViewModel();
                r.RoleId = role.Id;
                r.RoleName = role.Name;
                r.UserId = user.Id;
                if (userroles.Contains(role.Name))
                { r.Exist = true; }
                else
                { r.Exist = false; }

                roleAssignViewModels.Add(r);
            }

            return View(roleAssignViewModels);
        }
        [HttpPost]
        public async Task<IActionResult> RoleAssign(List<RoleAssignViewModel> roleAssignViewModels)
        {
            foreach (var item in roleAssignViewModels)
            {
                var user = await _userManager.FindByIdAsync(item.UserId);

                if (item.Exist)
                {
                    await _userManager.AddToRoleAsync(user, item.RoleName);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, item.RoleName);
                }
            }



            TempData.Put("message", new ResultMessage()
            {
                Title = ProsesMessages.TitleSuccess,
                Message = ProsesMessages.MessageGenerel,
                Css = ProsesMessages.CssSuccess,
            });

            return RedirectToAction("Index");
        }

    }
}