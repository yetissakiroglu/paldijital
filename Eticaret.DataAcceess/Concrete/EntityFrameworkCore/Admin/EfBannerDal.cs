using Eticaret.Core.DataAccess.EntityFramework;
using Eticaret.Core.Utilities.Results;
using Eticaret.DataAccess.Abstract.Admin;
using Eticaret.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eticaret.DataAccess.Concrete.EntityFrameworkCore.Admin
{
    public class EfBannerDal : EfEntityRepositoryBase<Banner, WebDbContext>, IBannerDal
    {
        public List<Banner> ListBannerPaging(int page, int pageSize)
        {
            using (var context = new WebDbContext())
            {
                var categorys = context.Banners.AsQueryable();

                return categorys.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }
    }
}
