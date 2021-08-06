using Eticaret.Core.DataAccess;
using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eticaret.DataAccess.Abstract.UI
{
    public interface INewsWebDal: IEntityRepository<News>
    {
       List<News> ListNewsWithNewsCategoryPaging(int page, int pageSize);
       List<News> ListNewsWithNewsCategoryPagingByCategoryUrl(int page, int pageSize,string url);
        News GetNewsWithNewsCategoryBynewsUrl(string pageUrl);

        List<News> ListNewsWithNewsCategoryBycategoryId(int categoryId, int page, int pageSize);
    }
}
