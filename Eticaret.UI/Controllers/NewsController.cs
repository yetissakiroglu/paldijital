using Eticaret.Business.Abstract;
using Eticaret.Business.Abstract.UI;
using Eticaret.UI.Constants;
using Eticaret.UI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Eticaret.UI.Controllers
{

    public class NewsController : Controller
    {
        INewsCategoryWebService _newsCategoryWebService;
        INewsWebService _newsWebService;

        public NewsController(INewsWebService newsWebService, INewsCategoryWebService newsCategorWebService)
        {
            _newsWebService = newsWebService;
            _newsCategoryWebService = newsCategorWebService;
        }

        int pageSize = 12;
        [HttpGet]
        public IActionResult Index(int? page)
        {
            try
            {
                NewsViewListModel newmodel = new NewsViewListModel();
                if (!page.HasValue)
                {
                    var news = _newsWebService.ListNewsWithNewsCategoryPaging(1, pageSize);
                    if (news.Success)
                    {
                        newmodel.Newsies = news.Data;
                    }
                }

                var newscategory = _newsCategoryWebService.ListNewsCategoryWithNews();
                if (newscategory.Success)
                {
                    newmodel.NewsCategories = newscategory.Data;
                }
                newmodel.title = Titles.Haberler;
                return View(newmodel);
            }
            catch
            {
                return View();
            }

        }

        public IActionResult Category(string categoryUrl, int? page)
        {
            try
            {
                NewsViewListModel newmodel = new NewsViewListModel();
                if (!string.IsNullOrEmpty(categoryUrl))
                {
                    if (!page.HasValue)
                    {
                        var news = _newsWebService.ListNewsWithNewsCategoryPagingSearchingCategoryUrl(1, pageSize, categoryUrl);
                        if (news.Success)
                        {
                            newmodel.Newsies = news.Data;

                        }
                    }

                    var categories = _newsCategoryWebService.ListNewsCategoryWithNews();
                    if (categories.Success)
                        newmodel.NewsCategories = categories.Data;


                    var category = _newsCategoryWebService.GetNewsCategoryBycategoryUrl(categoryUrl);
                    if (category.Success)
                        newmodel.NewsCategory = category.Data;

                    newmodel.title = Titles.Haberler;
                    return View(newmodel);
                }

                return View(newmodel);
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Detail(string newsUrl)
        {
            try
            {
                NewsViewListModel newmodel = new NewsViewListModel();
                if (!string.IsNullOrEmpty(newsUrl))
                {
                    var news = _newsWebService.GetNewsWithNewsCategoryBynewsUrl(newsUrl);
                    if (news.Success)
                    {
                        newmodel.Detail = news.Data;
                    }
                }
                return View(newmodel);
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult FullNewsListAjax(int? page)
        {
            NewsViewListModel newmodel = new NewsViewListModel();
            if (page.HasValue)
            {
                int pageIndex = page.Value + 1;
                var news = _newsWebService.ListNewsWithNewsCategoryPaging(pageIndex, pageSize);
                if (news.Success)
                {
                    newmodel.Newsies = news.Data;
                }
            }
            return PartialView("_newslist", newmodel);
        }
        [HttpGet]
        public IActionResult CategoryNewsListAjax(int? categoryId, int? page)
        {
            NewsViewListModel newmodel = new NewsViewListModel();
            if (page.HasValue && categoryId.HasValue)
            {
                int pageIndex = page.Value;
                var news = _newsWebService.ListNewsWithNewsCategoryBycategoryId((int)categoryId, pageIndex, pageSize);
                if (news.Success)
                {
                    newmodel.Newsies = news.Data;
                }
            }
            return PartialView("_newslist", newmodel);

        }
    }
}
