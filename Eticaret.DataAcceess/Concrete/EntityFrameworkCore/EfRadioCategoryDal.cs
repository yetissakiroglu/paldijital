using Eticaret.Core.DataAccess.EntityFramework;
using Microsoft.EntityFrameworkCore;

using Eticaret.DataAccess.Abstract;
using Eticaret.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Eticaret.DataAccess.Concrete.EntityFrameworkCore
{
    public class EfRadioCategoryDal : EfEntityRepositoryBase<RadioCategory, WebDbContext>, IRadioCategoryDal
    {
        public void DeleteFromRadioCategoryandRadios(RadioCategory radioCategory)
        {
            using (var context = new WebDbContext())
            {
                var cmdradio = @"delete from Radio where categoryId=@p1";
                context.Database.ExecuteSqlCommand(cmdradio, radioCategory.categoryId);

                var cmdcategory = @"delete from RadioCategory where categoryId=@p1";
                context.Database.ExecuteSqlCommand(cmdcategory, radioCategory.categoryId);
            }
        }

    

        public List<RadioCategory> ListRadioCategoryWithRadiosPaging(int page, int pageSize)
        {
            using (var context = new WebDbContext())
            {
                var categorys = context.RadioCategories
                          .Include(i => i.Radios)
                          .AsQueryable();
                return categorys.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }


        }

        public RadioCategory GetRadioCategoryWithRadiosBycategoryId(int categoryId)
        {
            using (var context = new WebDbContext())
            {
                return context.RadioCategories
                        .Where(i => i.categoryId == categoryId)
                        .Include(i => i.Radios)
                        .FirstOrDefault();
            }
        }

       

        public List<RadioCategory> ListRadioCategoryWithRadios()
        {
            using (var context = new WebDbContext())
            {
                return context.RadioCategories
                          .Include(i => i.Radios).ToList();
            }
        }

        
    }
}
