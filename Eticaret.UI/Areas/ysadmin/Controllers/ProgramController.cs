using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eticaret.Business.Abstract;
using Eticaret.Core.Entities.ComplexTypes;
using Eticaret.Core.Utilities.Messages;
using Microsoft.AspNetCore.Mvc;
using Eticaret.Core.Extensions;
using Eticaret.UI.Areas.ysadmin.ViewModels;
using Eticaret.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Mapster;
using Microsoft.AspNetCore.Mvc.Rendering;
using Eticaret.Business.Abstract.Admin;

namespace Eticaret.UI.Areas.ysadmin.Controllers
{
    [Area("ysadmin")]

    public class ProgramController : Controller
    {
        IProgramService _programService;
        IRadioApiService _radioApiService;

        public ProgramController(IProgramService programService, IRadioApiService radioApiService)
        {
            _programService = programService;
            _radioApiService = radioApiService;

        }

        public IActionResult Index(int limit, string metin, int radioApiId, int page = 1)
        {
            if (limit == 0)
            {
                limit = 10;
            }

            //const int pageSize = 10;
            var programs = _programService.ListProgramWithRadioApiPagingByradioApiIdAndArama(metin, radioApiId, page, limit);

            if (programs.Success)
            {
                var models = new ProgramListViewModel()
                {
                    title = "Program Listesi",
                    Programs = programs.Data,
                    PagingInfo = new PagingInfo()
                    {
                        CurrentPage = page,
                        ItemsPerPage = limit,
                        TotalItems = _programService.CountProgramByradioApiId(radioApiId).Data,
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
            List<Eticaret.Entities.Concrete.Program> radioapi = new List<Eticaret.Entities.Concrete.Program>();
            ProgramListViewModel model = new ProgramListViewModel()
            {
                title = "YENİ PROFRAM OLUŞTUR",
                RadiosApi = new SelectList(_radioApiService.ListWebRadio().Data, "radioApiId", "title", "--Select--"),
                Program = new Eticaret.Entities.Concrete.Program(),
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProgramListViewModel model, IFormFile imgPath)
        {
            Eticaret.Entities.Concrete.Program entity = model.Program.Adapt<Eticaret.Entities.Concrete.Program>();
            var ImgFile = await DosyaCreateExtensions.ImgCreate(imgPath, "program", model.Program.title);
            entity.imgPath = ImgFile;
            entity.url = Replace.UrlAndTitleReplace(model.Program.url == null ? model.Program.title : model.Program.url);
            var result = _programService.Create(entity);
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

            var program = _programService.GetProgramByprogramId((int)id);
            if (program.Data == null)
            {
                return NotFound();
            }
            if (program.Success)
            {
                var model = new ProgramListViewModel()
                {
                    title = program.Data.Adapt<Eticaret.Entities.Concrete.Program>().title,
                    Program = program.Data.Adapt<Eticaret.Entities.Concrete.Program>(),
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
        public async Task<IActionResult> Edit(ProgramListViewModel model, IFormFile imgPath)
        {
            var editmodel = _programService.GetProgramByprogramId(model.Program.programId);
            if (editmodel.Success)
            {
                Eticaret.Entities.Concrete.Program entity = model.Program.Adapt<Eticaret.Entities.Concrete.Program>();

                if (imgPath != null)
                {
                    var ImgFile = await DosyaCreateExtensions.ImgCreate(imgPath, "program", model.Program.title);
                    entity.imgPath = ImgFile;
                }

                entity.url = Replace.UrlAndTitleReplace(model.Program.url == null ? model.Program.title : model.Program.url);



                var updatemodel = _programService.Update(entity);
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
            var detail = _programService.GetProgramByprogramId((int)Id);
            if (detail.Success)
            {
                ProgramListViewModel _Detail = detail.Data.Adapt<ProgramListViewModel>();
                _Detail.Program = detail.Data;

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
                ProgramListViewModel _Detail = detail.Adapt<ProgramListViewModel>();
                return PartialView("ViewPreview", _Detail);
            }
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            var deletemodel = _programService.GetProgramByprogramId((int)id);
            if (deletemodel.Success)
            {
                Eticaret.Entities.Concrete.Program entity = deletemodel.Data.Adapt<Eticaret.Entities.Concrete.Program>();
                var modeldelete = _programService.Delete(entity);
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
            var modelactive = _programService.GetProgramByprogramId((int)id);

            ProgramListViewModel model = new ProgramListViewModel()
            {
                Program = modelactive.Data
            };


            if (active == true)
            {
                model.Program.status = false;
            }
            if (active == false)
            {
                model.Program.status = true;
            }

            var resultUpdate = _programService.Update(model.Program);
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
