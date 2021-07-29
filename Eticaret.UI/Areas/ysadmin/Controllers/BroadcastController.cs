using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eticaret.Business.Abstract;
using Eticaret.Core.Entities.ComplexTypes;
using Eticaret.Core.Utilities.Messages;
using Eticaret.UI.Areas.ysadmin.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Eticaret.Core.Extensions;
using Eticaret.Business.Abstract.Admin;

namespace Eticaret.UI.Areas.ysadmin.Controllers
{
    [Area("ysadmin")]

    public class BroadcastController : Controller
    {
        private IBroadcastService _broadcastService;
        private IDjService _djService;
        private IRadioApiService _radioApiService;

        public BroadcastController(IBroadcastService broadcastService, IDjService djService, IRadioApiService radioApiService )
        {
            _broadcastService = broadcastService;
            _djService = djService;
            _radioApiService = radioApiService;
        }

        public IActionResult Index(int limit, string metin, int radioApiId, int page = 1)
        {
            if (limit == 0)
            {
                limit = 10;
            }

            //const int pageSize = 10;
            var broadcasts = _broadcastService.ListBroadcastWithRadioApiPagingByradioApiIdAndArama(metin, radioApiId, page, limit);

            if (broadcasts.Success)
            {
                var models = new BroadcastListViewModel()
                {
                    title = "Yayın Akışı Listesi",
                    Broadcasts = broadcasts.Data,
                    PagingInfo = new PagingInfo()
                    {
                        CurrentPage = page,
                        ItemsPerPage = limit,
                        TotalItems = _broadcastService.CountBroadcastByradioApiId(radioApiId).Data,
                    }
                };
                List<SelectListItem> note = new List<SelectListItem>();
                note.Insert(0, new SelectListItem() { Value = "0", Text = " --- Radyo Seçiniz --- " });
                foreach (var item in _radioApiService.ListWebRadio().Data)
                {
                    var selectList = new SelectListItem
                    {
                        Text = item.title,
                        Value = item.radioApiId.ToString(),
                    };
                    note.Add(selectList);
                }
                models.RadiosApi = note;

                if (!string.IsNullOrEmpty(metin))
                {
                    models.Search = metin;
                }


                return View(models);
            }
            else
            {
                TempData.Put("message", new ResultMessage()
                {
                    Title = ProsesMessages.TitleError,
                    Message = ProsesMessages.MessageError,
                    Css = ProsesMessages.CssError,
                });
                return View();
            }
        }



    }
}
