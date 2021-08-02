using Eticaret.Business.Abstract.UI;
using Eticaret.UI.Constants;
using Eticaret.UI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eticaret.UI.Controllers
{
    public class PodcastController : Controller
    {

        private readonly IRadioApiWebService _radioApiWebService;
        private readonly IPodcastWebService _podcastWebService;

        public PodcastController(IRadioApiWebService radioApiWebService, IPodcastWebService podcastWebService )
        {
            _radioApiWebService = radioApiWebService;
            _podcastWebService = podcastWebService;
        }


      
        public IActionResult Index()
        {
            try
            {
                RadioApiViewListModel newmodel = new RadioApiViewListModel();
                var radioApi = _radioApiWebService.ListRadioApiWithFull();
                if (radioApi.Success)
                {
                    newmodel.RadioApies = radioApi.Data;

                }
                newmodel.title = Titles.Frekanslar;

                List<SelectListItem> note = new List<SelectListItem>();
                note.Insert(0, new SelectListItem() { Value = "0", Text = " RADYO SEÇİNİZ " });
                foreach (var item in radioApi.Data)
                {
                    var selectList = new SelectListItem
                    {
                        Text = item.title,
                        Value = item.radioApiId.ToString(),
                    };
                    note.Add(selectList);
                }

                newmodel.RadiosApiSelectListItem = note;


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
                RadioApiViewListModel newmodel = new RadioApiViewListModel();


                //if (!string.IsNullOrEmpty(newsUrl))
                //{
                //    var news = _radioApiWebService.
                //    if (news.Success)
                //    {
                //        newmodel.RadioApies = news.Data;
                //    }
                //}
                return View(newmodel);
            }
            catch
            {
                return View();
            }
        }

    }
}
