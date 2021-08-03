using Eticaret.Core.DataAccess.EntityFramework;
using Eticaret.DataAccess.Abstract.Admin;
using Eticaret.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using Eticaret.Entities.ComplexTypes;
using Eticaret.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eticaret.DataAccess.Concrete.EntityFrameworkCore.Admin
{
    public class EfNewsDal : EfEntityRepositoryBase<News, WebDbContext>, INewsDal
    {

        public int CountNewsBycategoryId(int categoryId)
        {

            using (var context = new WebDbContext())
            {
                var news = context.News.AsQueryable();

                if (!string.IsNullOrEmpty(categoryId.ToString()) && categoryId != 0)
                {
                    news = news
                                .Include(i => i.NewsCategory)
                                .Where(i => i.categoryId == categoryId);
                }
                return news.Count();
            }
        }
        public List<NewsDetail> ListNewsDetailWithNewsCategoryPaging(int page, int pageSize)
        {
            using (var context = new WebDbContext())
            {
                var result = from p in context.News
                             join c in context.NewsCategories on p.categoryId equals c.categoryId
                             select new NewsDetail
                             {
                                 newsId = p.newsId,
                                 categoryId = p.categoryId,
                                 categoryTitle = c.title,
                                 categoryUrl = c.url,
                                 title = p.title,
                                 //keywords = p.keywords,
                                 //description = p.description,
                                 shortDetail = p.shortDetail,
                                 detail = p.detail,
                                 url = p.url,
                                 imgPath = p.imgPath,
                                 addTime = p.addTime,
                                 updateTime = p.updateTime,
                                 viewHit = p.viewHit,
                                 imgPathAm = p.imgPathAm,
                                 detailAm = p.detailAm,

                                 imgPathFp = p.imgPathFp,
                                 dLink = p.imgPathFp,
                                 aM = p.aM,
                                 oC = p.oC,
                                 hB = p.hB,
                                 sD = p.sD,
                                 oH = p.oH,
                                 row = p.row,
                                 status = p.status,

                             };
                result.ToList().AsQueryable();

                result = result
                              .Include(i => i.NewsCategory);

                return result.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }
        public List<NewsDetail> ListNewsDetailWithNewsCategoryPagingBycategoryId(int categoryId, int page, int pageSize)
        {
            using (var context = new WebDbContext())
            {
                var result = from p in context.News
                             join c in context.NewsCategories on p.categoryId equals c.categoryId
                             select new NewsDetail
                             {
                                 newsId = p.newsId,
                                 categoryId = p.categoryId,
                                 categoryTitle = c.title,
                                 categoryUrl = c.url,
                                 title = p.title,
                                 //keywords = p.keywords,
                                 //description = p.description,
                                 shortDetail = p.shortDetail,
                                 detail = p.detail,
                                 url = p.url,
                                 imgPath = p.imgPath,
                                 addTime = p.addTime,
                                 updateTime = p.updateTime,
                                 viewHit = p.viewHit,
                                 imgPathAm = p.imgPathAm,
                                 detailAm = p.detailAm,

                                 imgPathFp = p.imgPathFp,
                                 dLink = p.imgPathFp,
                                 aM = p.aM,
                                 oC = p.oC,
                                 hB = p.hB,
                                 sD = p.sD,
                                 oH = p.oH,
                                 row = p.row,
                                 status = p.status,

                             };
                result.ToList().AsQueryable();


                if (!string.IsNullOrEmpty(categoryId.ToString()) && categoryId != 0)
                {
                    result = result
                                .Include(i => i.NewsCategory)
                                .Where(i => i.categoryId == categoryId);
                }
                return result.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }

        }
        public News GetNewsWithNewsCategoryBynewId(int newId)
        {
            using (var context = new WebDbContext())
            {
                return context.News
                             .Include(i => i.NewsCategory)
                             .Where(i => i.newsId == newId).SingleOrDefault();

            }
        }
        public List<News> ListNewsWithNewsCategory()
        {
            using (var context = new WebDbContext())
            {
                return context.News
                            .Include(i => i.NewsCategory).ToList();

            }
        }
        public List<News> ListNewsWithNewsCategoryBycategoryId(int categoryId)
        {
            using (var context = new WebDbContext())
            {
                return context.News
                            .Include(i => i.NewsCategory)
                            .Where(i => i.categoryId == categoryId)
                            .ToList();
            }
        }
        public List<NewsDetail> ListNewsDetailsWithNewsCategory()
        {
            using (var context = new WebDbContext())
            {
                var result = from p in context.News
                             join c in context.NewsCategories on p.categoryId equals c.categoryId
                             select new NewsDetail
                             {
                                 newsId = p.newsId,
                                 categoryId = p.categoryId,
                                 categoryTitle = c.title,
                                 categoryUrl = c.url,
                                 title = p.title,
                                 //keywords = p.keywords,
                                 //description = p.description,
                                 shortDetail = p.shortDetail,
                                 detail = p.detail,
                                 url = p.url,
                                 imgPath = p.imgPath,
                                 addTime = p.addTime,
                                 updateTime = p.updateTime,
                                 viewHit = p.viewHit,
                                 imgPathAm = p.imgPathAm,
                                 detailAm = p.detailAm,
                                 imgPathFp = p.imgPathFp,
                                 dLink = p.imgPathFp,
                                 aM = p.aM,
                                 oC = p.oC,
                                 hB = p.hB,
                                 sD = p.sD,
                                 oH = p.oH,
                                 row = p.row,
                                 status = p.status,

                             };
                result.ToList().AsQueryable();

                return result.Include(i => i.NewsCategory).ToList();

            }
        }

        public List<NewsDetail> ListNewsDetailWithNewsCategoryPagingByCategoryTitle(string category, int page, int pageSize)
        {
            using (var context = new WebDbContext())
            {
                var result = from p in context.News
                             join c in context.NewsCategories on p.categoryId equals c.categoryId
                             select new NewsDetail
                             {
                                 newsId = p.newsId,
                                 categoryId = p.categoryId,
                                 categoryTitle = c.title,
                                 categoryUrl = c.url,
                                 title = p.title,
                                 //keywords = p.keywords,
                                 //description = p.description,
                                 shortDetail = p.shortDetail,
                                 detail = p.detail,
                                 url = p.url,
                                 imgPath = p.imgPath,
                                 addTime = p.addTime,
                                 updateTime = p.updateTime,
                                 viewHit = p.viewHit,
                                 imgPathAm = p.imgPathAm,
                                 detailAm = p.detailAm,
                                 imgPathFp = p.imgPathFp,
                                 dLink = p.imgPathFp,
                                 aM = p.aM,
                                 oC = p.oC,
                                 hB = p.hB,
                                 sD = p.sD,
                                 oH = p.oH,
                                 row = p.row,
                                 status = p.status,

                             };
                result.ToList().AsQueryable();


                if (!string.IsNullOrEmpty(category))
                {
                    result = result
                                .Include(i => i.NewsCategory)
                                .Where(i => i.title == category);
                }
                return result.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public List<News> ListNewsWithNewsCategoryPaging(int page, int pageSize)
        {
            using (var context = new WebDbContext())
            {
                var news = context.News.AsQueryable();
                news = news
                            .Include(i => i.NewsCategory);
                return news.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }
        public List<News> ListNewsWithNewsCategoryPagingBycategoryId(int categoryId, int page, int pageSize)
        {
            using (var context = new WebDbContext())
            {
                var news = context.News.AsQueryable();
                if (!string.IsNullOrEmpty(categoryId.ToString()))
                {
                    news = news
                                .Include(i => i.NewsCategory)
                                .Where(i => i.categoryId == categoryId);
                }
                return news.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }
        public List<News> ListNewsWithNewsCategoryPagingByCategoryTitle(string category, int page, int pageSize)
        {
            using (var context = new WebDbContext())
            {
                var news = context.News.AsQueryable();
                if (!string.IsNullOrEmpty(category))
                {
                    news = news
                                .Include(i => i.NewsCategory)
                                .Where(i => i.title == category);
                }
                return news.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public void NewsRadioUpdate(News news, int[] categoryIds)
        {
            using (var context = new WebDbContext())
            {
                var entity = context.News
                                   .Include(i => i.NewsRadios)
                  .FirstOrDefault(i => i.newsId == news.newsId);

                if (entity != null)
                {
                    entity.categoryId = news.categoryId;
                    entity.title = news.title;
                    //entity.keywords = news.keywords;
                    //entity.description = news.description;
                    entity.shortDetail = news.shortDetail;
                    entity.detail = news.detail;
                    entity.url = news.url;
                    entity.imgPath = news.imgPath;
                    entity.addTime = news.addTime;
                    entity.updateTime = news.updateTime;
                    entity.viewHit = news.viewHit;
                    entity.imgPathAm = news.imgPathAm;
                    entity.detailAm = news.detailAm;

                    entity.imgPathFp = news.imgPathFp;
                    entity.dLink = news.dLink;
                    entity.aM = news.aM;
                    entity.oC = news.oC;
                    entity.hB = news.hB;
                    entity.sD = news.sD;
                    entity.oH = news.oH;
                    entity.row = news.row;
                    entity.status = news.status;

                    entity.NewsRadios = categoryIds.Select(catid => new NewsRadio()
                    {
                        radioApiId = catid,
                        newsId = news.newsId
                    }).ToList();

                    context.SaveChanges();
                }
            }
        }

        public void NewsRadioCreate(News news, int[] categoryIds)
        {
            using (var context = new WebDbContext())
            {
                news.NewsRadios = categoryIds.Select(catid => new NewsRadio()
                {
                    radioApiId = catid,
                    newsId = news.newsId
                }).ToList();

                context.SaveChanges();

            }
        }

        public News GetNewsWithWebRadioBynewId(int newsId)
        {
            using (var context = new WebDbContext())
            {
                return context.News
                        .Where(i => i.newsId == newsId)
                        .Include(i => i.NewsRadios)
                        .ThenInclude(i => i.RadioApi)
                        .FirstOrDefault();
            }
        }

        public News GetNewsWithNewsRadioBynewId(int newsId)
        {
            using (var context = new WebDbContext())
            {
                return context.News
                        .Where(i => i.newsId == newsId)
                        .Include(i => i.NewsRadios)
                        .FirstOrDefault();
            }
        }

        public List<NewsDetail> HomeManset(int count)
        {
            using (var context = new WebDbContext())
            {
                var result = from p in context.News.Where(x => x.aM == true && x.status == true)
                             join c in context.NewsCategories on p.categoryId equals c.categoryId
                             select new NewsDetail
                             {
                                 newsId = p.newsId,
                                 categoryId = p.categoryId,
                                 categoryTitle = c.title,
                                 categoryUrl = c.url,
                                 title = p.title,
                                 //keywords = p.keywords,
                                 //description = p.description,
                                 shortDetail = p.shortDetail,
                                 detail = p.detail,
                                 url = p.url,
                                 imgPath = p.imgPath,
                                 addTime = p.addTime,
                                 updateTime = p.updateTime,
                                 viewHit = p.viewHit,
                                 detailAm = p.detailAm,
                                 imgPathAm = p.imgPathAm,
                                 imgPathFp = p.imgPathFp,
                                 dLink = p.imgPathFp,
                                 aM = p.aM,
                                 oC = p.oC,
                                 hB = p.hB,
                                 sD = p.sD,
                                 oH = p.oH,
                                 row = p.row,
                                 status = p.status,
                             };
                return result.ToList().OrderByDescending(x => x.addTime).Take(count).ToList();


            }
        }

        public List<NewsDetail> HomeOnecikan(int count)
        {
            using (var context = new WebDbContext())
            {
                var result = from p in context.News.Where(x => x.oC == true && x.status == true)
                             join c in context.NewsCategories on p.categoryId equals c.categoryId
                             select new NewsDetail
                             {
                                 newsId = p.newsId,
                                 categoryId = p.categoryId,
                                 categoryTitle = c.title,
                                 categoryUrl = c.url,
                                 title = p.title,
                                 //keywords = p.keywords,
                                 //description = p.description,
                                 shortDetail = p.shortDetail,
                                 detail = p.detail,
                                 url = p.url,
                                 imgPath = p.imgPath,
                                 addTime = p.addTime,
                                 updateTime = p.updateTime,
                                 viewHit = p.viewHit,
                                 detailAm = p.detailAm,
                                 imgPathAm = p.imgPathAm,
                                 imgPathFp = p.imgPathFp,
                                 dLink = p.imgPathFp,
                                 aM = p.aM,
                                 oC = p.oC,
                                 hB = p.hB,
                                 sD = p.sD,
                                 oH = p.oH,
                                 row = p.row,
                                 status = p.status,

                             };
                return result.ToList().OrderByDescending(x => x.addTime).Take(count).ToList();
            }
        }



        public List<News> ListNewsWithRadioApiPagingByradioApiIdAndArama(string aramametin, int radioApiId, int categoryId, int page, int pageSize)
        {
            using (var context = new WebDbContext())
            {

                var result = context.News.AsQueryable().OrderByDescending(x => x.newsId).AsQueryable();


                result = result
                              .Include(i => i.NewsCategory);


                if (!string.IsNullOrEmpty(aramametin))
                {
                    result = result.Where(q => q.title.Contains(aramametin));
                }

                if (!string.IsNullOrEmpty(categoryId.ToString()) && categoryId != 0)
                {
                    result = result
                                .Where(i => i.categoryId == categoryId);
                }

                if (!string.IsNullOrEmpty(radioApiId.ToString()) && radioApiId != 0)
                {
                    result = result
                                .Include(i => i.NewsRadios)
                                .ThenInclude(i => i.RadioApi)
                                 .Where(i => i.NewsRadios.Any(a => a.radioApiId == radioApiId));
                }

               return result.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public int CountNewsByradioApiId(int radioApiId, int categoryId)
        {
            using (var context = new WebDbContext())
            {
                var news = context.News.AsQueryable();

                if (!string.IsNullOrEmpty(categoryId.ToString()) && categoryId != 0)
                {
                    news = news
                                .Include(i => i.NewsCategory)
                                .Where(i => i.categoryId == categoryId);
                }

                if (!string.IsNullOrEmpty(radioApiId.ToString()) && radioApiId != 0)
                {
                    news = news
                        .Include(i => i.NewsCategory)
                                .Include(i => i.NewsRadios)
                                .ThenInclude(i => i.RadioApi)
                                 .Where(i => i.NewsRadios.Any(a => a.radioApiId == radioApiId));
                }

                return news.Count();
            }
        }
    }
}
