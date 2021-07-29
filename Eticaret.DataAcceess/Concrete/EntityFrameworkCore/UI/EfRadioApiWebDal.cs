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
    public class EfRadioApiWebDal : EfEntityRepositoryBase<RadioApi, WebDbContext>, IRadioApiWebDal
    {
   

        public RadioApi GetRadioApiWithFullByradioApiId(int radioApiId)
        {
            using (var context = new WebDbContext())
            {
                return context.RadioApi
                        .Where(i => i.radioApiId == radioApiId)
                        .Include(i => i.Frequencys)
                        .Include(i => i.Programs).FirstOrDefault();
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

        public List<RadioApi> ListRadioApiWithFullByradioApiId(int radioApiId)
        {
            using (var context = new WebDbContext())
            {
                return context.RadioApi
                        .Where(i => i.radioApiId == radioApiId)
                        .Include(i => i.Frequencys)
                        .Include(i => i.Programs).ToList();
            }
        }
    }
}
