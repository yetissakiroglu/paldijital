using Eticaret.Business.Abstract.UI;
using Eticaret.UI.Constants;
using Eticaret.UI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eticaret.UI.ViewComponents
{
    [ViewComponent(Name = "_footer")] //Solution

    public class _footerController : ViewComponent
    {

    
        IRadioWebService _radioWebService;
      
        public _footerController( IRadioWebService radioWebService)
        {
          
            _radioWebService = radioWebService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
             
                FooterViewListModel fModel = new FooterViewListModel();

            var radios = _radioWebService.ListRadio();
            if (radios.Success)
                fModel.Radios = radios.Data;
            fModel.titleRadio = Titles.Radyolar;

            return View("_footer", fModel);
        }
    }
}
