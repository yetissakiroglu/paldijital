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

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public JsonResult MiniBasvuru(string adVal, string cepVal, string aciklamaVal)
        //{
        //    List<string> alert = null;
        //    if (string.IsNullOrEmpty(cepVal) || string.IsNullOrWhiteSpace(cepVal))
        //    {
        //        alert = new List<string> { "İletişim numarası eksik veya hatalı tekrar deneyiniz." };
        //    }
        //    else
        //    {
        //        if (cepVal.Length <
        //            15)
        //        {
        //            alert = new List<string> { "İletişim numarası eksik veya hatalı tekrar deneyiniz." };
        //            //alert = new List<string> { "İletişim numarası eksik veya hatalı tekrar deneyiniz." };
        //        }
        //    }

        //    if (alert != null && alert.Count > 0)
        //    {
        //        return Json(new
        //        {
        //            alert = alert,
        //            durum = JsonResultEnum.Error,
        //        });
        //    }
        //    var basvuruServices = DependencyResolver.Current.GetService<IBasvuruServices>();

        //    basvuruServices.AddBasvuru(new BasvuruModel
        //    {
        //        Universite = "",
        //        AdSoyad = adVal,
        //        Bolum = "Belirsiz Bölüm Tercihi",
        //        CepNo = cepVal,
        //        Mesaj = aciklamaVal,
        //        Tip = (int)KurumEnum.Belirsiz,
        //        IsDeleted = (int)IsActiveOrAccepted.Active,
        //        Durum = (int)BasvuruEnum.Yeni,
        //        BasvuruTarihi = DateTime.Now,
        //    });

        //    if (basvuruServices.Issues.IsValid)
        //    {
        //        return Json(new
        //        {
        //            durum = JsonResultEnum.Success,
        //        });
        //    }
        //    return Json(new
        //    {
        //        alert = basvuruServices.Issues.ValidationIssues.Select(x => x.ErrorMessage),
        //        durum = JsonResultEnum.Error,
        //    });

          
        //}
    }
}
