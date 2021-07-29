using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Eticaret.UI.Models;
using Eticaret.Business.Abstract;
using Eticaret.UI.ViewModels;
using Eticaret.Business.Abstract.UI;
using Eticaret.Business.Abstract.Admin;

namespace Eticaret.UI.Controllers
{
    public class HomeController : Controller
    {
        INewsService _newsService;
        INewsCategoryService _newsCategoryService;
        IRadioService _radioService;
        IRadioApiService _radioApiService;
        IDjService _djService;
        ITopMusicListWebService _topMusicListWebService;
        public HomeController(ITopMusicListWebService topMusicListWebService, IDjService djService, INewsService newsService, INewsCategoryService newsCategoryService, IRadioService radioService, IRadioApiService radioApiService)
        {
            _djService = djService;
            _newsService = newsService;
            _newsCategoryService = newsCategoryService;
            _radioService = radioService;
            _radioApiService = radioApiService;
            _topMusicListWebService = topMusicListWebService;


        }


        [HttpGet]
        public IActionResult Index()
        {
            HomeViewListeModel homemodel = new HomeViewListeModel();

            var mansetler = _newsService.HomeManset(5);
            var onecikanlar = _newsService.HomeOnecikan(8);
            var programlar = _radioApiService.ListRadioApiWithFull();
            var radios = _radioService.ListRadio();
            var djs = _djService.ListDjWithRadioApi();
            var listeler = _topMusicListWebService.ListTopMusicListWithMusicListWithRadioApi();

            if (mansetler.Success)
            {
                homemodel.Mansetler = mansetler.Data;
            }
            if (onecikanlar.Success)
            {
                homemodel.Oncikanlar = onecikanlar.Data;
            }
            if (programlar.Success)
            {
                homemodel.RadiosApiProgram = programlar.Data;
            }
            if (radios.Success)
            {
                homemodel.Radios = radios.Data;
            }
            if (djs.Success)
            {
                homemodel.Djs = djs.Data; 
            }

            if (listeler.Success)
            {
                homemodel.TopMusicLists = listeler.Data;
               
            }


            return View(homemodel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
