using Eticaret.Core.Utilities.Results;
using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eticaret.Business.Abstract.UI
{
    public interface IContactsWebService
    {
        IDataResult< Contacts > GetBildirById(int Id);
    }
}
