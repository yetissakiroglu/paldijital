using Eticaret.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Eticaret.Entities.Concrete
{
    public class Dj : IEntity
    {
        [Display(Name = "Programcı Id : ")]
        public int djId { get; set; }
        [Display(Name = "Dj Adı : ")]
        public string title { get; set; }
        [Display(Name = "Dj Etiketi : ")]
        public string keywords { get; set; }
        [Display(Name = "Dj Description : ")]
        public string description { get; set; }
        [Display(Name = "Dj Resmi : ")]
        public string imgPath { get; set; }
        [Display(Name = "Dj Açıklaması : ")]
        public string detail { get; set; }

        public string url { get; set; }
        [Display(Name = "Facebok Linki : ")]
        public string fUrl { get; set; }
        [Display(Name = "Twitter Linki : ")]
        public string tUrl { get; set; }
        [Display(Name = "Instagram Linki : ")]
        public string iUrl { get; set; }
        [Display(Name = "Youtube Linki : ")]
        public string yUrl { get; set; }
        [Display(Name = "Spotify Linki : ")]
        public string spUrl { get; set; }
        [Display(Name = "Soundcloud Linki : ")]
        public string sUrl { get; set; }
        public int row { get; set; }
        public bool status { get; set; }


        public List<DjRadio> DjsRadios { get; set; }

    }
}
