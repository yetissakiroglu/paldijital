using Eticaret.Business.Abstract;
using Eticaret.Business.Abstract.Admin;
using Eticaret.UI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eticaret.UI.Controllers
{
    public class RadioController : Controller
    {
   
        IRadioService _radioService;
   
        public RadioController( IRadioService radioService)
        {
     
            _radioService = radioService;
   


        }
        public IActionResult Index()
        {
            RadioViewListeModel modelradio = new RadioViewListeModel();

             var radios = _radioService.ListRadio();
            if (radios.Success)
            {
                modelradio.Radios = radios.Data;
            }
           


            return View(modelradio);
        }
    }
}
