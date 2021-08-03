using Eticaret.Business.Abstract.Admin;
using Eticaret.Business.Constants;
using Eticaret.Core.Utilities.Results;
using Eticaret.DataAccess.Abstract.Admin;
using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eticaret.Business.Concrete.Managers.Admin
{
    public class RadioApiManager : IRadioApiService
    {
        private IRadioApiDal _webRadioDal;

        public RadioApiManager(IRadioApiDal webRadioDal)
        {
            _webRadioDal = webRadioDal;
        }
        public IDataResult<int> CountWebRadio()
        {
            return new SuccessDataResult<int>(_webRadioDal.GetAll().Count());
        }

        public IResult Create(RadioApi webRadio)
        {
            _webRadioDal.Create(webRadio);
            return new SuccessResult(Messages.Creared);
        }

        public IResult Delete(RadioApi webRadio)
        {
            _webRadioDal.Delete(webRadio);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<RadioApi> GetWebRadioBywebRadioId(int webRadioId)
        {
            return new SuccessDataResult<RadioApi>(_webRadioDal.Get(p => p.radioApiId == webRadioId));
        }

        public IDataResult<List<RadioApi>> ListRadioApiPaging(int page, int pageSize)
        {
            return new SuccessDataResult<List<RadioApi>>(_webRadioDal.ListRadioApiPaging(page,pageSize).ToList());
        }

        public IDataResult<List<RadioApi>> ListRadioApiWithFull()
        {
            return new SuccessDataResult<List<RadioApi>>(_webRadioDal.ListRadioApiWithFull().ToList());
        }

        public IDataResult<List<RadioApi>> ListWebRadio()
        {
            return new SuccessDataResult<List<RadioApi>>(_webRadioDal.GetAll().Where(x => x.status == true && x.programStatus == true).ToList());

        }

        public IDataResult<List<RadioApi>> ListWebRadioBywebRadioId(int webRadioId)
        {
            return new SuccessDataResult<List<RadioApi>>(_webRadioDal.GetAll(p => p.radioApiId == webRadioId).ToList());
        }

        public IDataResult<List<RadioApi>> ListWebRadioWithNewsRadio()
        {
            return new SuccessDataResult<List<RadioApi>>(_webRadioDal.ListWebRadioWithNewsRadio());
        }

        public IResult Update(RadioApi webRadio)
        {
            _webRadioDal.Update(webRadio);
            return new SuccessResult(Messages.Updated);
        }
    }
}
