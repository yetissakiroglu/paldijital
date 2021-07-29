using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eticaret.Core.Entities.ComplexTypes;
using Eticaret.Core.Utilities.Messages;
using Microsoft.AspNetCore.Mvc;
using Eticaret.Core.Extensions;
using Eticaret.UI.Areas.ysadmin.ViewModels;
using Eticaret.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Mapster;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Web.WebPages;
using Eticaret.Business.Abstract.Admin;

namespace Eticaret.UI.Areas.ysadmin.Controllers
{
    [Area("ysadmin")]
    public class NewsController : Controller
    {
        INewsService _newsService;
        INewsCategoryService _newsCategoryService;
        IRadioApiService _webRadioService;
        IPageService _pageService;
        ISeoService _seoService;
        IRadioApiService _radioApiService;

        public NewsController(IRadioApiService radioApiService, ISeoService seoService,IPageService pageService, INewsService newsService, INewsCategoryService newsCategoryService, IRadioApiService webRadioService)
        {
            _radioApiService = radioApiService;
            _newsService = newsService;
            _newsCategoryService = newsCategoryService;
            _webRadioService = webRadioService;
            _pageService = pageService;
            _seoService = seoService;
        }
        public IActionResult Index(int categoryId, int limit, string metin, int radioApiId, int page = 1)
        {
            if (limit == 0)
            {
                limit = 25;
            }


            var news = _newsService.ListNewsWithRadioApiPagingByradioApiIdAndArama(metin, radioApiId, categoryId, page, limit);
            if (news.Success)
            {
                var models = new NewsListViewModel()
                {
                    title = "HABERLER",

                    Newsies = news.Data,
                    PagingInfo = new PagingInfo()
                    {
                        CurrentPage = page,
                        ItemsPerPage = limit,
                        TotalItems = _newsService.CountNewsByradioApiId(radioApiId,categoryId).Data,
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
                //Kategori Listesi
                List<SelectListItem> Category = new List<SelectListItem>();
                Category.Insert(0, new SelectListItem() { Value = "0", Text = " --- Kategori Seçiniz --- " });
                foreach (var item in _newsCategoryService.ListNewsCategory().Data)
                {
                    var selectList = new SelectListItem
                    {
                        Text = item.title,
                        Value = item.categoryId.ToString(),
                    };
                    Category.Add(selectList);
                }
                models.Categories = Category;



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
            List<NewsRadio> webRadios = new List<NewsRadio>();

            NewsListViewModel model = new NewsListViewModel()
            {
                title = "YENİ HABER OLUŞTUR",
                SelectedWebRadios = webRadios,
                WebRadios = _webRadioService.ListWebRadio().Data,
                Categories = new SelectList(_newsCategoryService.ListNewsCategory().Data, "categoryId", "title"),
                News = new News()
            };

            model.News.addTime = DateTime.Now;

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(NewsListViewModel model, int[] categoryIds, IFormFile imgPath, IFormFile imgPathAm, IFormFile imgPathFp)
        {
            News entity = model.News.Adapt<News>();

            var ImgFile = await DosyaCreateExtensions.ImgCreate(imgPath, "haberler", model.News.title);
            entity.imgPath = ImgFile;

            var ImgFileAm = await DosyaCreateExtensions.ImgCreate(imgPathAm, "haberler", model.News.title);
            entity.imgPathAm = ImgFileAm;

            var ImgFileFp = await DosyaCreateExtensions.ImgCreate(imgPathFp, "haberler", model.News.title);
            entity.imgPathFp = ImgFileFp;


            entity.url = Replace.UrlAndTitleReplace(model.News.url == null ? model.News.title : model.News.url);

            entity.updateTime = model.News.updateTime;

            var result = _newsService.Create(entity);
            if (result.Success)
            {

                var newsradio = _newsService.NewsRadioCreate(entity, categoryIds);


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
            var newsone = _newsService.GetNewsBynewsId((int)id);
            if (newsone.Data == null)
            {
                return NotFound();
            }
            if (newsone.Success)
            {
                var model = new NewsListViewModel()
                {
                    title = newsone.Data.title,
                    WebRadios = _webRadioService.ListWebRadio().Data,
                    SelectedWebRadios = _newsService.GetNewsWithNewsRadioBynewId(newsone.Data.newsId).Data.NewsRadios.ToList(),
                    Categories = new SelectList(_newsCategoryService.ListNewsCategory().Data, "categoryId", "title"),
                    News = newsone.Data.Adapt<News>(),
                };


                return View(model);
            }
            else
            {
                return NotFound();
            }



        }
        [HttpPost]
        public async Task<IActionResult> Edit(NewsListViewModel model, int[] categoryIds, IFormFile imgPath, IFormFile imgPathAm, IFormFile imgPathFp)
        {
            var editmodel = _newsService.GetNewsBynewsId(model.News.newsId);
            if (editmodel.Success)
            {
                News entity = model.News.Adapt<News>();

                if (imgPath != null)
                {
                    var ImgFile = await DosyaCreateExtensions.ImgCreate(imgPath, "haberler", model.News.title);
                    entity.imgPath = ImgFile;
                }
                else
                {
                    entity.imgPath = model.News.imgPath;
                }

                if (imgPathAm != null)
                {
                    var ImgFileAm = await DosyaCreateExtensions.ImgCreate(imgPathAm, "haberler", model.News.title);
                    entity.imgPathAm = ImgFileAm;
                }
                else
                {
                    entity.imgPathAm = model.News.imgPathAm;
                }

                if (imgPathFp != null)
                {
                    var ImgFileFp = await DosyaCreateExtensions.ImgCreate(imgPathFp, "haberler", model.News.title);
                    entity.imgPathFp = ImgFileFp;
                }
                else
                {
                    entity.imgPathFp = model.News.imgPathFp;
                }

                model.News.url = Replace.UrlAndTitleReplace(model.News.url == null ? model.News.title : model.News.url);


                entity.updateTime = DateTime.Now;

                var updatemodel = _newsService.NewsRadioUpdate(entity, categoryIds);
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
            var detail = _newsService.GetNewsBynewsId((int)Id);
            if (detail.Success)
            {
                NewsListViewModel _Detail = detail.Data.Adapt<NewsListViewModel>();

                _Detail.News = detail.Data;

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
                NewsListViewModel _Detail = detail.Adapt<NewsListViewModel>();
                return PartialView("ViewPreview", _Detail);
            }
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            var entity_model = _newsService.GetNewsBynewsId((int)id);
            if (entity_model.Success)
            {
                News entity = entity_model.Data.Adapt<News>();
                var modeldelete = _newsService.Delete(entity);
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
            var modelactive = _newsService.GetNewsBynewsId((int)id);

            NewsListViewModel model = new NewsListViewModel()
            {
                News = modelactive.Data
            };


            if (active == true)
            {
                model.News.status = false;
            }
            if (active == false)
            {
                model.News.status = true;
            }

            var resultUpdate = _newsService.Update(model.News);
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
        [HttpPost]
        public IActionResult ActiveaM(bool active, int id)
        {
            var modelactive = _newsService.GetNewsBynewsId((int)id);
            NewsListViewModel model = new NewsListViewModel()
            {
                News = modelactive.Data
            };

            if (active == true)
            {
                model.News.aM = false;
            }
            if (active == false)
            {
                model.News.aM = true;
            }

            var resultUpdate = _newsService.Update(model.News);
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
        [HttpPost]
        public IActionResult ActiveoC(bool active, int id)
        {
            var modelactive = _newsService.GetNewsBynewsId((int)id);
            NewsListViewModel model = new NewsListViewModel()
            {
                News = modelactive.Data
            };

            if (active == true)
            {
                model.News.oC = false;
            }
            if (active == false)
            {
                model.News.oC = true;
            }

            var resultUpdate = _newsService.Update(model.News);
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
        [HttpPost]
        public IActionResult ActivehB(bool active, int id)
        {
            var modelactive = _newsService.GetNewsBynewsId((int)id);
            NewsListViewModel model = new NewsListViewModel()
            {
                News = modelactive.Data
            };

            if (active == true)
            {
                model.News.hB = false;
            }
            if (active == false)
            {
                model.News.hB = true;
            }

            var resultUpdate = _newsService.Update(model.News);
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
        [HttpPost]
        public IActionResult ActivesD(bool active, int id)
        {
            var modelactive = _newsService.GetNewsBynewsId((int)id);
            NewsListViewModel model = new NewsListViewModel()
            {
                News = modelactive.Data
            };

            if (active == true)
            {
                model.News.sD = false;
            }
            if (active == false)
            {
                model.News.sD = true;
            }

            var resultUpdate = _newsService.Update(model.News);
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
        [HttpPost]
        public IActionResult ActiveoH(bool active, int id)
        {
            var modelactive = _newsService.GetNewsBynewsId((int)id);
            NewsListViewModel model = new NewsListViewModel()
            {
                News = modelactive.Data
            };

            if (active == true)
            {
                model.News.oH = false;
            }
            if (active == false)
            {
                model.News.oH = true;
            }

            var resultUpdate = _newsService.Update(model.News);
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
        public IActionResult NewsCategoryCreate()
        {
            NewsCategoryListViewModel model = new NewsCategoryListViewModel()
            {
                NewsCategory = new NewsCategory()
            };


            var row = _newsCategoryService.CountNewsCategories().Data;
            if (row > 0)
            {
                model.NewsCategory.row = row + 1;
            }

            return PartialView("NewsCategoryCreate", model);
        }
        [HttpPost]
        public IActionResult NewsCategoryCreate(NewsCategoryListViewModel model)
        {
            var entity = new NewsCategory()
            {
                title = model.NewsCategory.title,
                keywords = model.NewsCategory.title,
                description = model.NewsCategory.title,
                url = Replace.UrlAndTitleReplace(model.NewsCategory.title),
                status = true,
                row = model.NewsCategory.row
            };
            var result = _newsCategoryService.Create(entity);

            if (result.Success)
            {
                TempData.Put("message", new ResultMessage()
                {
                    Title = ProsesMessages.TitleSuccess,
                    Message = model.NewsCategory.title + " " + ProsesMessages.MessageCreate,
                    Css = ProsesMessages.CssSuccess,

                });
            }
            return RedirectToAction("Create", "News", model);
        }

        //-----------------------------------------------------------------
        public IActionResult CategoryIndex(int page = 1)
        {
            const int pageSize = 10;
            var categorynews = _newsCategoryService.ListNewsCategoryWithNewsPaging(page, pageSize);

            if (categorynews.Success)
            {
                var models = new NewsCategoryListViewModel()
                {
                    NewsCategorys = categorynews.Data,
                    PagingInfo = new PagingInfo()
                    {
                        CurrentPage = page,
                        ItemsPerPage = pageSize,
                        TotalItems = _newsCategoryService.CountNewsCategories().Data,
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
        public IActionResult CategoryCreate()
        {
            //List<NewsRadio> webRadios = new List<NewsRadio>();

            NewsCategoryListViewModel model = new NewsCategoryListViewModel()
            {
                title = "Yeni Haber Ekleme",
                NewsCategory = new NewsCategory(),
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> CategoryCreate(NewsCategoryListViewModel model, IFormFile imgPath)
        {
            NewsCategory entity = model.NewsCategory.Adapt<NewsCategory>();

            var ImgFile = await DosyaCreateExtensions.ImgCreate(imgPath, "news/category", model.NewsCategory.title);
            entity.imgPath = ImgFile;

            entity.url = Replace.UrlAndTitleReplace(model.NewsCategory.url == null ? model.NewsCategory.title : model.NewsCategory.url);
            var result = _newsCategoryService.Create(entity);

            if (result.Success)
            {
                TempData.Put("message", new ResultMessage()
                {
                    Title = ProsesMessages.TitleSuccess,
                    Message = ProsesMessages.MessageCreate,
                    Css = ProsesMessages.CssSuccess,
                });

                return RedirectToAction("CategoryIndex");
            }
            else
            {
                return View("CategoryIndex", result);
            }
        }
        [HttpGet]
        public IActionResult CategoryEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = _newsCategoryService.GetNewsCategoryBycategoryId((int)id);
            if (category.Data == null)
            {
                return NotFound();
            }
            if (category.Success)
            {
                var model = new NewsCategoryListViewModel()
                {
                    title = category.Data.title,
                    NewsCategory = category.Data.Adapt<NewsCategory>(),
                };

                model.NewsCategory.url = Replace.UrlAndTitleReplace(model.NewsCategory.url == null ? model.NewsCategory.title : model.NewsCategory.url);
                return View(model);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public async Task<IActionResult> CategoryEdit(NewsCategoryListViewModel model, IFormFile imgPath)
        {
            var editmodel = _newsCategoryService.GetNewsCategoryBycategoryId(model.NewsCategory.categoryId);
            if (editmodel.Success)
            {
                NewsCategory entity = model.NewsCategory.Adapt<NewsCategory>();

                if (imgPath != null)
                {
                    var ImgFile = await DosyaCreateExtensions.ImgCreate(imgPath, "news", model.NewsCategory.title);
                    entity.imgPath = ImgFile;
                }
                else
                {
                    entity.imgPath = model.NewsCategory.imgPath;
                }


                var updatemodel = _newsCategoryService.Update(entity);
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
                return RedirectToAction("CategoryIndex");
            }
            else
            {
                TempData.Put("message", new ResultMessage()
                {
                    Title = ProsesMessages.TitleError,
                    Message = ProsesMessages.MessageNoData,
                    Css = ProsesMessages.CssError,
                });
                return RedirectToAction("CategoryIndex");
            }

        }
        [HttpPost]
        public IActionResult CategoryViewPreview(int? Id)
        {
            var detail = _newsCategoryService.GetNewsCategoryBycategoryId((int)Id);
            if (detail.Success)
            {
                NewsCategoryListViewModel _Detail = detail.Data.Adapt<NewsCategoryListViewModel>();
                _Detail.NewsCategory = detail.Data;

                return PartialView("CategoryViewPreview", _Detail);
            }
            else
            {
                TempData.Put("message", new ResultMessage()
                {
                    Title = ProsesMessages.TitleError,
                    Message = detail.Message,
                    Css = ProsesMessages.CssError
                });
                NewsCategoryListViewModel _Detail = detail.Adapt<NewsCategoryListViewModel>();
                return PartialView("CategoryViewPreview", _Detail);
            }
        }
        [HttpGet]
        public IActionResult CategoryDelete(int? id)
        {
            var deletemodel = _newsCategoryService.GetNewsCategoryBycategoryId((int)id);
            if (deletemodel.Success)
            {
                NewsCategory entity = deletemodel.Data.Adapt<NewsCategory>();
                var modeldelete = _newsCategoryService.Delete(entity);
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
            return RedirectToAction("CategoryIndex");
        }
        [HttpPost]
        public IActionResult CategoryActive(bool active, int id)
        {
            var modelactive = _newsCategoryService.GetNewsCategoryBycategoryId((int)id);

            NewsCategoryListViewModel model = new NewsCategoryListViewModel()
            {
                NewsCategory = modelactive.Data
            };


            if (active == true)
            {
                model.NewsCategory.status = false;
            }
            if (active == false)
            {
                model.NewsCategory.status = true;
            }

            var resultUpdate = _newsCategoryService.Update(model.NewsCategory);
            if (resultUpdate.Success)
            {
                TempData.Put("message", new ResultMessage()
                {
                    Title = ProsesMessages.TitleSuccess,
                    Message = $"" + ProsesMessages.MessageEdit,
                    Css = ProsesMessages.CssSuccess
                });
            }
            return RedirectToAction("CategoryIndex");
        }


    }
}
