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
        private readonly IProgramWebService _programWebService;
        private readonly IPodcastWebService _podcastWebService;


        public PodcastController(IProgramWebService programWebService, IRadioApiWebService radioApiWebService, IPodcastWebService podcastWebService )
        {
            _radioApiWebService = radioApiWebService;
            _podcastWebService = podcastWebService;
            _programWebService = programWebService;
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
        public IActionResult Detail(string podcastUrl)
        {
            try
            {
                PodcastViewListModel viewmodel = new PodcastViewListModel();
                if (!string.IsNullOrEmpty(podcastUrl))
                {
                    var model = _programWebService.GetProgramWithPodcastListByprogramUrl(podcastUrl);
                    if (model.Success)
                    {
                        viewmodel.title = Titles.Podcastler;
                        viewmodel.Program = model.Data;
                    }
                }
                return View(viewmodel);
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult PodcastGetAjax(int? podcastid)
        {
            PodcastViewListModel newmodel = new PodcastViewListModel();
            if (podcastid.HasValue)
            {
                var radyo = _podcastWebService.GetPodcastbyId((int)podcastid);
                if (radyo.Success)
                {
                    newmodel.soundPath = radyo.Data.soundPath;
                }
            }
            return Ok(newmodel);
        }
    }
}
