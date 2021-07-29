using Eticaret.Core.Utilities.Results;
using Eticaret.Entities.ComplexTypes;
using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eticaret.Business.Abstract.Admin
{
    public interface IRadioService
    {
        IDataResult<Radio> GetRadioByradioId(int radioId);
        IDataResult<List<Radio>> ListRadio();
        IResult Create(Radio radio);
        IResult Update(Radio radio);
        IResult Delete(Radio radio);
        IDataResult<int> CountRadios();





        IDataResult<List<RadioDetail>> ListRadioDetailWithRadioCategory();
        IDataResult<List<Radio>> ListRadioWithRadioCategory();
        IDataResult<List<Radio>> ListRadioWithRadioCategoryBycategoryId(int categoryId);
        IDataResult<Radio> GetRadioWithRadioCategoryByradioId(int radioId);

        IDataResult<int> CountRadiosBycategoryId(int categoryId);

        IDataResult<List<RadioDetail>> ListRadioDetailWithRadioCategoryPaging(int page, int pageSize);
        IDataResult<List<Radio>> ListRadioWithRadioCategoryPaging(int page, int pageSize);

        IDataResult<List<RadioDetail>> ListRadioDetailWithRadioCategoryPagingBycategoryId(int categoryId, int page, int pageSize);
        IDataResult<List<Radio>> ListRadioWithRadioCategoryPagingBycategoryId(int categoryId, int page, int pageSize);

        IDataResult<List<RadioDetail>> ListRadioDetailWithRadioCategoryPagingByCategoryTitle(string category, int page, int pageSize);
        IDataResult<List<Radio>> ListRadioWithRadioCategoryPagingByCategoryTitle(string category, int page, int pageSize);



        IDataResult<List<Radio>> ListRadioWithRadioCategoryAndAramaPaging(string aramametin, int page, int pageSize);
        IDataResult<List<RadioDetail>> ListRadioWithRadioCategoryPagingByradioCategoryIdAndArama(string aramametin, int radiocategoryId, int page, int pageSize);


    }
}
