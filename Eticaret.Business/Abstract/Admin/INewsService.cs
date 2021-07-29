using Eticaret.Core.Utilities.Results;
using Eticaret.Entities.ComplexTypes;
using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eticaret.Business.Abstract.Admin
{
    public interface INewsService
    {
        IDataResult<News> GetNewsBynewsId(int newsId);
        IDataResult<List<News>> ListNews();
        IResult Create(News news);
        IResult Update(News news);
        IResult Delete(News news);
        IDataResult<int> CountNews();

        IResult NewsRadioCreate(News news, int[] categoryIds);
        IResult NewsRadioUpdate(News news, int[] categoryIds);

        IDataResult<News> GetNewsWithWebRadioBynewId(int newsId);


        IDataResult<News> GetNewsWithNewsRadioBynewId(int newsId);


        IDataResult<List<NewsDetail>> ListNewsDetailsWithNewsCategory();
        IDataResult<List<News>> ListNewsWithNewsCategory();
        IDataResult<List<News>> ListNewsWithNewsCategoryBycategoryId(int categoryId);
        IDataResult<News> GetNewsWithNewsCategoryBynewId(int newId);

        IDataResult<int> CountNewsBycategoryId(int categoryId);
        IDataResult<List<NewsDetail>> ListNewsDetailWithNewsCategoryPaging(int page, int pageSize);
        IDataResult<List<News>> ListNewsWithNewsCategoryPaging(int page, int pageSize);

        IDataResult<List<NewsDetail>> ListNewsDetailWithNewsCategoryPagingBycategoryId(int categoryId, int page, int pageSize);
        IDataResult<List<News>> ListNewsWithNewsCategoryPagingBycategoryId(int categoryId, int page, int pageSize);

        IDataResult<List<NewsDetail>> ListNewsDetailWithNewsCategoryPagingByCategoryTitle(string category, int page, int pageSize);
        IDataResult<List<News>> ListNewsWithNewsCategoryPagingByCategoryTitle(string category, int page, int pageSize);

        //Web İçin Sorgular

        IDataResult<List<NewsDetail>> HomeManset(int count);
        IDataResult<List<NewsDetail>> HomeOnecikan(int count);


        IDataResult<List<News>> ListNewsWithRadioApiPagingByradioApiIdAndArama(string aramametin, int radioApiId, int categoryId, int page, int pageSize);
        IDataResult<int> CountNewsByradioApiId(int radioApiId, int categoryId);

    }
}
