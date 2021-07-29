using Eticaret.Business.Abstract.UI;
using Eticaret.Core.Utilities.Results;
using Eticaret.DataAccess.Abstract.UI;
using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eticaret.Business.Concrete.Managers.UI
{
    public class NewsWebManager : INewsWebService
    {
        private INewsWebDal _newsWebDal;

        public NewsWebManager(INewsWebDal newsWebDal)
        {
            _newsWebDal = newsWebDal;
        }

        public IDataResult<News> GetNewsWithNewsCategoryBynewsUrl(string pageUrl)
        {
            return new SuccessDataResult<News>(_newsWebDal.GetNewsWithNewsCategoryBynewsUrl(pageUrl));
        }

        public IDataResult<List<News>> ListNewsWithNewsCategoryPaging(int page, int pageSize)
        {
            return new SuccessDataResult<List<News>>(_newsWebDal.ListNewsWithNewsCategoryPaging(page, pageSize));
        }

        public IDataResult<List<News>> ListNewsWithNewsCategoryPagingSearchingCategoryUrl(int page, int pageSize, string url)
        {
            return new SuccessDataResult<List<News>>(_newsWebDal.ListNewsWithNewsCategoryPagingByCategoryUrl(page, pageSize,url));
        }
    }
}
