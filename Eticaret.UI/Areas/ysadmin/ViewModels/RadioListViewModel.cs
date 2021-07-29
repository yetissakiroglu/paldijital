using Eticaret.Entities.ComplexTypes;
using Eticaret.Entities.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Eticaret.UI.Areas.ysadmin.ViewModels
{
    public class RadioListViewModel
    {
        public string title { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }

        public Radio Radio { get; set; }
        public List<Radio> Radios { get; set; }

        //public RadioDetail RadioDetail { get; set; }
        //public List<RadioDetail> RadiosDetail { get; set; }

        public STREAMSTATSViewRadio streamState { get; set; }

        public List<RadioStreamStatus> streamStatus { get; set; }

        public PagingInfo PagingInfo { get; set; }
        public string Search { get; set; }
        public int Limit { get; set; }

    }

  


    public class RadioStreamStatus
    {
        public int RadioId { get; set; }
        public string StreamStatus { get; set; }
    }



    public class STREAMSTATSViewRadio
    {
        public string TOTALSTREAMS { get; set; }
        public string ACTIVESTREAMS { get; set; }
        public string CURRENTLISTENERS { get; set; }
        public string PEAKLISTENERS { get; set; }
        public string MAXLISTENERS { get; set; }
        public string UNIQUELISTENERS { get; set; }
        public string AVERAGETIME { get; set; }
        public string VERSION { get; set; }

        public STREAMViewRadio streams { get; set; }
    }
    public class STREAMViewRadio
    {
        [Display(Name = "ANLIK DİNLEYİCİ SAYISI")]
        public string CURRENTLISTENERS { get; set; }
        [Display(Name = "ANLIK EN YÜKSEK DİNLEYİCİ SAYISI")]
        public string PEAKLISTENERS { get; set; }
        [Display(Name = "MAKSİMUM DİNLEYİCİ SAYISI")]
        public string MAXLISTENERS { get; set; }

        [Display(Name = "EŞSİZ DİNLEYİCİ SAYISI")]
        public string UNIQUELISTENERS { get; set; }
        [Display(Name = "ORTALAMA SÜRE")]

        public string AVERAGETIME { get; set; }
        [Display(Name = "RADYO TÜRÜ")]
        public string SERVERGENRE { get; set; }
        [Display(Name = "RADYO URL")]
        public string SERVERURL { get; set; }
        [Display(Name = "RADYO NAME")]
        public string SERVERTITLE { get; set; }
        [Display(Name = "ÇALAN ŞARKI")]
        public string SONGTITLE { get; set; }
        public string DJ { get; set; }
        [Display(Name = "TOPLAM DİNLEYİCİ SAYISI")]
        public string STREAMHITS { get; set; }

        public string STREAMSTATUS { get; set; }
        public string BACKUPSTATUS { get; set; }
        public string STREAMLISTED { get; set; }
        public string STREAMLISTEDERROR { get; set; }
        public string STREAMPATH { get; set; }
        public string STREAMUPTIME { get; set; }
        public string BITRATE { get; set; }
        public string SAMPLERATE { get; set; }
        public string CONTENT { get; set; }
    }
}
