using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eticaret.Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Eticaret.Core.Extensions;
using Eticaret.UI.Areas.ysadmin.ViewModels;
using Eticaret.Core.Entities.ComplexTypes;
using Eticaret.Core.Utilities.Messages;
using Eticaret.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Mapster;
using Eticaret.Business.Abstract.Admin;

namespace Eticaret.UI.Areas.ysadmin.Controllers
{
    [Area("ysadmin")]

    public class RadioApiController : Controller
    {
        IRadioApiService _radioApiService;

        public RadioApiController(IRadioApiService radioApiService)
        {
            _radioApiService = radioApiService;
        }

        public IActionResult Index(int page = 1)
        {
            const int pageSize = 10;
            var radioapi = _radioApiService.ListRadioApiPaging(page, pageSize);

            if (radioapi.Success)
            {
                var models = new RadioApiListeViewModel()
                {
                    title = "Radio Api Listesi",
                    RadiosApi = radioapi.Data,
                    PagingInfo = new PagingInfo()
                    {
                        CurrentPage = page,
                        ItemsPerPage = pageSize,
                        TotalItems = _radioApiService.CountWebRadio().Data,
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
        public IActionResult Create()
        {
            List<RadioApi> radioapi = new List<RadioApi>();

            RadioApiListeViewModel model = new RadioApiListeViewModel()
            {
                title = "Yeni Web Api Ekleme",
                RadioApi = new RadioApi(),
            };

            return View(model);
        }
        [HttpPost]
        public IActionResult Create(RadioApiListeViewModel model, IFormFile imgPath)
        {
            RadioApi entity = model.RadioApi.Adapt<RadioApi>();

        
            var result = _radioApiService.Create(entity);

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

            var radioapi = _radioApiService.GetWebRadioBywebRadioId((int)id);
            if (radioapi.Data == null)
            {
                return NotFound();
            }
            if (radioapi.Success)
            {
                var model = new RadioApiListeViewModel()
                {
                    title = radioapi.Data.title,
                    RadioApi = radioapi.Data.Adapt<RadioApi>(),
                };

                return View(model);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult Edit(RadioApiListeViewModel model, IFormFile imgPath)
        {
            var editmodel = _radioApiService.GetWebRadioBywebRadioId(model.RadioApi.radioApiId);
            if (editmodel.Success)
            {
                RadioApi entity = model.RadioApi.Adapt<RadioApi>();

                
                var updatemodel = _radioApiService.Update(entity);
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
            var detail = _radioApiService.GetWebRadioBywebRadioId((int)Id);
            if (detail.Success)
            {
                RadioApiListeViewModel _Detail = detail.Data.Adapt<RadioApiListeViewModel>();
                _Detail.RadioApi = detail.Data;

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
                RadioApiListeViewModel _Detail = detail.Adapt<RadioApiListeViewModel>();
                return PartialView("ViewPreview", _Detail);
            }
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            var deletemodel = _radioApiService.GetWebRadioBywebRadioId((int)id);
            if (deletemodel.Success)
            {
                RadioApi entity = deletemodel.Data.Adapt<RadioApi>();
                var modeldelete = _radioApiService.Delete(entity);
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
            var modelactive = _radioApiService.GetWebRadioBywebRadioId((int)id);

            RadioApiListeViewModel model = new RadioApiListeViewModel()
            {
                RadioApi = modelactive.Data
            };


            if (active == true)
            {
                model.RadioApi.status = false;
            }
            if (active == false)
            {
                model.RadioApi.status = true;
            }

            var resultUpdate = _radioApiService.Update(model.RadioApi);
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
        public IActionResult ActiveProgram(bool active, int id)
        {
            var modelactive = _radioApiService.GetWebRadioBywebRadioId((int)id);

            RadioApiListeViewModel model = new RadioApiListeViewModel()
            {
                RadioApi = modelactive.Data
            };


            if (active == true)
            {
                model.RadioApi.programStatus = false;
            }
            if (active == false)
            {
                model.RadioApi.programStatus = true;
            }

            var resultUpdate = _radioApiService.Update(model.RadioApi);
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
        public IActionResult ActiveTopmusiclist(bool active, int id)
        {
            var modelactive = _radioApiService.GetWebRadioBywebRadioId((int)id);

            RadioApiListeViewModel model = new RadioApiListeViewModel()
            {
                RadioApi = modelactive.Data
            };


            if (active == true)
            {
                model.RadioApi.topmusiclistStatus = false;
            }
            if (active == false)
            {
                model.RadioApi.topmusiclistStatus = true;
            }

            var resultUpdate = _radioApiService.Update(model.RadioApi);
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
        public IActionResult ActivePodcast(bool active, int id)
        {
            var modelactive = _radioApiService.GetWebRadioBywebRadioId((int)id);

            RadioApiListeViewModel model = new RadioApiListeViewModel()
            {
                RadioApi = modelactive.Data
            };


            if (active == true)
            {
                model.RadioApi.podcastStatus = false;
            }
            if (active == false)
            {
                model.RadioApi.podcastStatus = true;
            }

            var resultUpdate = _radioApiService.Update(model.RadioApi);
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

        public IActionResult ActiveBroadcast(bool active, int id)
        {
            var modelactive = _radioApiService.GetWebRadioBywebRadioId((int)id);

            RadioApiListeViewModel model = new RadioApiListeViewModel()
            {
                RadioApi = modelactive.Data
            };


            if (active == true)
            {
                model.RadioApi.broadcastStatus = false;
            }
            if (active == false)
            {
                model.RadioApi.broadcastStatus = true;
            }

            var resultUpdate = _radioApiService.Update(model.RadioApi);
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
        public IActionResult ActiveFrequency(bool active, int id)
        {
            var modelactive = _radioApiService.GetWebRadioBywebRadioId((int)id);

            RadioApiListeViewModel model = new RadioApiListeViewModel()
            {
                RadioApi = modelactive.Data
            };


            if (active == true)
            {
                model.RadioApi.frequencyStatus = false;
            }
            if (active == false)
            {
                model.RadioApi.frequencyStatus = true;
            }

            var resultUpdate = _radioApiService.Update(model.RadioApi);
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
        public IActionResult ActiveDj(bool active, int id)
        {
            var modelactive = _radioApiService.GetWebRadioBywebRadioId((int)id);

            RadioApiListeViewModel model = new RadioApiListeViewModel()
            {
                RadioApi = modelactive.Data
            };


            if (active == true)
            {
                model.RadioApi.djStatus = false;
            }
            if (active == false)
            {
                model.RadioApi.djStatus = true;
            }

            var resultUpdate = _radioApiService.Update(model.RadioApi);
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
