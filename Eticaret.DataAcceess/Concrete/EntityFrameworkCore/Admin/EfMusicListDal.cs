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
    public class EfMusicListDal : EfEntityRepositoryBase<MusicList, WebDbContext>, IMusicListDal
    {
        public int CountMusicListByTopmusicListId(int TopmusicListId)
        {
            using (var context = new WebDbContext())
            {
                var news = context.MusicLists.AsQueryable();

                if (!string.IsNullOrEmpty(TopmusicListId.ToString()) && TopmusicListId != 0)
                {
                    news = news
                                .Where(i => i.topmusicListId == TopmusicListId);
                }

                news = news
                              .Include(i => i.TopMusicList);

                return news.Count();
            }
        }

        public MusicList GetMusicListWithTopMusicListByMusicListId(int MusicListId)
        {
            using (var context = new WebDbContext())
            {
                return context.MusicLists
                             .Include(i => i.TopMusicList)
                             .Where(i => i.musicListId == MusicListId).SingleOrDefault();

            }
        }

        public List<MusicList> ListMusicListPaging(int page, int pageSize)
        {
            using (var context = new WebDbContext())
            {
                var news = context.MusicLists.AsQueryable().Include(i => i.TopMusicList).ToList();
                return news.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public List<MusicList> ListMusicListWithTopMusicList()
        {
            using (var context = new WebDbContext())
            {
                return context.MusicLists
                            .Include(i => i.TopMusicList).ToList();
            }
        }

        public List<MusicList> ListMusicListWithTopMusicListAndAramaPaging(string aramametin, int page, int pageSize)
        {
            using (var context = new WebDbContext())
            {
                var news = context.MusicLists.AsQueryable();
                news = news
                            .Include(i => i.TopMusicList);

                if (!string.IsNullOrEmpty(aramametin))
                {
                    news = news.Where(q => q.singerName.Contains(aramametin));
                }

                return news.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public List<MusicList> ListMusicListWithTopMusicListByTopmusicListId(int TopmusicListId)
        {
            using (var context = new WebDbContext())
            {
                return context.MusicLists
                            .Include(i => i.TopMusicList)
                            .Where(i => i.topmusicListId == TopmusicListId)
                            .ToList();
            }
        }

        public List<MusicList> ListMusicListWithTopMusicListPaging(int page, int pageSize)
        {
            using (var context = new WebDbContext())
            {
                var news = context.MusicLists.AsQueryable();
                news = news
                            .Include(i => i.TopMusicList);
                return news.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public List<MusicList> ListMusicListWithTopMusicListPagingByTopmusicListId(int TopmusicListId, int page, int pageSize)
        {
            using (var context = new WebDbContext())
            {
                var news = context.MusicLists.AsQueryable();
                if (!string.IsNullOrEmpty(TopmusicListId.ToString()) && TopmusicListId != 0)
                {
                    news = news
                                .Include(i => i.TopMusicList)
                                .Where(i => i.topmusicListId == TopmusicListId);
                }


                return news.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public List<MusicList> ListMusicListWithTopMusicListPagingByTopmusicListIdAndArama(string aramametin, int TopmusicListId, int page, int pageSize)
        {
            using (var context = new WebDbContext())
            {
                var news = context.MusicLists.AsQueryable();
                if (!string.IsNullOrEmpty(TopmusicListId.ToString()) && TopmusicListId != 0)
                {
                    news = news.Where(i => i.topmusicListId == TopmusicListId);
                }

                if (!string.IsNullOrEmpty(aramametin))
                {
                    news = news.Where(q => q.songName.Contains(aramametin));
                }

                news = news.Include(i => i.TopMusicList);
      

                return news.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public List<MusicList> ListMusicListWithTopMusicListPagingByTopMusicListTitle(string TopmusicListId, int page, int pageSize)
        {
            using (var context = new WebDbContext())
            {
                var news = context.MusicLists.AsQueryable();
                if (!string.IsNullOrEmpty(TopmusicListId))
                {
                    news = news
                                .Include(i => i.TopMusicList)
                                .Where(i => i.singerName == TopmusicListId);
                }
                return news.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }
    }
}
