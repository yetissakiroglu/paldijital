using Eticaret.Core.DataAccess.EntityFramework;
using Eticaret.DataAccess.Abstract;
using Eticaret.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using Eticaret.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eticaret.DataAccess.Concrete.EntityFrameworkCore
{
    public class EfPodcastMusicListDal : EfEntityRepositoryBase<PodcastMusicList, WebDbContext>, IPodcastMusicListDal
    {
        public int CountPodcastMusicListByProgramId(int ProgramId)
        {
            using (var context = new WebDbContext())
            {
                var news = context.PodcastMusicLists.AsQueryable();

                if (!string.IsNullOrEmpty(ProgramId.ToString()) && ProgramId != 0)
                {
                    news = news
                                .Include(i => i.Program)
                                .Where(i => i.programId == ProgramId);
                }
                return news.Count();
            }
        }

        public PodcastMusicList GetPodcastMusicListWithPodcastByMusicListId(int PodcastMusicListId)
        {
            using (var context = new WebDbContext())
            {
                return context.PodcastMusicLists
                             .Include(i => i.Program)
                             .Where(i => i.podcastMusicListId == PodcastMusicListId).SingleOrDefault();

            }
        }

        public List<PodcastMusicList> ListPodcastMusicListPaging(int page, int pageSize)
        {
            using (var context = new WebDbContext())
            {
                var news = context.PodcastMusicLists.AsQueryable().Include(i => i.Program).ToList();
                return news.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public List<PodcastMusicList> ListPodcastMusicListWithPodcast()
        {
            using (var context = new WebDbContext())
            {
                return context.PodcastMusicLists
                            .Include(i => i.Program).ToList();
            }
        }

        public List<PodcastMusicList> ListPodcastMusicListWithPodcastAndAramaPaging(string aramametin, int page, int pageSize)
        {
            using (var context = new WebDbContext())
            {
                var news = context.PodcastMusicLists.AsQueryable();
                news = news
                            .Include(i => i.Program);

                if (!string.IsNullOrEmpty(aramametin))
                {
                    news = news.Where(q => q.title.Contains(aramametin));
                }

                return news.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public List<PodcastMusicList> ListPodcastMusicListWithPodcastByProgramId(int ProgramId)
        {
            using (var context = new WebDbContext())
            {
                return context.PodcastMusicLists
                            .Include(i => i.Program)
                            .Where(i => i.programId == ProgramId)
                            .ToList();
            }
        }

        public List<PodcastMusicList> ListPodcastMusicListWithPodcastPaging(int page, int pageSize)
        {
            using (var context = new WebDbContext())
            {
                var news = context.PodcastMusicLists.AsQueryable();
                news = news
                            .Include(i => i.Program);
                return news.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public List<PodcastMusicList> ListPodcastMusicListWithPodcastPagingByProgramId(int ProgramId, int page, int pageSize)
        {
            using (var context = new WebDbContext())
            {
                var news = context.PodcastMusicLists.AsQueryable();
                if (!string.IsNullOrEmpty(ProgramId.ToString()) && ProgramId != 0)
                {
                    news = news
                                .Include(i => i.Program)
                                .Where(i => i.programId == ProgramId);
                }


                return news.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public List<PodcastMusicList> ListPodcastMusicListWithPodcastPagingByProgramIdAndArama(string aramametin, int ProgramId, int page, int pageSize)
        {
            using (var context = new WebDbContext())
            {
                var news = context.PodcastMusicLists.AsQueryable();
                if (!string.IsNullOrEmpty(ProgramId.ToString()) && ProgramId != 0)
                {
                    news = news
                                .Include(i => i.Program)
                                .Where(i => i.programId == ProgramId);
                }

                if (!string.IsNullOrEmpty(aramametin))
                {
                    news = news.Where(q => q.title.Contains(aramametin));
                }

                return news.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public List<PodcastMusicList> ListPodcastMusicListWithPodcastPagingByProgramTitle(string program, int page, int pageSize)
        {
            using (var context = new WebDbContext())
            {
                var news = context.PodcastMusicLists.AsQueryable();
                if (!string.IsNullOrEmpty(program))
                {
                    news = news
                                .Include(i => i.Program)
                                .Where(i => i.title == program);
                }
                return news.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public List<PodcastMusicList> ListPodcastMusicListWithProgramPagingByprogramIdAndDataArama(DateTime sData, DateTime fData, string aramametin, int ProgramId, int page, int pageSize)
        {
            using (var context = new WebDbContext())
            {
                var news = context.PodcastMusicLists.AsQueryable();


                if (!string.IsNullOrEmpty(ProgramId.ToString()) && ProgramId != 0)
                {
                    news = news.Where(i => i.programId == ProgramId);
                }

                if (!string.IsNullOrEmpty(aramametin))
                {
                    news = news.Where(q => q.title.Contains(aramametin));
                }

                news = news
                           .Include(i => i.Program);

                news = news.Where(q => q.startingDate >= sData && q.startingDate <= fData  );

        

                return news.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }
    }
}
