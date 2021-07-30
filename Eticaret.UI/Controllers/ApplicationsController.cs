using Eticaret.UI.Constants;
using Eticaret.UI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eticaret.UI.Controllers
{
    public class ApplicationsController : Controller
    {

        [HttpGet]
        [Route("uygulamalar")]
        public IActionResult Index()
        {
            ApplicationViewListModel newmodel = new ApplicationViewListModel();
            newmodel.title = Titles.Uygulamalar;
            return View(newmodel);
        }
    }
}
