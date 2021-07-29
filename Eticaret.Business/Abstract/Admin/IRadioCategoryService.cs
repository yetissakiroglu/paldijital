using Eticaret.Core.Utilities.Results;
using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eticaret.Business.Abstract.Admin
{
    public interface IRadioCategoryService
    {
      
        IDataResult<List<RadioCategory>> ListRadioCategory();
        IDataResult<RadioCategory> GetRadioCategoryBycategoryId(int categoryId);
        IResult Create(RadioCategory radioCategory);
        IResult Update(RadioCategory radioCategory);
        IResult Delete(RadioCategory radioCategory);
        IDataResult<int> CountRadioCategories();


        IDataResult<RadioCategory> GetRadioCategoryWithRadiosBycategoryId(int categoryId);
        IDataResult<List<RadioCategory>> ListRadioCategoryWithRadiosPaging(int page, int pageSize);
        IDataResult<List<RadioCategory>> ListRadioCategoryWithRadios();
        IResult DeleteFromRadioCategoryandRadios(RadioCategory radioCategory);
             

    }
}
