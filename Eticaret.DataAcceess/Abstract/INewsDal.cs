using Eticaret.Core.DataAccess;
using Eticaret.Entities.ComplexTypes;
using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eticaret.DataAccess.Abstract
{
    public interface INewsDal : IEntityRepository<News>
    {
        News GetNewsWithWebRadioBynewId(int newsId);

        List<NewsDetail> ListNewsDetailsWithNewsCategory();
        List<News> ListNewsWithNewsCategory();
        List<News> ListNewsWithNewsCategoryBycategoryId(int categoryId);
        News GetNewsWithNewsCategoryBynewId(int newId);

        int CountNewsBycategoryId(int categoryId);
        List<NewsDetail> ListNewsDetailWithNewsCategoryPaging(int page, int pageSize);


        List<News> ListNewsWithNewsCategoryPaging(int page, int pageSize);



        List<NewsDetail> ListNewsDetailWithNewsCategoryPagingBycategoryId(int categoryId, int page, int pageSize);
        List<News> ListNewsWithNewsCategoryPagingBycategoryId(int categoryId, int page, int pageSize);

        List<NewsDetail> ListNewsDetailWithNewsCategoryPagingByCategoryTitle(string category, int page, int pageSize);
        List<News> ListNewsWithNewsCategoryPagingByCategoryTitle(string category, int page, int pageSize);

        void NewsRadioUpdate(News news, int[] categoryIds);
        void NewsRadioCreate(News news, int[] categoryIds);

        News GetNewsWithNewsRadioBynewId(int newsId);


        List<News> ListNewsWithRadioApiPagingByradioApiIdAndArama(string aramametin, int radioApiId, int categoryId, int page, int pageSize);
        int CountNewsByradioApiId(int radioApiId, int categoryId);



        //Web Sorgu
        List<NewsDetail> HomeManset(int count);
        List<NewsDetail> HomeOnecikan(int count);

    }
}
