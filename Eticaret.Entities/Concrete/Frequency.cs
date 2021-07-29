using Castle.Components.DictionaryAdapter;
using Eticaret.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Eticaret.Entities.Concrete
{
    //Frekanslar
    public class Frequency:IEntity
    {
        [Display(Name = "Id : ")]
        public int frequencyId { get; set; }
        [ForeignKey("RadioApi")]
        [Display(Name = "Radio ID : ")]
        public int radioApiId { get; set; }
        [Display(Name = "Şehir : ")]
        public string cityName { get; set; }
        [Display(Name = "Frekans No : ")]
        public string frequencyNo { get; set; }
        [Display(Name = "Frekans Resmi : ")]
        public string imgPath { get; set; }
        [Display(Name = "Frekans Sırası : ")]
        public int row { get; set; }
        [Display(Name = "Frekans Durumu : ")]
        public bool status { get; set; }
    
        public virtual RadioApi RadioApi { get; set; }


    }
}
