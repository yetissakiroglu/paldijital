using Eticaret.Core.DataAccess;
using Eticaret.Entities.ComplexTypes;
using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eticaret.DataAccess.Abstract.Admin
{
    public interface IRadioDal : IEntityRepository<Radio>
    {
        List<RadioDetail> ListRadioDetailWithRadioCategory();
        List<Radio> ListRadioWithRadioCategory();
        List<Radio> ListRadioWithRadioCategoryBycategoryId(int categoryId);
        Radio GetRadioWithRadioCategoryByradioId(int radioId);
        int CountRadiosBycategoryId(int categoryId);
     
        List<RadioDetail> ListRadioDetailWithRadioCategoryPaging(int page, int pageSize);
        List<Radio> ListRadioWithRadioCategoryPaging(int page, int pageSize);

        List<RadioDetail> ListRadioDetailWithRadioCategoryPagingBycategoryId(int categoryId, int page, int pageSize);
        List<Radio> ListRadioWithRadioCategoryPagingBycategoryId(int categoryId, int page, int pageSize);

        List<RadioDetail> ListRadioDetailWithRadioCategoryPagingByCategoryTitle(string category, int page, int pageSize);
        List<Radio> ListRadioWithRadioCategoryPagingByCategoryTitle(string category, int page, int pageSize);

        List<Radio> ListRadioWithRadioCategoryAndAramaPaging(string aramametin, int page, int pageSize);


        List<RadioDetail> ListRadioWithRadioCategoryPagingByradioCategoryIdAndArama(string aramametin, int radiocategoryId, int page, int pageSize);


    }
}
