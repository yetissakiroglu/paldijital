using Eticaret.Business.Abstract.Admin;
using Eticaret.Business.Constants;
using Eticaret.Core.Utilities.Business;
using Eticaret.Core.Utilities.Results;
using Eticaret.DataAccess.Abstract.Admin;
using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eticaret.Business.Concrete.Managers.Admin
{
    public class NewsCategoryManager : INewsCategoryService
    {
        private INewsCategoryDal _newsCategoryDal;

        public NewsCategoryManager(INewsCategoryDal newsCategoryDal)
        {
            _newsCategoryDal = newsCategoryDal;
        }

        public IDataResult<int> CountNewsCategories()
        {
            return new SuccessDataResult<int>(_newsCategoryDal.GetAll().Count());
        }

        public IResult Create(NewsCategory newsCategory)
        {
            IResult result = BusinessRules.Run(CheckIfCreateDataNameExists(newsCategory.title));
            if (result != null)
            {
                return result;
            }
            _newsCategoryDal.Create(newsCategory);
            return new SuccessResult(Messages.Creared);
        }

        public IResult Delete(NewsCategory newsCategory)
        {
            _newsCategoryDal.Delete(newsCategory);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<NewsCategory> GetNewsCategoryBycategoryId(int categoryId)
        {
            return new SuccessDataResult<NewsCategory>(_newsCategoryDal.Get(p => p.categoryId == categoryId));
        }

        public IDataResult<NewsCategory> GetNewsCategoryWithNewsBycategoryId(int categoryId)
        {
            return new SuccessDataResult<NewsCategory>(_newsCategoryDal.GetNewsCategoryWithNewsBycategoryId(categoryId));
        }

        public IDataResult<List<NewsCategory>> ListNewsCategory()
        {
            return new SuccessDataResult<List<NewsCategory>>(_newsCategoryDal.GetAll().ToList());
        }

        public IDataResult<List<NewsCategory>> ListNewsCategoryWithNews()
        {
            return new SuccessDataResult<List<NewsCategory>>(_newsCategoryDal.ListNewsCategoryWithNews());
        }

        public IDataResult<List<NewsCategory>> ListNewsCategoryWithNewsPaging(int page, int pageSize)
        {
            return new SuccessDataResult<List<NewsCategory>>(_newsCategoryDal.ListNewsCategoryWithNewsPaging(page, pageSize));
        }

        public IResult Update(NewsCategory newsCategory)
        {
            IResult result = BusinessRules.Run(CheckIfUpdateDataNameExists(newsCategory.title, newsCategory.categoryId));
            if (result != null)
            {
                return result;
            }
            _newsCategoryDal.Update(newsCategory);
            return new SuccessResult(Messages.Updated);
        }

        private IResult CheckIfCreateDataNameExists(string name)
        {
            var result = _newsCategoryDal.GetAll(p => p.title == name).Any();
            if (result)
            {
                return new ErrorResult(Messages.NameAlreadyExists);
            }
            return new SuccessResult();
        }

        private IResult CheckIfUpdateDataNameExists(string name, int id)
        {

            var result = _newsCategoryDal.GetAll(p => p.title == name && p.categoryId != id).Any();
            if (result)
            {
                return new ErrorResult(Messages.NameAlreadyExists);
            }
            return new SuccessResult();
        }

    }
}
