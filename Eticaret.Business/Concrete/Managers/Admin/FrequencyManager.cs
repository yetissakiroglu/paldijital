using Eticaret.Business.Abstract.Admin;
using Eticaret.Business.Constants;
using Eticaret.Core.Utilities.Results;
using Eticaret.DataAccess.Abstract;
using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eticaret.Business.Concrete.Managers.Admin
{
    public class FrequencyManager : IFrequencyService
    {
        private IFrequencyDal _FrequencyDal;

        public FrequencyManager(IFrequencyDal FrequencyDal)
        {
            _FrequencyDal = FrequencyDal;
        }

        public IDataResult<int> CountFrequency()
        {
            return new SuccessDataResult<int>(_FrequencyDal.GetAll().Count());
        }

        public IDataResult<int> CountFrequencyByradioApiId(int radioApiId)
        {
            return new SuccessDataResult<int>(_FrequencyDal.CountFrequencyByradioApiId(radioApiId));
        }

        public IResult Create(Frequency Frequency)
        {
            _FrequencyDal.Create(Frequency);
            return new SuccessResult(Messages.Creared);
        }

        public IResult Delete(Frequency Frequency)
        {
            _FrequencyDal.Delete(Frequency);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<Frequency> GetFrequencyByFrequencyId(int FrequencyId)
        {
            return new SuccessDataResult<Frequency>(_FrequencyDal.Get(p => p.frequencyId == FrequencyId));
        }

        public IDataResult<Frequency> GetFrequencyWithRadioApiByFrequencyId(int FrequencyId)
        {
            return new SuccessDataResult<Frequency>(_FrequencyDal.GetFrequencyWithRadioApiByFrequencyId(FrequencyId));
        }

        public IDataResult<List<Frequency>> ListFrequency()
        {
            return new SuccessDataResult<List<Frequency>>(_FrequencyDal.GetAll().ToList());
        }

        public IDataResult<List<Frequency>> ListFrequencyByradioApiId(int radioApiId)
        {
            return new SuccessDataResult<List<Frequency>>(_FrequencyDal.GetAll(p => p.radioApiId == radioApiId).ToList());
        }

        public IDataResult<List<Frequency>> ListFrequencyPaging(int page, int pageSize)
        {
            return new SuccessDataResult<List<Frequency>>(_FrequencyDal.ListFrequencyPaging(page, pageSize));
        }

        public IDataResult<List<Frequency>> ListFrequencyWithRadioApi()
        {
            return new SuccessDataResult<List<Frequency>>(_FrequencyDal.ListFrequencyWithRadioApi());
        }

        public IDataResult<List<Frequency>> ListFrequencyWithRadioApiAndAramaPaging(string aramametin, int page, int pageSize)
        {
            return new SuccessDataResult<List<Frequency>>(_FrequencyDal.ListFrequencyWithRadioApiAndAramaPaging(aramametin, page, pageSize));
        }

        public IDataResult<List<Frequency>> ListFrequencyWithRadioApiByradioApiId(int radioApiId)
        {
            return new SuccessDataResult<List<Frequency>>(_FrequencyDal.ListFrequencyWithRadioApiByradioApiId(radioApiId));
        }

        public IDataResult<List<Frequency>> ListFrequencyWithRadioApiPaging(int page, int pageSize)
        {
            return new SuccessDataResult<List<Frequency>>(_FrequencyDal.ListFrequencyWithRadioApiPaging(page, pageSize));
        }

        public IDataResult<List<Frequency>> ListFrequencyWithRadioApiPagingByradioApiId(int radioApiId, int page, int pageSize)
        {
            return new SuccessDataResult<List<Frequency>>(_FrequencyDal.ListFrequencyWithRadioApiPagingByradioApiId(radioApiId, page, pageSize));
        }

        public IDataResult<List<Frequency>> ListFrequencyWithRadioApiPagingByradioApiIdAndArama(string aramametin, int radioApiId, int page, int pageSize)
        {
            return new SuccessDataResult<List<Frequency>>(_FrequencyDal.ListFrequencyWithRadioApiPagingByradioApiIdAndArama(aramametin, radioApiId, page, pageSize));
        }

        public IDataResult<List<Frequency>> ListFrequencyWithRadioApiPagingByradioApiTitle(string radioApi, int page, int pageSize)
        {
            return new SuccessDataResult<List<Frequency>>(_FrequencyDal.ListFrequencyWithRadioApiPagingByradioApiTitle(radioApi, page, pageSize));
        }

        public IResult Update(Frequency Frequency)
        {
            _FrequencyDal.Update(Frequency);
            return new SuccessResult(Messages.Updated);
        }
    }
}
