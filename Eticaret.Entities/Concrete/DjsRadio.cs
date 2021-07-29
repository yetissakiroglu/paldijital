using Eticaret.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Eticaret.Entities.Concrete
{
    public class DjRadio : IEntity
    {
        [ForeignKey("RadioApi")]
        public int radioApiId { get; set; }
        public RadioApi RadioApi { get; set; }
        [ForeignKey("Dj")]
        public int djId { get; set; }
        public Dj Djs { get; set; }
    }
}
