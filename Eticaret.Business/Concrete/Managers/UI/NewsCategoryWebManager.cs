using Eticaret.Business.Abstract.UI;
using Eticaret.Core.Utilities.Results;
using Eticaret.DataAccess.Abstract.Admin;
using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eticaret.Business.Concrete.Managers.UI
{
    public class NewsCategoryWebManager : INewsCategoryWebService
    {
        private INewsCategoryDal _newsCategoryDal;

        public NewsCategoryWebManager(INewsCategoryDal newsCategoryDal)
        {
            _newsCategoryDal = newsCategoryDal;
        }

        public IDataResult<NewsCategory> GetNewsCategoryBycategoryUrl(string categoryUrl)
        {
            return new SuccessDataResult<NewsCategory>(_newsCategoryDal.GetOne(p=> p.url==categoryUrl));
               
        }

        public IDataResult<List<NewsCategory>> ListNewsCategoryWithNews()
        {
            return new SuccessDataResult<List<NewsCategory>>(_newsCategoryDal.ListNewsCategoryWithNews());
        }
    }
}
