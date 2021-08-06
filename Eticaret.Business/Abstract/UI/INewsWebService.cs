using Eticaret.Core.Utilities.Results;
using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eticaret.Business.Abstract.UI
{
   public interface INewsWebService
    {
        IDataResult<List<News>> ListNewsWithNewsCategoryPaging(int page, int pageSize);
        IDataResult<List<News>> ListNewsWithNewsCategoryPagingSearchingCategoryUrl(int page, int pageSize, string url);
        IDataResult<News> GetNewsWithNewsCategoryBynewsUrl(string pageUrl);
        IDataResult<List<News>> ListNewsWithNewsCategoryBycategoryId(int categoryId,int page, int pageSize);


    }
}
