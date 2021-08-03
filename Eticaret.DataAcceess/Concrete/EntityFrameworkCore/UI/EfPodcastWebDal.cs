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
    public class EfPodcastWebDal : EfEntityRepositoryBase<PodcastMusicList, WebDbContext>, IPodcastWebDal
    {
        public PodcastMusicList GetPodcastWithProgrambypodcastId(int podcastId)
        {
            using (var context = new WebDbContext())
            {
                return context.PodcastMusicLists
                  .Where(i => i.podcastMusicListId == podcastId)
                  .Include(i => i.Program).FirstOrDefault();
            }
        }

        public List<PodcastMusicList> ListPodcastWithProgrambyProgramId(int programId)
        {

            using (var context = new WebDbContext())
            {
                return context.PodcastMusicLists
                  .Where(i => i.programId == programId)
                  .Include(i => i.Program).ToList();
            }

        }
    }
}
