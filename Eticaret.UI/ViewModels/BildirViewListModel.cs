using Eticaret.Core.Entities;
using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Eticaret.UI.ViewModels
{
    public class BildirViewListModel:IDto
    {

     
        public string title { get; set; }

        public Bildir Bildir { get; set; }

        public List<Bildir> Bildirs { get; set; }

    }
}
