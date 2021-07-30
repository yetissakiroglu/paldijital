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
    public class ContactsController : Controller
    {
        IContactsWebService _contactsWebService;

        public ContactsController(IContactsWebService contactsWebService)
        {
            _contactsWebService = contactsWebService;
        }
        public IActionResult Index()
        {
            ContactsViewListModel newmodel = new ContactsViewListModel();
            newmodel.title = Titles.Iletisim;
            return View(newmodel);
        }
    }
}
