using Eticaret.Core.DataAccess;
using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eticaret.DataAccess.Abstract
{
    public interface IFrequencyDal: IEntityRepository<Frequency>
    {
        List<Frequency> ListFrequencyWithRadioApi();
        List<Frequency> ListFrequencyPaging(int page, int pageSize);
        List<Frequency> ListFrequencyWithRadioApiPaging(int page, int pageSize);

        //Arama
        List<Frequency> ListFrequencyWithRadioApiAndAramaPaging(string aramametin, int page, int pageSize);

        List<Frequency> ListFrequencyWithRadioApiPagingByradioApiId(int radioApiId, int page, int pageSize);

        //Arama
        List<Frequency> ListFrequencyWithRadioApiPagingByradioApiIdAndArama(string aramametin, int radioApiId, int page, int pageSize);

        List<Frequency> ListFrequencyWithRadioApiPagingByradioApiTitle(string radioApi, int page, int pageSize);

        Frequency GetFrequencyWithRadioApiByFrequencyId(int FrequencyId);
        List<Frequency> ListFrequencyWithRadioApiByradioApiId(int radioApiId);
        int CountFrequencyByradioApiId(int radioApiId);

    }
}
