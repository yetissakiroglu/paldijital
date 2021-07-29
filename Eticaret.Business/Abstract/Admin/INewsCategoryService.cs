using Eticaret.Core.Utilities.Results;
using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eticaret.Business.Abstract.Admin
{
    public interface INewsCategoryService
    {
        IDataResult<List<NewsCategory>> ListNewsCategory();
        IDataResult<NewsCategory> GetNewsCategoryBycategoryId(int categoryId);
        IResult Create(NewsCategory newsCategory);
        IResult Update(NewsCategory newsCategory);
        IResult Delete(NewsCategory newsCategory);
        IDataResult<int> CountNewsCategories();


        IDataResult<NewsCategory> GetNewsCategoryWithNewsBycategoryId(int categoryId);
        IDataResult<List<NewsCategory>> ListNewsCategoryWithNewsPaging(int page, int pageSize);
        IDataResult<List<NewsCategory>> ListNewsCategoryWithNews();

    }
}
