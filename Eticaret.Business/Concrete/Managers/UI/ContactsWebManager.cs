using Eticaret.Business.Abstract.UI;
using Eticaret.Core.Utilities.Results;
using Eticaret.DataAccess.Abstract.UI;
using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eticaret.Business.Concrete.Managers.UI
{
    public class ContactsWebManager : IContactsWebService
    {
        private IContactsWebDal _contactsWebDal;

        public ContactsWebManager(IContactsWebDal contactsWebDal)
        {
            _contactsWebDal = contactsWebDal;
        }
        public IDataResult<Contacts> GetBildirById(int Id)
        {
            return new SuccessDataResult<Contacts>(_contactsWebDal.Get(p => p.Id == Id));
        }
    }
}
