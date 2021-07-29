using Eticaret.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Eticaret.Entities.Concrete
{
    public class Broadcast : IEntity
    {
        public int broadcastId { get; set; }
        [ForeignKey("RadioApi")]
        [Display(Name = "Radio ID : ")]
        public int radioApiId { get; set; }
        public string title { get; set; }
        public string imgPath { get; set; }
        public string beginDate { get; set; }
        public string finishDate { get; set; }
        [ForeignKey("Dj")]
        public int djId { get; set; }
        public bool status { get; set; }

        public virtual RadioApi RadioApi { get; set; }

    }
}
