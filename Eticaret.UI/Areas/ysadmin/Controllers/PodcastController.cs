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
using Eticaret.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Mapster;
using Eticaret.Business.Abstract.Admin;

namespace Eticaret.UI.Areas.ysadmin.Controllers
{
    [Area("ysadmin")]
    public class PodcastController : Controller
    {
        IProgramService _programService;
        IPodcastMusicListService _podcastMusicListService;

        IRadioApiService _radioApiService;

        public PodcastController(IProgramService programService, IRadioApiService radioApiService, IPodcastMusicListService podcastMusicListService)
        {
            _programService = programService;
            _podcastMusicListService = podcastMusicListService;
            _radioApiService = radioApiService;
        }

        public IActionResult Index(DateTime SDate, DateTime FDate, int limit, string metin, int programId, int page = 1)
        {
            if (limit == 0)
            {
                limit = 10;
            }

            //const int pageSize = 10;
            var lists = _podcastMusicListService.ListPodcastMusicListWithProgramPagingByprogramIdAndDataArama(SDate, FDate, metin, programId, page, limit);

            if (lists.Success)
            {
                var models = new PodcastMusicListListViewModel()
                {
                    title = "Podcast Listesi",
                    PodcastMusicLists = lists.Data,

                    PagingInfo = new PagingInfo()
                    {
                        CurrentPage = page,
                        ItemsPerPage = limit,
                        TotalItems = _podcastMusicListService.CountPodcastMusicListByProgramId(programId).Data,
                        //CurrentCategory = radioApiId

                    }
                };
                List<SelectListItem> note = new List<SelectListItem>();
                note.Insert(0, new SelectListItem() { Value = "0", Text = " --- Program Seçiniz --- " });
                foreach (var item in _programService.ListProgram().Data)
                {
                    var selectList = new SelectListItem
                    {
                        Text = item.title,
                        Value = item.programId.ToString(),
                    };
                    note.Add(selectList);
                }
                models.Programs = note;

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
            List<PodcastMusicList> radioapi = new List<PodcastMusicList>();

            PodcastMusicListListViewModel model = new PodcastMusicListListViewModel()
            {
                title = "Yeni Podcast Ekleme",
                Programs = new SelectList(_programService.ListProgram().Data, "programId", "title", " --Select-- "),
                PodcastMusicList = new PodcastMusicList(),
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(PodcastMusicListListViewModel model, IFormFile soundPath)
        {
            PodcastMusicList entity = model.PodcastMusicList.Adapt<PodcastMusicList>();


            var SoundFile = await DosyaCreateExtensions.Mp3Create(soundPath, "Podcast", model.PodcastMusicList.title);
            entity.soundPath = SoundFile;


            var result = _podcastMusicListService.Create(entity);

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

            var edit = _podcastMusicListService.GetPodcastMusicListByPodcastMusicListId((int)id);
            if (edit.Data == null)
            {
                return NotFound();
            }
            if (edit.Success)
            {
                var model = new PodcastMusicListListViewModel()
                {
                    title = edit.Data.Adapt<PodcastMusicList>().title,
                    PodcastMusicList = edit.Data.Adapt<PodcastMusicList>(),
                    Programs = new SelectList(_programService.ListProgram().Data, "programId", "title"),
                };

                return View(model);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(PodcastMusicListListViewModel model, IFormFile soundPath)
        {
            var editmodel = _podcastMusicListService.GetPodcastMusicListByPodcastMusicListId(model.PodcastMusicList.podcastMusicListId);
            if (editmodel.Success)
            {
                PodcastMusicList entity = model.PodcastMusicList.Adapt<PodcastMusicList>();

                if (soundPath != null)
                {
                    var SoundFile = await DosyaCreateExtensions.Mp3Create(soundPath, "Podcast", model.PodcastMusicList.title);
                    entity.soundPath = SoundFile;
                }

                var updatemodel = _podcastMusicListService.Update(entity);
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
            var detail = _podcastMusicListService.GetPodcastMusicListByPodcastMusicListId((int)Id);
            if (detail.Success)
            {
                PodcastMusicListListViewModel _Detail = detail.Data.Adapt<PodcastMusicListListViewModel>();
                _Detail.PodcastMusicList = detail.Data;

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
                PodcastMusicListListViewModel _Detail = detail.Adapt<PodcastMusicListListViewModel>();
                return PartialView("ViewPreview", _Detail);
            }
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            var deletemodel = _podcastMusicListService.GetPodcastMusicListByPodcastMusicListId((int)id);
            if (deletemodel.Success)
            {
                PodcastMusicList entity = deletemodel.Data.Adapt<PodcastMusicList>();
                var modeldelete = _podcastMusicListService.Delete(entity);
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
            var modelactive = _podcastMusicListService.GetPodcastMusicListByPodcastMusicListId((int)id);

            PodcastMusicListListViewModel model = new PodcastMusicListListViewModel()
            {
                PodcastMusicList = modelactive.Data
            };


            if (active == true)
            {
                model.PodcastMusicList.status = false;
            }
            if (active == false)
            {
                model.PodcastMusicList.status = true;
            }

            var resultUpdate = _podcastMusicListService.Update(model.PodcastMusicList);
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
