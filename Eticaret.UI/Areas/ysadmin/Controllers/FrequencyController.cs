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
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Eticaret.UI.Areas.ysadmin.Controllers
{
    [Area("ysadmin")]

    public class FrequencyController : Controller
    {
        IFrequencyService _FrequencyService;
        IRadioApiService _radioApiService;

        public FrequencyController(IFrequencyService FrequencyService, IRadioApiService radioApiService)
        {
            _FrequencyService = FrequencyService;
            _radioApiService = radioApiService;

        }

        public IActionResult Index(int limit, string metin, int radioApiId, int page = 1)
        {
            if (limit == 0)
            {
                limit = 10;
            }
            //const int pageSize = 10;
            var Frequencys = _FrequencyService.ListFrequencyWithRadioApiPagingByradioApiIdAndArama(metin, radioApiId, page, limit);
            if (Frequencys.Success)
            {
                var models = new FrequencyListViewModel()
                {
                    title = "Radyo Frekans Listesi",
                    Frequencys = Frequencys.Data,
                    //RadiosApi = new SelectList(_radioApiService.ListWebRadio().Data, "radioApiId", "title"),
                    PagingInfo = new PagingInfo()
                    {
                        CurrentPage = page,
                        ItemsPerPage = limit,
                        TotalItems = _FrequencyService.CountFrequencyByradioApiId(radioApiId).Data,
                        //CurrentCategory = radioApiId
                    }
                };
                List<SelectListItem> note = new List<SelectListItem>();
                note.Insert(0, new SelectListItem() { Value = "0", Text = " --- Radyo Seçiniz --- " });
                foreach (var item in _radioApiService.ListWebRadio().Data)
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
            List<Frequency> radioapi = new List<Frequency>();
            FrequencyListViewModel model = new FrequencyListViewModel()
            {
                title = "Yeni Radyo Frekansı Ekleme",
                RadiosApi = new SelectList(_radioApiService.ListWebRadio().Data, "radioApiId", "title", " --Select-- "),
                Frequency = new Frequency(),
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(FrequencyListViewModel model, IFormFile imgPath)
        {
            Frequency entity = model.Frequency.Adapt<Frequency>();


            var ImgFile = await DosyaCreateExtensions.ImgCreate(imgPath, "frekanslar", model.Frequency.cityName);
            entity.imgPath = ImgFile;



            var result = _FrequencyService.Create(entity);

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
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Frequency = _FrequencyService.GetFrequencyByFrequencyId((int)id);
            if (Frequency.Data == null)
            {
                return NotFound();
            }
            if (Frequency.Success)
            {
                var model = new FrequencyListViewModel()
                {
                   title = Frequency.Data.Adapt<Frequency>().cityName,
                   Frequency = Frequency.Data.Adapt<Frequency>(),
                   RadiosApi = new SelectList(_radioApiService.ListWebRadio().Data, "radioApiId", "title"),
                };

                return View(model);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(FrequencyListViewModel model, IFormFile imgPath)
        {
            var editmodel = _FrequencyService.GetFrequencyByFrequencyId(model.Frequency.frequencyId);
            if (editmodel.Success)
            {
                Frequency entity = model.Frequency.Adapt<Frequency>();

                if (imgPath != null)
                {
                    var ImgFile = await DosyaCreateExtensions.ImgCreate(imgPath, "frekanslar", model.Frequency.cityName);
                    entity.imgPath = ImgFile;
                }


                var updatemodel = _FrequencyService.Update(entity);
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
            var detail = _FrequencyService.GetFrequencyByFrequencyId((int)Id);
            if (detail.Success)
            {
                FrequencyListViewModel _Detail = detail.Data.Adapt<FrequencyListViewModel>();
                _Detail.Frequency = detail.Data;

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
                FrequencyListViewModel _Detail = detail.Adapt<FrequencyListViewModel>();
                return PartialView("ViewPreview", _Detail);
            }
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            var deletemodel = _FrequencyService.GetFrequencyByFrequencyId((int)id);
            if (deletemodel.Success)
            {
                Frequency entity = deletemodel.Data.Adapt<Frequency>();
                var modeldelete = _FrequencyService.Delete(entity);
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
            var modelactive = _FrequencyService.GetFrequencyByFrequencyId((int)id);

            FrequencyListViewModel model = new FrequencyListViewModel()
            {
                Frequency = modelactive.Data
            };


            if (active == true)
            {
                model.Frequency.status = false;
            }
            if (active == false)
            {
                model.Frequency.status = true;
            }

            var resultUpdate = _FrequencyService.Update(model.Frequency);
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
