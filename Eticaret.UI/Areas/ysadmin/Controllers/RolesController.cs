using Eticaret.Business.Abstract;
using Eticaret.Core.Entities.ComplexTypes;
using Eticaret.Core.Entities.Concrete;
using Eticaret.UI.Areas.ysadmin.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Eticaret.Core.Extensions;

using System.Threading.Tasks;
using WebUIStandart.Areas.ysadmin.ClaimsRepository;
using System.Security.Claims;

namespace Eticaret.UI.Areas.ysadmin.Controllers
{
    [Area("ysadmin")]
    [Authorize]

    public class RolesController : Controller
    {

        private IRoleClaimsService _roleClaimsService;
        private RoleManager<AppRole> _roleManager { get; }
        private UserManager<AppUser> _userManager { get; }

        public RolesController(IRoleClaimsService roleClaimsService, RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleClaimsService = roleClaimsService;
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public IActionResult Index(int limit, string metin, int page = 1)
        {
            if (limit == 0)
            {
                limit = 10;
            }

            var role = _roleManager.Roles.ToList();
            var models = new RoleList()
            {
                title = "Kullanıcılar",
                roles = role,
                PagingInfo = new PagingInfo()
                {
                    CurrentPage = page,
                    ItemsPerPage = limit,
                    TotalItems = role.Count,
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
            return View();
        }
        [HttpPost]
        public IActionResult Create(RoleModel roleViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(roleViewModel);
            }

            var role = new AppRole
            {
                Name = roleViewModel.Name
            };

            var result = _roleManager.CreateAsync(role).Result;
            if (result.Succeeded)
            {
                TempData.Put("message", new ResultMessage()
                {
                    Title = "BAŞARILI",
                    Message = "Role Başarılı Bir Şekilde Oluşturulmuştur.",
                    Css = "warning"
                });
                return RedirectToAction("Index", "Roles");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }

            return View(roleViewModel);
        }
        public IActionResult Edit(string Id)
        {
            var role = _roleManager.FindByIdAsync((string)Id).Result;

            if (role != null)
            {
                var entity = new RoleModel()
                {
                    Id = role.Id,
                    Name = role.Name
                };
                return PartialView("Edit", entity);
            }
            else
            {
                return RedirectToAction("Roles");
            }
        }
        [HttpPost]
        public IActionResult Edit(RoleModel roleViewModel)
        {
            var role = _roleManager.FindByIdAsync(roleViewModel.Id).Result;

            if (role != null)
            {
                role.Name = roleViewModel.Name;
                var result = _roleManager.UpdateAsync(role).Result;
                if (result.Succeeded)
                {
                    TempData.Put("message", new ResultMessage()
                    {
                        Title = "Başarılı.",
                        Message = "Güncelleme İşlemi Yapıldı.",
                        Css = "success"
                    });

                    return RedirectToAction("Index", "Roles");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {

                        TempData.Put("message", new ResultMessage()
                        {
                            Title = "Hata",
                            Message = item.Description,
                            Css = "danger"
                        });

                    }
                    return RedirectToAction("Index", "Roles");

                }
            }
            else
            {
                TempData.Put("message", new ResultMessage()
                {
                    Title = "Hata",
                    Message = "Güncelleme İşlemi Başarısız Oldu.",
                    Css = "danger"
                });

                return RedirectToAction("Index", "Roles");

            }

        }
        public IActionResult Detail(string Id)
        {
            var role = _roleManager.FindByIdAsync((string)Id).Result;

            if (role != null)
            {
                var entity = new RoleModel()
                {
                    Id = role.Id,
                    Name = role.Name
                };

                return PartialView("Detail", entity);
            }
            else
            {
                return RedirectToAction("Roles");
            }
        }
        [HttpPost]
        public IActionResult RoleDelete(string Id)
        {
            var role = _roleManager.FindByIdAsync(Id).Result;
            if (role != null)
            {
                var result = _roleManager.DeleteAsync(role).Result;
                if (result.Succeeded)
                {
                    TempData.Put("message", new ResultMessage()
                    {
                        Title = "BAŞARILI",
                        Message = "Role Başarılı Bir Şekilde Silinmiştir.",
                        Css = "success"
                    });
                    return RedirectToAction("Index", "Roles");
                }
                else
                {
                    ViewBag.ErrorMessage = "Bir Hata Oluştu. Lütfen Tekrar Deneyiniz.";
                    return RedirectToAction("Index", "Roles");
                }
            }
            return RedirectToAction("Index", "Roles");
        }

        public static List<ClaimModel> ClaimsList = new List<ClaimModel>(){
        new ClaimModel(){Id="1",Type="Administrator", Value="admin"},
        new ClaimModel(){Id="2",Type="Editor", Value="editor"},
        new ClaimModel(){Id="3",Type="Create", Value="create"},
        new ClaimModel(){Id="4",Type="Edit", Value="edit"},
        new ClaimModel(){Id="5",Type="Delete", Value="delete"},
        new ClaimModel(){Id="6",Type="View", Value="view"},
        new ClaimModel(){Id="7",Type="List", Value="list"},
        };

        [Authorize]
        public async Task<IActionResult> RoleClaimsAssign(string Id)
        {
            var role = await _roleManager.FindByIdAsync((string)Id);

            var claims = ClaimsList;


            List<string> roleclaims = new List<string>();

            var claimslist = _roleClaimsService.GetListByRoleId(Id);
            if (claimslist.Success)
            {
                foreach (var item in claimslist.Data)
                {
                    roleclaims.Add(item.ClaimValue);
                }
            }



            List<RoleClaimsAssignViewModel> roleClaimsAssignViewModels = new List<RoleClaimsAssignViewModel>();



            foreach (var claim in claims)
            {
                RoleClaimsAssignViewModel r = new RoleClaimsAssignViewModel();

                r.Id = claim.Id;
                r.RoleId = role.Id;
                r.ClaimType = claim.Type;
                r.ClaimValue = claim.Value;

                if (roleclaims != null)
                {
                    if (roleclaims.Contains(claim.Value))
                    { r.Exist = true; }
                    else
                    { r.Exist = false; }
                }
                else
                {
                    r.Exist = false;

                }
                roleClaimsAssignViewModels.Add(r);
            }

            return View(roleClaimsAssignViewModels);
        }

        [HttpPost]
        public async Task<IActionResult> RoleClaimsAssign(List<RoleClaimsAssignViewModel> roleClaimsAssignViewModels)
        {
            foreach (var item in roleClaimsAssignViewModels)
            {
                var role = await _roleManager.FindByIdAsync(item.RoleId);

                if (item.Exist)
                {

                    await _roleManager.AddClaimAsync(role, new System.Security.Claims.Claim(item.ClaimType, item.ClaimValue));
                }
                else
                {
                    await _roleManager.RemoveClaimAsync(role, new System.Security.Claims.Claim(item.ClaimType, item.ClaimValue));
                }
            }
            return RedirectToAction("Index");
        }

    }
}
