using Eticaret.Business.Abstract.UI;
using Eticaret.Core.Utilities.Results;
using Eticaret.DataAccess.Abstract.UI;
using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eticaret.Business.Concrete.Managers.UI
{
    public class RadioWebManager : IRadioWebService
    {
        private IRadioWebDal _radioWebDal;

        public RadioWebManager(IRadioWebDal radioWebDal)
        {
            _radioWebDal = radioWebDal;
        }
        public IDataResult<Radio> GetRadioByradioId(int? radioId)
        {
            return new SuccessDataResult<Radio>(_radioWebDal.GetOne(p => p.radioId == radioId));
        }

        public IDataResult<List<Radio>> ListRadio()
        {
            return new SuccessDataResult<List<Radio>>(_radioWebDal.GetAll().ToList());
        }
    }
}
