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
    public class EfProgramWebDal : EfEntityRepositoryBase<ProgramList, WebDbContext>, IProgramWebDal
    {
        public ProgramList GetProgramWithPodcastListByprogramUrl(string pageUrl)
        {
            using (var context = new WebDbContext())
            {
                return context.Programs
                  .Where(i => i.url == pageUrl)
                  .Include(i => i.PodcastMusicLists)
                  .FirstOrDefault();
            }
        }
    }
}
