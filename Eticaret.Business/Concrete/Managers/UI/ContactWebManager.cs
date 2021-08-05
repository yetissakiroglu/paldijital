using Eticaret.Business.Abstract.UI;
using Eticaret.Core.Utilities.Results;
using Eticaret.DataAccess.Abstract.UI;
using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eticaret.Business.Concrete.Managers.UI
{
    public class ContactWebManager : IContactWebService
    {
        private IContactWebDal _contactsWebDal;

        public ContactWebManager(IContactWebDal contactsWebDal)
        {
            _contactsWebDal = contactsWebDal;
        }
        public IDataResult<Contact> GetBildirById(int Id)
        {
            return new SuccessDataResult<Contact>(_contactsWebDal.Get(p => p.Id == Id));
        }
    }
}
