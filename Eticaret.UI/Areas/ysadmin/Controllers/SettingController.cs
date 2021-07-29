using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eticaret.Business.Abstract;
using Eticaret.Business.Abstract.Admin;
using Eticaret.Core.Entities.ComplexTypes;
using Eticaret.Core.Extensions;
using Eticaret.Core.Utilities.Messages;
using Eticaret.Entities.Concrete;
using Eticaret.UI.Areas.ysadmin.ViewModels;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eticaret.UI.Areas.ysadmin.Controllers
{
    [Area("ysadmin")]

    public class SettingController : Controller
    {
        ISettingService _settingService;

        public SettingController(ISettingService settingService)
        {
            _settingService = settingService;
        }

        public IActionResult Index()
        {
            var setting = _settingService.GetOne();
            if (setting.Success)
            {
                if (setting.Data != null)
                {
                    SettingListViewModel entity = setting.Data.Adapt<SettingListViewModel>();

                    return View(entity);
                }
                else
                {
                    SettingListViewModel model = new SettingListViewModel();
                    return View(model);
                }
            }
            else
            {
                SettingListViewModel model = new SettingListViewModel();
                return View(model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Index(SettingListViewModel model, IFormFile logoPath, IFormFile footerLogoPath)
        {
            var entity = new Setting()
            {
                settingId=model.settingId,
                title=model.title,
                slogan = model.slogan,
                keywords = model.keywords,
                description = model.description,
                status =model.status
            };

            if (logoPath != null)
            {
                var weblogo = await DosyaCreateExtensions.ImgCreate(logoPath, "logo", model.title);
                entity.logoPath = weblogo;
            }
            else
            {
                entity.logoPath = model.logoPath;
            }

            if (footerLogoPath != null)
            {
                var webfooterlogo = await DosyaCreateExtensions.ImgCreate(footerLogoPath, "logo", model.title);
                entity.footerLogoPath = webfooterlogo;

            }
            else
            {
                entity.footerLogoPath = model.footerLogoPath;
            }
           

            if (model.settingId == 0)
            {

                var setting = _settingService.Create(entity);
                if (setting.Success)
                {
                    TempData.Put("message", new ResultMessage()
                    {
                        Title = ProsesMessages.TitleSuccess,
                        Message = $"{model.title} isimli Ayarlar Kaydedildi.",
                        Css = ProsesMessages.CssSuccess,
                    });
                    return RedirectToAction("Index", "Setting");
                }
                else
                {
                    TempData.Put("message", new ResultMessage()
                    {
                        Title = ProsesMessages.TitleError,
                        Message =ProsesMessages.MessageError,
                        Css = ProsesMessages.CssError,
                    });
                }
            }
            else
            {
                var setting = _settingService.Update(entity);
                if (setting.Success)
                {
                    TempData.Put("message", new ResultMessage()
                    {
                        Title = ProsesMessages.TitleSuccess,
                        Message = $"{model.title} isimli Ayarlar Güncellendi.",
                        Css = ProsesMessages.CssSuccess,
                    });
                    return RedirectToAction("Index", "Setting");
                }
                else
                {
                    TempData.Put("message", new ResultMessage()
                    {
                        Title = ProsesMessages.TitleError,
                        Message = ProsesMessages.MessageError,
                        Css = ProsesMessages.CssError,
                    });
                }
            }

            return View(entity);


        }

     }
}
