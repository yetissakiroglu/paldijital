using Eticaret.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eticaret.Entities.Concrete
{
  public  class Bildir:IEntity
    {
        public int Id { get; set; }
        public string message { get; set; }
        public bool IsRead { get; set; }
        public bool IsEdited { get; set; }
        
    }
}
