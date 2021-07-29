using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eticaret.Business.Abstract;
using Eticaret.Core.Entities.ComplexTypes;
using Eticaret.Core.Utilities.Messages;
using Eticaret.UI.Areas.ysadmin.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Eticaret.Core.Extensions;
using Mapster;
using Eticaret.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Eticaret.Business.Abstract.Admin;

namespace Eticaret.UI.Areas.ysadmin.Controllers
{
    [Area("ysadmin")]

    public class DjController : Controller
    {
        IDjService _djService;
        IRadioApiService _webRadioService;

        public DjController(IDjService djService, IRadioApiService webRadioService)
        {
            _djService = djService;
            _webRadioService = webRadioService;

        }

        public IActionResult Index(int limit, string metin, int radioApiId, int page = 1)
        {
            if (limit == 0)
            {
                limit = 10;
            }

            //const int pageSize = 10;
            var djs = _djService.ListDjWithRadioApiPagingByradioApiIdAndArama(metin, radioApiId, page, limit);

            if (djs.Success)
            {
                var models = new DjListViewModel()
                {
                    title = "Dj Listesi",
                    Djs = djs.Data,
                    //RadiosApi = new SelectList(_radioApiService.ListWebRadio().Data, "radioApiId", "title"),
                    PagingInfo = new PagingInfo()
                    {
                        CurrentPage = page,
                        ItemsPerPage = limit,
                        TotalItems = _djService.CountDjByradioApiId(radioApiId).Data,
                        //CurrentCategory = radioApiId
                    }
                };
                List<SelectListItem> note = new List<SelectListItem>();
                note.Insert(0, new SelectListItem() { Value = "0", Text = " --- Radyo Seçiniz --- " });
                foreach (var item in _webRadioService.ListWebRadio().Data)
                {
                    var selectList = new SelectListItem
                    {
                        Text = item.title,
                        Value = item.radioApiId.ToString(),
                    };
                    note.Add(selectList);
                }
                models.RadiosApi = note;

                if (!string.IsNullOrEmpty(metin))
                {
                    models.Search = metin;
                }


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
        public IActionResult Create()
        {
            List<DjRadio> webRadios = new List<DjRadio>();

            DjListViewModel model = new DjListViewModel()
            {
                title = "Yeni Dj Ekleme",
                SelectedWebRadios = webRadios,
                WebRadios = _webRadioService.ListWebRadio().Data,

                RadiosApi = new SelectList(_webRadioService.ListWebRadio().Data, "radioApiId", "title", " --Select-- "),
                Dj = new Dj(),
            };



            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(DjListViewModel model, int[] categoryIds, IFormFile imgPath)
        {
            Dj entity = model.Dj.Adapt<Dj>();


            var ImgFile = await DosyaCreateExtensions.ImgCreate(imgPath, "dj", model.Dj.title);
            entity.imgPath = ImgFile;


            entity.url = Replace.UrlAndTitleReplace(model.Dj.url == null ? model.Dj.title : model.Dj.url);

            var result = _djService.Create(entity);

            if (result.Success)
            {
                var newsradio = _djService.DjRadioCreate(entity, categoryIds);

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
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dj = _djService.GetDjBydjId((int)id);
            if (dj.Data == null)
            {
                return NotFound();
            }
            if (dj.Success)
            {
                var model = new DjListViewModel()
                {
                    WebRadios = _webRadioService.ListWebRadio().Data,
                    SelectedWebRadios = _djService.GetDjBydjId(dj.Data.djId).Data.DjsRadios.ToList(),
                    title = dj.Data.Adapt<Dj>().title,
                    Dj = dj.Data.Adapt<Dj>(),
                };

                return View(model);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(DjListViewModel model, int[] categoryIds, IFormFile imgPath)
        {
            var editmodel = _djService.GetDjBydjId(model.Dj.djId);
            if (editmodel.Success)
            {
                Dj entity = model.Dj.Adapt<Dj>();

                if (imgPath != null)
                {
                    var ImgFile = await DosyaCreateExtensions.ImgCreate(imgPath, "dj", model.Dj.title);
                    entity.imgPath = ImgFile;
                }

                entity.url = Replace.UrlAndTitleReplace(model.Dj.url == null ? model.Dj.title : model.Dj.url);

                var updatemodel = _djService.DjRadioUpdate(entity, categoryIds);

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
        public IActionResult ViewPreview(int? Id)
        {
            var detail = _djService.GetDjBydjId((int)Id);
            if (detail.Success)
            {
                DjListViewModel _Detail = detail.Data.Adapt<DjListViewModel>();
                _Detail.Dj = detail.Data;

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
                DjListViewModel _Detail = detail.Adapt<DjListViewModel>();
                return PartialView("ViewPreview", _Detail);
            }
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            var deletemodel = _djService.GetDjBydjId((int)id);
            if (deletemodel.Success)
            {
                Dj entity = deletemodel.Data.Adapt<Dj>();
                var modeldelete = _djService.Delete(entity);
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
        [HttpPost]
        public IActionResult Active(bool active, int id)
        {
            var modelactive = _djService.GetDjBydjId((int)id);

            DjListViewModel model = new DjListViewModel()
            {
                Dj = modelactive.Data
            };


            if (active == true)
            {
                model.Dj.status = false;
            }
            if (active == false)
            {
                model.Dj.status = true;
            }

            var resultUpdate = _djService.Update(model.Dj);
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
