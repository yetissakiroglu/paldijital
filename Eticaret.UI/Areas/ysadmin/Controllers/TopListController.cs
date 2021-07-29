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

    public class TopListController : Controller
    {
        ITopMusicListService _topMusicListService;
        IRadioApiService _radioApiService;
        IMusicListService _musicListService;

        public TopListController(ITopMusicListService topMusicListService, IRadioApiService radioApiService, IMusicListService musicListService)
        {
            _topMusicListService = topMusicListService;
            _radioApiService = radioApiService;
            _musicListService = musicListService;
        }

        public IActionResult Index(DateTime SDate, DateTime FDate, int limit, string metin, int radioApiId, int page = 1)
        {
            if (limit == 0)
            {
                limit = 10;
            }

            //const int pageSize = 10;
            var lists = _topMusicListService.ListTopMusicListWithRadioApiPagingByradioApiIdAndDataArama(SDate, FDate, metin, radioApiId, page, limit);

            if (lists.Success)
            {
                var models = new TopListListViewModel()
                {
                    title = "Top Listeleri",
                    TopMusicLists = lists.Data,
                    PagingInfo = new PagingInfo()
                    {
                        CurrentPage = page,
                        ItemsPerPage = limit,
                        TotalItems = _topMusicListService.CountTopMusicListByradioApiId(radioApiId).Data,
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
            List<TopMusicList> radioapi = new List<TopMusicList>();

            TopListListViewModel model = new TopListListViewModel()
            {
                title = "Yeni Liste Ekleme",
                RadiosApi = new SelectList(_radioApiService.ListWebRadio().Data, "radioApiId", "title", " --Select-- "),
                TopMusicList = new TopMusicList(),
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(TopListListViewModel model, IFormFile imgPath)
        {
            TopMusicList entity = model.TopMusicList.Adapt<TopMusicList>();


            var ImgFile = await DosyaCreateExtensions.ImgCreate(imgPath, "listeler", model.TopMusicList.title);
            //entity.imgPath = ImgFile;


            entity.url = Replace.UrlAndTitleReplace(model.TopMusicList.url == null ? model.TopMusicList.title : model.TopMusicList.url);

            var result = _topMusicListService.Create(entity);

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

            var edit = _topMusicListService.GetTopMusicListByTopMusicListId((int)id);
            if (edit.Data == null)
            {
                return NotFound();
            }
            if (edit.Success)
            {
                var model = new TopListListViewModel()
                {
                    title = edit.Data.Adapt<TopMusicList>().title,
                    TopMusicList = edit.Data.Adapt<TopMusicList>(),
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
        public async Task<IActionResult> Edit(TopListListViewModel model, IFormFile imgPath)
        {
            var editmodel = _topMusicListService.GetTopMusicListByTopMusicListId(model.TopMusicList.topmusicListId);
            if (editmodel.Success)
            {
                TopMusicList entity = model.TopMusicList.Adapt<TopMusicList>();

                if (imgPath != null)
                {
                    var ImgFile = await DosyaCreateExtensions.ImgCreate(imgPath, "listeler", model.TopMusicList.title);
                    //entity.imgPath = ImgFile;
                }

                entity.url = Replace.UrlAndTitleReplace(model.TopMusicList.url == null ? model.TopMusicList.title : model.TopMusicList.url);

                var updatemodel = _topMusicListService.Update(entity);
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
            var detail = _topMusicListService.GetTopMusicListByTopMusicListId((int)Id);
            if (detail.Success)
            {
                TopListListViewModel _Detail = detail.Data.Adapt<TopListListViewModel>();
                _Detail.TopMusicList = detail.Data;

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
                TopListListViewModel _Detail = detail.Adapt<TopListListViewModel>();
                return PartialView("ViewPreview", _Detail);
            }
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            var deletemodel = _topMusicListService.GetTopMusicListByTopMusicListId((int)id);
            if (deletemodel.Success)
            {
                TopMusicList entity = deletemodel.Data.Adapt<TopMusicList>();
                var modeldelete = _topMusicListService.Delete(entity);
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
            var modelactive = _topMusicListService.GetTopMusicListByTopMusicListId((int)id);

            TopListListViewModel model = new TopListListViewModel()
            {
                TopMusicList = modelactive.Data
            };


            if (active == true)
            {
                model.TopMusicList.status = false;
            }
            if (active == false)
            {
                model.TopMusicList.status = true;
            }

            var resultUpdate = _topMusicListService.Update(model.TopMusicList);
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


        //Music List
        public IActionResult MusicListIndex(int limit, string metin, int TopMusicListId, int page = 1)
        {

            if (limit == 0)
            {
                limit = 100;
            }

            var lists = _musicListService.ListMusicListWithTopMusicListPagingByTopmusicListIdAndArama(metin, TopMusicListId, page, limit);

            //const int pageSize = 10;

            if (lists.Success)
            {
                var models = new MusicListListViewModel()
                {
                    title = "Müzik Listesi",
                    MusicLists = lists.Data,
                    TopMusicListId = TopMusicListId,

                    PagingInfo = new PagingInfo()
                    {
                        CurrentPage = page,
                        ItemsPerPage = limit,
                        TotalItems = _musicListService.CountMusicListByTopmusicListId(TopMusicListId).Data,
                        //CurrentCategory = radioApiId

                    }
                };


                if (!string.IsNullOrEmpty(TopMusicListId.ToString()) && TopMusicListId != 0)
                {
                    var topmuziktitle = _topMusicListService.GetTopMusicListWithRadioApiByTopMusicListId(TopMusicListId).Data;
                    models.title = $"Ağıdaki Listede "+topmuziktitle.title + $"ait tüm şarkılar listelenmiştir." ;
                }


                List<SelectListItem> note = new List<SelectListItem>();
                note.Insert(0, new SelectListItem() { Value = "0", Text = " --- Liste Seçiniz --- " });
                foreach (var item in _topMusicListService.ListTopMusicList().Data)
                {
                    var selectList = new SelectListItem
                    {
                        Text = item.title,
                        Value = item.topmusicListId.ToString(),
                    };
                    note.Add(selectList);

                }
                models.TopMusicLists = note;

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
        public IActionResult MusicListCreate(int? TopMusicListId)
        {
            var data = _topMusicListService.GetTopMusicListByTopMusicListId((int)TopMusicListId);
            if (data.Success)
            {

                List<MusicList> radioapi = new List<MusicList>();
                MusicListListViewModel model = new MusicListListViewModel()
                {
                    title = "YENİ MÜZİK EKLEME",
                    TopMusicLists = new SelectList(_topMusicListService.ListTopMusicList().Data, "topmusicListId", "title", " --Select-- "),
                    MusicList = new MusicList(),
                    SelectedTopMusicListId = (int)TopMusicListId,
                };

                return View(model);
            }
            else
            {


                TempData.Put("message", new ResultMessage()
                {
                    Title = ProsesMessages.TitleError,
                    Message = $"" + TopMusicListId + $" ait bilgi yoktur.",
                    Css = ProsesMessages.CssError,
                });

                return RedirectToAction("Index");

            }
        }
        [HttpPost]
        public async Task<IActionResult> MusicListCreate(MusicListListViewModel model, IFormFile imgPath, IFormFile filePath)
        {

            MusicList entity = model.MusicList.Adapt<MusicList>();
            entity.topmusicListId = model.SelectedTopMusicListId;

            //Resim
            var ImgFile = await DosyaCreateExtensions.ImgCreate(imgPath, "listeler", model.MusicList.singerName);
            entity.imgPath = ImgFile;

            //Mp3
            var Mp3File = await DosyaCreateExtensions.Mp3Create(filePath, "mp3listeler", model.MusicList.singerName);
            entity.filePath = Mp3File;


            var result = _musicListService.Create(entity);
            if (result.Success)
            {
                TempData.Put("message", new ResultMessage()
                {
                    Title = ProsesMessages.TitleSuccess,
                    Message = ProsesMessages.MessageCreate,
                    Css = ProsesMessages.CssSuccess,
                });
                return RedirectToAction("MusicListIndex", new { TopMusicListId = model.SelectedTopMusicListId });
            }
            else
            {
                return View("MusicListIndex", result);
            }
        }
        [HttpGet]
        public IActionResult MusicListEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var edit = _musicListService.GetMusicListByMusicListId((int)id);
            if (edit.Data == null)
            {
                return NotFound();
            }
            if (edit.Success)
            {
                var model = new MusicListListViewModel()
                {
                    title = edit.Data.Adapt<MusicList>().singerName,
                    MusicList = edit.Data.Adapt<MusicList>(),
                    TopMusicLists = new SelectList(_topMusicListService.ListTopMusicList().Data, "topmusicListId", "title", " --Select-- "),
                    SelectedTopMusicListId = edit.Data.topmusicListId,

                };

                return View(model);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public async Task<IActionResult> MusicListEdit(MusicListListViewModel model, IFormFile imgPath, IFormFile filePath)
        {
            var editmodel = _musicListService.GetMusicListByMusicListId(model.MusicList.musicListId);
            if (editmodel.Success)
            {
                MusicList entity = model.MusicList.Adapt<MusicList>();

                if (imgPath != null)
                {
                    //Resim
                    var ImgFile = await DosyaCreateExtensions.ImgCreate(imgPath, "listeler", model.MusicList.singerName);
                    entity.imgPath = ImgFile;
                }
                if (filePath != null)
                {
                    //Mp3
                    var Mp3File = await DosyaCreateExtensions.Mp3Create(filePath, "mp3listeler", model.MusicList.singerName);
                    entity.filePath = Mp3File;
                }

               
                var updatemodel = _musicListService.Update(entity);
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
                return RedirectToAction("MusicListIndex", new { TopMusicListId = model.MusicList.topmusicListId });
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
        public IActionResult MusicListViewPreview(int? Id)
        {
            var detail = _musicListService.GetMusicListByMusicListId((int)Id);
            if (detail.Success)
            {
                MusicListListViewModel _Detail = detail.Data.Adapt<MusicListListViewModel>();
                _Detail.MusicList = detail.Data;

                return PartialView("MusicListViewPreview", _Detail);
            }
            else
            {
                TempData.Put("message", new ResultMessage()
                {
                    Title = ProsesMessages.TitleError,
                    Message = detail.Message,
                    Css = ProsesMessages.CssError
                });
                MusicListListViewModel _Detail = detail.Adapt<MusicListListViewModel>();
                return PartialView("MusicListViewPreview", _Detail);
            }
        }
        [HttpGet]
        public IActionResult MusicListDelete(int? id)
        {
            var deletemodel = _musicListService.GetMusicListByMusicListId((int)id);
            if (deletemodel.Success)
            {
                MusicList entity = deletemodel.Data.Adapt<MusicList>();
                var modeldelete = _musicListService.Delete(entity);
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

            return RedirectToAction("MusicListIndex", new { TopMusicListId = deletemodel.Data.topmusicListId });

        }
        [HttpPost]
        public IActionResult MusicListActive(bool active, int id)
        {
            var modelactive = _musicListService.GetMusicListByMusicListId((int)id);

            MusicListListViewModel model = new MusicListListViewModel()
            {
                MusicList = modelactive.Data
            };


            if (active == true)
            {
                model.MusicList.status = false;
            }
            if (active == false)
            {
                model.MusicList.status = true;
            }

            var resultUpdate = _musicListService.Update(model.MusicList);
            if (resultUpdate.Success)
            {
                TempData.Put("message", new ResultMessage()
                {
                    Title = ProsesMessages.TitleSuccess,
                    Message = $"" + ProsesMessages.MessageEdit,
                    Css = ProsesMessages.CssSuccess
                });
            }
            return RedirectToAction("MusicListIndex", new { TopMusicListId = modelactive.Data.topmusicListId });
        }


    }
}
