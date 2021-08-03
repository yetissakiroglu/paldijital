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
    public class EfRadioApiDal : EfEntityRepositoryBase<RadioApi, WebDbContext>, IRadioApiDal
    {
        public List<RadioApi> ListRadioApiPaging(int page, int pageSize)
        {
            using (var context = new WebDbContext())
            {
                var categorys = context.RadioApi
                          .AsQueryable();
                return categorys.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public List<RadioApi> ListRadioApiWithFull()
        {
            using (var context = new WebDbContext())
            {
                return context.RadioApi
                        .Include(i => i.Frequencys)
                        .Include(i => i.Programs).ToList();
            }
        }

        public List<RadioApi> ListWebRadioWithNewsRadio()
        {
            using (var context = new WebDbContext())
            {
                return context.RadioApi
                        .Include(i => i.NewsRadioCategories).ToList();
            }
        }
    }
}
