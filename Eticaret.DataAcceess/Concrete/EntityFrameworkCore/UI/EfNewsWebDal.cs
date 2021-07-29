using Eticaret.Core.DataAccess.EntityFramework;
using Eticaret.DataAccess.Abstract.UI;
using Eticaret.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using Eticaret.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eticaret.DataAccess.Concrete.EntityFrameworkCore.UI
{
    public class EfNewsWebDal : EfEntityRepositoryBase<News, WebDbContext>, INewsWebDal
    {
        public News GetNewsWithNewsCategoryBynewsUrl(string pageUrl)
        {
            using (var context = new WebDbContext())
            {
                return context.News
                        .Where(i => i.url == pageUrl)
                        .Include(i => i.NewsCategory)
                        .FirstOrDefault();
            }
        }

        public List<News> ListNewsWithNewsCategoryPaging(int page, int pageSize)
        {
            using (var context = new WebDbContext())
            {
                var news = context.News.AsQueryable();
                news = news
                            .Include(i => i.NewsCategory);
                return news.OrderByDescending(p => p.newsId).Skip(page * pageSize).Take(pageSize).ToList();
                    
            }
        }

        public List<News> ListNewsWithNewsCategoryPagingByCategoryUrl(int page, int pageSize, string url)
        {
            using (var context = new WebDbContext())
            {
                var news = context.News.AsQueryable();
                news = news
                            .Include(i => i.NewsCategory);

                if (!string.IsNullOrEmpty(url))
                {
                    news = news.Where(i => i.NewsCategory.url == url);
                }

                return news.OrderByDescending(p => p.newsId).Skip(page * pageSize).Take(pageSize).ToList();

            }
        }
    }
}
