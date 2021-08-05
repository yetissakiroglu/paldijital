using Eticaret.Business.Abstract.UI;
using Eticaret.UI.Constants;
using Eticaret.UI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eticaret.UI.Controllers
{
    public class ContactController : Controller
    {
        IContactWebService _contactsWebService;

        public ContactController(IContactWebService contactsWebService)
        {
            _contactsWebService = contactsWebService;
        }

        [Route("bize-ulasin")]
        public IActionResult Index()
        {
            ContactViewListModel newmodel = new ContactViewListModel();
            newmodel.title = Titles.Iletisim;
            return View(newmodel);
        }
    }
}
