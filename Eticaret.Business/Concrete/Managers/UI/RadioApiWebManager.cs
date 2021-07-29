using Eticaret.Business.Abstract.UI;
using Eticaret.Core.Utilities.Results;
using Eticaret.DataAccess.Abstract;
using Eticaret.DataAccess.Abstract.UI;
using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eticaret.Business.Concrete.Managers.UI
{
    public class RadioApiWebManager : IRadioApiWebService
    {
        private IRadioApiWebDal _radioApiWebDal;

        public RadioApiWebManager(IRadioApiWebDal radioApiWebDal)
        {
            _radioApiWebDal = radioApiWebDal;
        }
        public IDataResult<RadioApi> GetRadioApiWithFullByradioApiId(int? radioapiId)
        {
            return new SuccessDataResult<RadioApi>(_radioApiWebDal.GetRadioApiWithFullByradioApiId((int)radioapiId));
        }

        public IDataResult<List<RadioApi>> ListRadioApiWithFull()
        {
            return new SuccessDataResult<List<RadioApi>>(_radioApiWebDal.ListRadioApiWithFull());
        }

        public IDataResult<List<RadioApi>> ListRadioApiWithFullByradioApiId(int? radioapiId)
        {
            return new SuccessDataResult<List<RadioApi>>(_radioApiWebDal.ListRadioApiWithFullByradioApiId((int) radioapiId));
        }
    }
}
