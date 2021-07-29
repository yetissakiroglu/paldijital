using Eticaret.Core.Utilities.Results;
using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eticaret.Business.Abstract.Admin
{
    public interface IDjService
    {

        IDataResult<Dj> GetDjBydjId(int djId);
        IDataResult<List<Dj>> ListDjByradioApiId(int radioApiId);
        IDataResult<List<Dj>> ListDj();
        IResult Create(Dj dj);
        IResult Update(Dj dj);
        IResult Delete(Dj dj);


        IResult DjRadioCreate(Dj dj, int[] categoryIds);
        IResult DjRadioUpdate(Dj dj, int[] categoryIds);


        IDataResult<int> CountDj();

        IDataResult<List<Dj>> ListDjWithRadioApi();
        IDataResult<List<Dj>> ListDjPaging(int page, int pageSize);
        IDataResult<List<Dj>> ListDjWithRadioApiPaging(int page, int pageSize);
        //Arama
        IDataResult<List<Dj>> ListDjWithRadioApiAndAramaPaging(string aramametin, int page, int pageSize);
        IDataResult<List<Dj>> ListDjWithRadioApiPagingByradioApiId(int radioApiId, int page, int pageSize);
        //Arama
        IDataResult<List<Dj>> ListDjWithRadioApiPagingByradioApiIdAndArama(string aramametin, int radioApiId, int page, int pageSize);
        IDataResult<List<Dj>> ListDjWithRadioApiPagingByradioApiTitle(string radioApi, int page, int pageSize);
        IDataResult<Dj> GetDjWithRadioApiBydjId(int djId);
        IDataResult<List<Dj>> ListDjWithRadioApiByradioApiId(int radioApiId);
        IDataResult<int> CountDjByradioApiId(int radioApiId);

    }
}
