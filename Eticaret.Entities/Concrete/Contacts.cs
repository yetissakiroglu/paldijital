using Eticaret.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eticaret.Entities.Concrete
{
    public class Contacts: IEntity
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string telefon { get; set; }
        public string adres { get; set; }
        public string email { get; set; }

    }
}
