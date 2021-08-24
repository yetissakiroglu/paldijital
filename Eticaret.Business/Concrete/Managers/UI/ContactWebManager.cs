using Eticaret.Business.Abstract.UI;
using Eticaret.Business.Constants;
using Eticaret.Business.ValidationRules.FluentValidation;
using Eticaret.Core.Aspects.Autofac.Validation;
using Eticaret.Core.Utilities.Results;
using Eticaret.DataAccess.Abstract.UI;
using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [ValidationAspect(typeof(ContactValidator), Priority = 1)]
        public IResult Create(Contact contact)
        {
            _contactsWebDal.Create(contact);
            return new SuccessResult(Messages.Creared);
        }

   

        public IDataResult<Contact> GetContactById(int Id)
        {
            return new SuccessDataResult<Contact>(_contactsWebDal.Get(p => p.Id == Id));
        }

        public IDataResult<List<Contact>> ListContact()
        {
            return new SuccessDataResult<List<Contact>>(_contactsWebDal.GetAll().ToList());
        }

        public IDataResult<List<Contact>> ListContactById(int Id)
        {
            return new SuccessDataResult<List<Contact>>(_contactsWebDal.GetAll(p => p.Id == Id).ToList());
        }
    }
}
