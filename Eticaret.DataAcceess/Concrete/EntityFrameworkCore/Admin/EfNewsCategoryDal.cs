using Eticaret.Core.DataAccess.EntityFramework;
using Eticaret.DataAccess.Abstract.Admin;
using Eticaret.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using Eticaret.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eticaret.DataAccess.Concrete.EntityFrameworkCore.Admin
{
    public class EfNewsCategoryDal : EfEntityRepositoryBase<NewsCategory, WebDbContext>, INewsCategoryDal
    {
        public NewsCategory GetNewsCategoryWithNewsBycategoryId(int categoryId)
        {
            using (var context = new WebDbContext())
            {
                return context.NewsCategories
                        .Where(i => i.categoryId == categoryId)
                        .Include(i => i.News)
                        .FirstOrDefault();
            }
        }

        public List<NewsCategory> ListNewsCategoryWithNewsPaging(int page, int pageSize)
        {
            using (var context = new WebDbContext())
            {
                var categorys = context.NewsCategories
                          .Include(i => i.News)
                          .AsQueryable();
                return categorys.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public List<NewsCategory> ListNewsCategoryWithNews()
        {
            using (var context = new WebDbContext())
            {
                return context.NewsCategories
                          .Include(i => i.News).ToList();
            }
        }
    }
}
