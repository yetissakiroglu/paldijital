using Eticaret.Core.DataAccess;
using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eticaret.DataAccess.Abstract
{
    public interface IRadioCategoryDal : IEntityRepository<RadioCategory>
    {
        RadioCategory GetRadioCategoryWithRadiosBycategoryId(int categoryId);
        List<RadioCategory> ListRadioCategoryWithRadiosPaging(int page, int pageSize);
        List<RadioCategory> ListRadioCategoryWithRadios();
        void DeleteFromRadioCategoryandRadios(RadioCategory radioCategory);



    }
}
