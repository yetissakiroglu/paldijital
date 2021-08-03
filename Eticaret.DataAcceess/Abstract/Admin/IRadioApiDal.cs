using Eticaret.Core.DataAccess;
using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eticaret.DataAccess.Abstract.Admin
{
    public interface IRadioApiDal : IEntityRepository<RadioApi>
    {
        List<RadioApi> ListWebRadioWithNewsRadio();

        List<RadioApi> ListRadioApiPaging(int page, int pageSize);

        List<RadioApi> ListRadioApiWithFull();



    }
}
