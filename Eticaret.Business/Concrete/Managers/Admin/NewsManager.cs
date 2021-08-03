using Eticaret.Business.Abstract.Admin;
using Eticaret.Business.Constants;
using Eticaret.Core.Utilities.Results;
using Eticaret.DataAccess.Abstract.Admin;
using Eticaret.Entities.ComplexTypes;
using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eticaret.Business.Concrete.Managers.Admin
{
    public class NewsManager : INewsService
    {
        private INewsDal _newsDal;

        public NewsManager(INewsDal newsDal)
        {
            _newsDal = newsDal;
        }

        public IDataResult<int> CountNews()
        {
            return new SuccessDataResult<int>(_newsDal.GetAll().Count());
        }

        public IDataResult<int> CountNewsBycategoryId(int categoryId)
        {
            return new SuccessDataResult<int>(_newsDal.CountNewsBycategoryId(categoryId));
        }

        public IResult Create(News news)
        {
          
            _newsDal.Create(news);
            return new SuccessResult(Messages.Creared);
        }
        public IResult NewsRadioCreate(News news, int[] categoryIds)
        {

            _newsDal.NewsRadioCreate(news, categoryIds);
            return new SuccessResult(Messages.Creared);
        }

        public IResult Delete(News news)
        {
            _newsDal.Delete(news);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<News> GetNewsBynewsId(int newsId)
        {
            return new SuccessDataResult<News>(_newsDal.Get(p => p.newsId == newsId));
        }

        public IDataResult<News> GetNewsWithNewsCategoryBynewId(int newId)
        {
            return new SuccessDataResult<News>(_newsDal.GetNewsWithNewsCategoryBynewId(newId));
        }

        public IDataResult<List<NewsDetail>> ListNewsDetailsWithNewsCategory()
        {
            return new SuccessDataResult<List<NewsDetail>>(_newsDal.ListNewsDetailsWithNewsCategory());
        }

        public IDataResult<List<NewsDetail>> ListNewsDetailWithNewsCategoryPaging(int page, int pageSize)
        {
            return new SuccessDataResult<List<NewsDetail>>(_newsDal.ListNewsDetailWithNewsCategoryPaging(page,pageSize));
        }

        public IDataResult<List<NewsDetail>> ListNewsDetailWithNewsCategoryPagingBycategoryId(int categoryId, int page, int pageSize)
        {
            return new SuccessDataResult<List<NewsDetail>>(_newsDal.ListNewsDetailWithNewsCategoryPagingBycategoryId(categoryId,page, pageSize));
        }

        public IDataResult<List<NewsDetail>> ListNewsDetailWithNewsCategoryPagingByCategoryTitle(string category, int page, int pageSize)
        {
            return new SuccessDataResult<List<NewsDetail>>(_newsDal.ListNewsDetailWithNewsCategoryPagingByCategoryTitle(category, page, pageSize));
        }

        public IDataResult<List<News>> ListNewsWithNewsCategory()
        {
            return new SuccessDataResult<List<News>>(_newsDal.ListNewsWithNewsCategory());
        }

        public IDataResult<List<News>> ListNewsWithNewsCategoryBycategoryId(int categoryId)
        {
            return new SuccessDataResult<List<News>>(_newsDal.ListNewsWithNewsCategoryBycategoryId(categoryId));
        }

        public IDataResult<List<News>> ListNewsWithNewsCategoryPaging(int page, int pageSize)
        {
            return new SuccessDataResult<List<News>>(_newsDal.ListNewsWithNewsCategoryPaging(page, pageSize));
        }

        public IDataResult<List<News>> ListNewsWithNewsCategoryPagingBycategoryId(int categoryId, int page, int pageSize)
        {
            return new SuccessDataResult<List<News>>(_newsDal.ListNewsWithNewsCategoryPagingBycategoryId(categoryId,page, pageSize));
        }

        public IDataResult<List<News>> ListNewsWithNewsCategoryPagingByCategoryTitle(string category, int page, int pageSize)
        {
            return new SuccessDataResult<List<News>>(_newsDal.ListNewsWithNewsCategoryPagingByCategoryTitle(category, page, pageSize));
        }

        public IDataResult<List<News>> ListNews()
        {
            return new SuccessDataResult<List<News>>(_newsDal.GetAll().ToList());
        }

        public IResult Update(News news)
        {
            _newsDal.Update(news);
            return new SuccessResult(Messages.Updated);
        }

        public IDataResult<News> GetNewsWithWebRadioBynewId(int newsId)
        {
            return new SuccessDataResult<News>(_newsDal.GetNewsWithWebRadioBynewId(newsId));
        }

        public IResult NewsRadioUpdate(News news, int[] categoryIds)
        {
            _newsDal.NewsRadioUpdate(news, categoryIds);
            return new SuccessResult(Messages.Updated);
        }

        public IDataResult<News> GetNewsWithNewsRadioBynewId(int newsId)
        {
            return new SuccessDataResult<News>(_newsDal.GetNewsWithNewsRadioBynewId(newsId));
        }

        public IDataResult<List<NewsDetail>> HomeManset(int count)
        {
            return new SuccessDataResult<List<NewsDetail>>(_newsDal.HomeManset(count));
        }

        public IDataResult<List<NewsDetail>> HomeOnecikan(int count)
        {
            return new SuccessDataResult<List<NewsDetail>>(_newsDal.HomeOnecikan(count));
        }

        public IDataResult<List<News>> ListNewsWithRadioApiPagingByradioApiIdAndArama(string aramametin, int radioApiId, int categoryId, int page, int pageSize)
        {
            return new SuccessDataResult<List<News>>(_newsDal.ListNewsWithRadioApiPagingByradioApiIdAndArama(aramametin,radioApiId, categoryId, page, pageSize));
        }

        public IDataResult<int> CountNewsByradioApiId(int radioApiId, int categoryId)
        {
            return new SuccessDataResult<int>(_newsDal.CountNewsByradioApiId(radioApiId, categoryId));
        }
    }
}
