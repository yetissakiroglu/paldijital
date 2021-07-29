using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eticaret.Business.Abstract;
using Eticaret.UI.Areas.ysadmin.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUIStandart.Areas.ysadmin.Controllers
{
    [Area("ysadmin")]
    [Authorize]
    public class HomeController : Controller
    {
        IDjService _djService;
        INewsService _newsService;

        public HomeController(IDjService djService, INewsService newsService)
        {
            _djService = djService;
            _newsService = newsService;

        }
        public IActionResult Index()
        {
            HomeListViewModel homes = new HomeListViewModel();
            var news = _newsService.ListNews();
            if (news.Success)
            {
                homes.NewsCount = news.Data.Count();    
            }
            return View(homes);
        }

    }
}