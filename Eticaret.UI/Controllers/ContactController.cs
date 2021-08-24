using Eticaret.Business.Abstract.UI;
using Eticaret.Entities.Concrete;
using Eticaret.UI.Constants;
using Eticaret.UI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eticaret.Core.Extensions;
using Eticaret.Core.Entities.ComplexTypes;
using Eticaret.Core.Utilities.Messages.WebMessage;

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

        [HttpPost]
        public IActionResult Send(ContactViewListModel model)
        {
            //AppUser = _mapper.Map<AppUserListDto>(_userManager.Users.FirstOrDefault(I => I.Id == model.PersonelId)),

            //return View(_mapper.Map<GorevUpdateDto>(gorev));
            if (ModelState.IsValid)
            {
                Contact entity = new Contact()
                {
                    name = model.Contact.name,
                    subject = model.Contact.subject,
                    email = model.Contact.email,
                    message = model.Contact.message
                };
                var result = _contactsWebService.Create(entity);


                if (result.Success)
                {
                    TempData.Put("message", new ResultMessage()
                    {
                        Title = ProsesWebMessages.Success,
                        Message = result.Message,
                        Css = ProsesWebMessages.CssSuccess,
                    });

                    return RedirectToAction("Index");
                }

                return BadRequest(result.Message);
            }
            return View(model);
        }
    }
}
