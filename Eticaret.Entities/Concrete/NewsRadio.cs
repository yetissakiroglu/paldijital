using Castle.Components.DictionaryAdapter;
using Eticaret.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eticaret.Entities.Concrete
{
    public class NewsRadio : IEntity
    {
         
        public int radioApiId { get; set; }
        public RadioApi RadioApi { get; set; }

        public int newsId { get; set; }
        public News News { get; set; }

    }
}
