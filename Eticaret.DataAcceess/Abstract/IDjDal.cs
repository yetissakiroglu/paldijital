using Eticaret.Core.DataAccess;
using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eticaret.DataAccess.Abstract
{
   public interface IDjDal : IEntityRepository<Dj>
    {
        List<Dj> ListDjWithRadioApi();
        List<Dj> ListDjPaging(int page, int pageSize);
        List<Dj> ListDjWithRadioApiPaging(int page, int pageSize);

        void DjRadioUpdate(Dj djs, int[] categoryIds);
        void DjRadioCreate(Dj djs, int[] categoryIds);

        //Arama
        List<Dj> ListDjWithRadioApiAndAramaPaging(string aramametin, int page, int pageSize);

        List<Dj> ListDjWithRadioApiPagingByradioApiId(int radioApiId, int page, int pageSize);

        //Arama
        List<Dj> ListDjWithRadioApiPagingByradioApiIdAndArama(string aramametin, int radioApiId, int page, int pageSize);

        List<Dj> ListDjWithRadioApiPagingByradioApiTitle(string radioApi, int page, int pageSize);

        Dj GetDjWithRadioApiBydjId(int djId);
        List<Dj> ListDjWithRadioApiByradioApiId(int radioApiId);
        int CountDjByradioApiId(int radioApiId);

    }
}
