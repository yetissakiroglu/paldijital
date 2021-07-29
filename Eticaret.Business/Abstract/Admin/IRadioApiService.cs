using Eticaret.Core.Utilities.Results;
using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eticaret.Business.Abstract.Admin
{
    public interface IRadioApiService
    {
        IDataResult<RadioApi> GetWebRadioBywebRadioId(int webRadioId);
        IDataResult<List<RadioApi>> ListRadioApiPaging(int page, int pageSize);

        IDataResult<List<RadioApi>> ListRadioApiWithFull();

        IDataResult<List<RadioApi>> ListWebRadioBywebRadioId(int webRadioId);
        IDataResult<List<RadioApi>> ListWebRadioWithNewsRadio();
        IDataResult<List<RadioApi>> ListWebRadio();
        IResult Create(RadioApi webRadio);
        IResult Update(RadioApi webRadio);
        IResult Delete(RadioApi webRadio);
        IDataResult<int> CountWebRadio();
    }
}
