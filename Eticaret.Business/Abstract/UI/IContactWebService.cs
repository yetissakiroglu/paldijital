using Eticaret.Core.Utilities.Results;
using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eticaret.Business.Abstract.UI
{
    public interface IContactWebService
    {
        IDataResult<Contact> GetContactById(int Id);
        IDataResult<List<Contact>> ListContactById(int Id);
        IDataResult<List<Contact>> ListContact();
        IResult Create(Contact contact);
    }
}
