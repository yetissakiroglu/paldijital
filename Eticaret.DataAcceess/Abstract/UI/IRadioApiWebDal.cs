using Eticaret.Core.DataAccess;
using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eticaret.DataAccess.Abstract.UI
{
    public interface IRadioApiWebDal : IEntityRepository<RadioApi>
    {
        RadioApi GetRadioApiWithFullByradioApiId(int radioApiId);

       List<RadioApi> ListRadioApiWithFullByradioApiId(int radioApiId);
        List<RadioApi> ListRadioApiWithFull();


    }
}
