using Eticaret.Core.Utilities.Results;
using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eticaret.Business.Abstract.Admin
{
    public interface IFrequencyService
    {
        IDataResult<Frequency> GetFrequencyByFrequencyId(int FrequencyId);
        IDataResult<List<Frequency>> ListFrequencyByradioApiId(int radioApiId);
        IDataResult<List<Frequency>> ListFrequency();
        IResult Create(Frequency Frequency);
        IResult Update(Frequency Frequency);
        IResult Delete(Frequency Frequency);
        IDataResult<int> CountFrequency();

        IDataResult<List<Frequency>> ListFrequencyWithRadioApi();
        IDataResult<List<Frequency>> ListFrequencyPaging(int page, int pageSize);
        IDataResult<List<Frequency>> ListFrequencyWithRadioApiPaging(int page, int pageSize);
        //Arama
        IDataResult<List<Frequency>> ListFrequencyWithRadioApiAndAramaPaging(string aramametin, int page, int pageSize);
        IDataResult<List<Frequency>> ListFrequencyWithRadioApiPagingByradioApiId(int radioApiId, int page, int pageSize);
        //Arama
        IDataResult<List<Frequency>> ListFrequencyWithRadioApiPagingByradioApiIdAndArama(string aramametin, int radioApiId, int page, int pageSize);
        IDataResult<List<Frequency>> ListFrequencyWithRadioApiPagingByradioApiTitle(string radioApi, int page, int pageSize);
        IDataResult<Frequency> GetFrequencyWithRadioApiByFrequencyId(int FrequencyId);
        IDataResult<List<Frequency>> ListFrequencyWithRadioApiByradioApiId(int radioApiId);
        IDataResult<int> CountFrequencyByradioApiId(int radioApiId);
    }
}
