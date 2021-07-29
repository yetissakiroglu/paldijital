using Eticaret.Core.DataAccess;
using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eticaret.DataAccess.Abstract
{
   public interface INewsCategoryDal:IEntityRepository<NewsCategory>
    {
        NewsCategory GetNewsCategoryWithNewsBycategoryId(int categoryId);
        List<NewsCategory> ListNewsCategoryWithNewsPaging(int page, int pageSize);
        List<NewsCategory> ListNewsCategoryWithNews();
    }
}
