using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eticaret.Business.Abstract;
using Eticaret.Core.Entities.ComplexTypes;
using Eticaret.Core.Utilities.Messages;
using Eticaret.UI.Areas.ysadmin.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Eticaret.Core.Extensions;
using Eticaret.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Mapster;

namespace Eticaret.UI.Areas.ysadmin.Controllers
{
    [Area("ysadmin")]

    public class BannerController : Controller
    {
        IBannerService _bannerService;

        public BannerController(IBannerService bannerService)
        {
            _bannerService = bannerService;
        }

        public IActionResult Index(int page = 1)
        {

            const int pageSize = 10;
            var lists = _bannerService.ListBannerPaging(page, pageSize);
            if (lists.Success)
            {
                var models = new BannerListViewModel()
                {
                    Banners = lists.Data,
                    PagingInfo = new PagingInfo()
                    {
                        CurrentPage = page,
                        ItemsPerPage = pageSize,
                        TotalItems = _bannerService.CountBanners().Data,
                    }
                };

                return View(models);
            }

            else
            {
                TempData.Put("message", new ResultMessage()
                {
                    Title = ProsesMessages.TitleError,
                    Message = ProsesMessages.MessageError,
                    Css = ProsesMessages.CssError,
                });

                return View();
            }
        }
        [HttpGet]
        public IActionResult Create()
        {
            BannerListViewModel model = new BannerListViewModel()
            {
                Banner = new Banner()
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(BannerListViewModel model, IFormFile imgPath)
        {

            Banner entity = model.Banner.Adapt<Banner>();


            var ImgFile = await DosyaCreateExtensions.ImgCreate(imgPath, "banner", model.Banner.title);
            entity.imgPath = ImgFile;

            entity.url = Replace.UrlAndTitleReplace(model.Banner.url == null ? model.Banner.title : model.Banner.url);



            var result = _bannerService.Create(entity);
            if (result.Success)
            {
                TempData.Put("message", new ResultMessage()
                {
                    Title = ProsesMessages.TitleSuccess,
                    Message = ProsesMessages.MessageCreate,
                    Css = ProsesMessages.CssSuccess,
                });

                return RedirectToAction("Index");
            }
            else
            {
                return View("Index", result);
            }
        }
        [HttpPost]
        public IActionResult ViewPreview(int? Id)
        {
            var detail = _bannerService.GetBannerBybannerId((int)Id);
            if (detail.Success)
            {
                BannerListViewModel _Detail = detail.Data.Adapt<BannerListViewModel>();

                _Detail.Banner = detail.Data;

                return PartialView("ViewPreview", _Detail);
            }
            else
            {
                TempData.Put("message", new ResultMessage()
                {
                    Title = ProsesMessages.TitleError,
                    Message = detail.Message,
                    Css = ProsesMessages.CssError
                });
                BannerListViewModel _Detail = detail.Adapt<BannerListViewModel>();
                return PartialView("ViewPreview", _Detail);
            }
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            var entity_model = _bannerService.GetBannerBybannerId((int)id);
            if (entity_model.Success)
            {
                Banner entity = entity_model.Data.Adapt<Banner>();
                var modeldelete = _bannerService.Delete(entity);
                if (modeldelete.Success)
                {
                    TempData.Put("message", new ResultMessage()
                    {
                        Title = ProsesMessages.TitleSuccess,
                        Message = ProsesMessages.MessageDelete,
                        Css = ProsesMessages.CssWarning,
                    });
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
            else
            {
                TempData.Put("message", new ResultMessage()
                {
                    Title = ProsesMessages.TitleError,
                    Message = ProsesMessages.MessageError,
                    Css = ProsesMessages.CssError,
                });
            }

            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var banner = _bannerService.GetBannerBybannerId((int)id);
            if (banner.Data == null)
            {
                return NotFound();
            }
            if (banner.Success)
            {
                BannerListViewModel model = new BannerListViewModel()
                {
                    Banner = banner.Data.Adapt<Banner>(),
                };

                model.Banner.url = Replace.UrlAndTitleReplace(model.Banner.url == null ? model.Banner.title : model.Banner.url);

                return View(model);
            }
            else
            {
                return NotFound();
            }



        }
        [HttpPost]
        public async Task<IActionResult> Edit(BannerListViewModel model, IFormFile imgPath)
        {
            var editmodel = _bannerService.GetBannerBybannerId(model.Banner.bannerId);
            if (editmodel.Success)
            {
                Banner entity = model.Banner.Adapt<Banner>();

                if (imgPath != null)
                {
                    var ImgFile = await DosyaCreateExtensions.ImgCreate(imgPath, "banner", model.Banner.title);
                    entity.imgPath = ImgFile;
                }
                else
                {
                    entity.imgPath = model.Banner.imgPath;
                }
                var updatemodel = _bannerService.Update(entity);

                if (updatemodel.Success)
                {
                    TempData.Put("message", new ResultMessage()
                    {
                        Title = ProsesMessages.TitleSuccess,
                        Message = updatemodel.Message,
                        Css = ProsesMessages.CssSuccess,
                    });

                }
                else
                {
                    TempData.Put("message", new ResultMessage()
                    {
                        Title = ProsesMessages.TitleError,
                        Message = updatemodel.Message,
                        Css = ProsesMessages.CssError,
                    });


                    return View(model);

                }

                return RedirectToAction("Index");

            }
            else
            {
                TempData.Put("message", new ResultMessage()
                {
                    Title = ProsesMessages.TitleError,
                    Message = ProsesMessages.MessageNoData,
                    Css = ProsesMessages.CssError,
                });

                return RedirectToAction("Index");
            }

        }
        [HttpPost]
        public IActionResult Active(bool active, int id)
        {
            var modelactive = _bannerService.GetBannerBybannerId((int)id);

            BannerListViewModel model = new BannerListViewModel()
            {
                Banner = modelactive.Data
            };


            if (active == true)
            {
                model.Banner.status = false;
            }
            if (active == false)
            {
                model.Banner.status = true;
            }

            var resultUpdate = _bannerService.Update(model.Banner);
            if (resultUpdate.Success)
            {
                TempData.Put("message", new ResultMessage()
                {
                    Title = ProsesMessages.TitleSuccess,
                    Message = $"" + ProsesMessages.MessageEdit,
                    Css = ProsesMessages.CssSuccess
                });
            }
            return RedirectToAction("Index");
        }
    }
}
