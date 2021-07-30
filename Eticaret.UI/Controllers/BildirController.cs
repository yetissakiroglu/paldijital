using Eticaret.Business.Abstract.UI;
using Eticaret.Core.Entities.ComplexTypes;
using Eticaret.Entities.Concrete;
using Eticaret.UI.Constants;
using Eticaret.UI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eticaret.Core.Extensions;
using Eticaret.Core.Utilities.Messages.WebMessage;
using AutoMapper;

namespace Eticaret.UI.Controllers
{
    public class BildirController : Controller
    {
        private readonly IBildirWebService _bildirWebService;

        public BildirController(IBildirWebService bildirWebService)
        {
            _bildirWebService = bildirWebService;
        }
        public IActionResult Index()
        {
            BildirViewListModel newmodel = new BildirViewListModel();
            newmodel.title= Titles.Bildir;
            return View(newmodel);
        }


        [HttpPost]
        public async Task<IActionResult> Save(BildirViewListModel model)
        {
            if (!ModelState.IsValid)
            {
                model.title = Titles.Bildir;
                return View("Index", model);
            }

            Bildir entity = new Bildir()
            {
                name = model.Bildir.name,
                email = model.Bildir.email,
                message = model.Bildir.message

            };
            var result = _bildirWebService.Create(entity);

            if (result.Success)
            {
                TempData.Put("message", new ResultMessage()
                {
                    Title = ProsesWebMessages.Success,
                    Message = ProsesWebMessages.SuccessMessage,
                    Css = ProsesWebMessages.CssSuccess,
                });

            }

            return View("Index");
        }

    }
}
