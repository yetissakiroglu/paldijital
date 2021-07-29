using Eticaret.Business.Abstract;
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
    public class FrequencyController : Controller
    {

        IRadioApiWebService _radioApiWebService;

        public FrequencyController(IRadioApiWebService radioApiWebService)
        {
            _radioApiWebService = radioApiWebService;
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
        public IActionResult FrequencyListAjax(int? page)
        {
            RadioApiViewListModel modelRadioApi = new RadioApiViewListModel();
            if (page.HasValue)
            {
          
                var news = _radioApiWebService.ListRadioApiWithFullByradioApiId(page);
                if (news.Success)
                {
                    modelRadioApi.RadioApies = news.Data;
                }
            }
            return PartialView("_frequencylist", modelRadioApi);
        }


    }
}
