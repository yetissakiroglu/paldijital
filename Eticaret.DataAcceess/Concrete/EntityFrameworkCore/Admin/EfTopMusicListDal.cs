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
    public class EfTopMusicListDal : EfEntityRepositoryBase<TopMusicList, WebDbContext>, ITopMusicListDal
    {
        public int CountTopMusicListByradioApiId(int radioApiId)
        {
            using (var context = new WebDbContext())
            {
                var news = context.TopMusicLists.AsQueryable();

                if (!string.IsNullOrEmpty(radioApiId.ToString()) && radioApiId != 0)
                {
                    news = news
                                .Include(i => i.RadioApi)
                                .Where(i => i.radioApiId == radioApiId);
                }
                return news.Count();
            }
        }

        public TopMusicList GetTopMusicListWithRadioApiByTopMusicListId(int TopMusicListId)
        {
            using (var context = new WebDbContext())
            {
                return context.TopMusicLists
                             .Include(i => i.RadioApi)
                             .Where(i => i.topmusicListId == TopMusicListId).SingleOrDefault();

            }
        }

        public List<TopMusicList> ListTopMusicListPaging(int page, int pageSize)
        {
            using (var context = new WebDbContext())
            {
                var news = context.TopMusicLists.AsQueryable();

                return news.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public List<TopMusicList> ListTopMusicListWithMusicListWithRadioApi()
        {
            using (var context = new WebDbContext())
            {
                return context.TopMusicLists
                            .Include(i => i.RadioApi)
                                 .Include(i => i.MusicLists).ToList();

            }
        }

        public List<TopMusicList> ListTopMusicListWithRadioApi()
        {
            using (var context = new WebDbContext())
            {
                return context.TopMusicLists
                            .Include(i => i.RadioApi).ToList();

            }
        }

        public List<TopMusicList> ListTopMusicListWithRadioApiAndAramaPaging(string aramametin, int page, int pageSize)
        {
            using (var context = new WebDbContext())
            {
                var news = context.TopMusicLists.AsQueryable();
                news = news
                            .Include(i => i.RadioApi);

                if (!string.IsNullOrEmpty(aramametin))
                {
                    news = news.Where(q => q.title.Contains(aramametin));
                }

                return news.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public List<TopMusicList> ListTopMusicListWithRadioApiByradioApiId(int radioApiId)
        {
            using (var context = new WebDbContext())
            {
                return context.TopMusicLists
                            .Include(i => i.RadioApi)
                            .Where(i => i.radioApiId == radioApiId)
                            .ToList();
            }
        }

        public List<TopMusicList> ListTopMusicListWithRadioApiPaging(int page, int pageSize)
        {
            using (var context = new WebDbContext())
            {
                var news = context.TopMusicLists.AsQueryable();
                news = news
                            .Include(i => i.RadioApi);
                return news.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public List<TopMusicList> ListTopMusicListWithRadioApiPagingByradioApiId(int radioApiId, int page, int pageSize)
        {
            using (var context = new WebDbContext())
            {
                var news = context.TopMusicLists.AsQueryable();
                if (!string.IsNullOrEmpty(radioApiId.ToString()) && radioApiId != 0)
                {
                    news = news
                                .Include(i => i.RadioApi)
                                .Where(i => i.radioApiId == radioApiId);
                }


                return news.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public List<TopMusicList> ListTopMusicListWithRadioApiPagingByradioApiIdAndArama(string aramametin, int radioApiId, int page, int pageSize)
        {
            using (var context = new WebDbContext())
            {
                var news = context.TopMusicLists.AsQueryable();
           

                if (!string.IsNullOrEmpty(radioApiId.ToString()) && radioApiId != 0)
                {
                    news = news
                                .Include(i => i.RadioApi)
                                .Where(i => i.radioApiId == radioApiId);
                }

                if (!string.IsNullOrEmpty(aramametin))
                {
                    news = news.Where(q => q.title.Contains(aramametin));
                }

                news = news
                          .Include(i => i.MusicLists);

                return news.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public List<TopMusicList> ListTopMusicListWithRadioApiPagingByradioApiIdAndDataArama(DateTime sData, DateTime fData, string aramametin, int radioApiId, int page, int pageSize)
        {
            using (var context = new WebDbContext())
            {
                var news = context.TopMusicLists.AsQueryable();


                if (!string.IsNullOrEmpty(radioApiId.ToString()) && radioApiId != 0)
                {
                    news = news.Where(i => i.radioApiId == radioApiId);
                }

                if (!string.IsNullOrEmpty(aramametin))
                {
                    news = news.Where(q => q.title.Contains(aramametin));
                }

                news = news .Include(i => i.RadioApi);

                //news = news.Where(q => q.startDate >= sData && q.finishDate <= fData);

                news = news
                          .Include(i => i.MusicLists);

                return news.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public List<TopMusicList> ListTopMusicListWithRadioApiPagingByradioApiTitle(string radioApi, int page, int pageSize)
        {
            using (var context = new WebDbContext())
            {
                var news = context.TopMusicLists.AsQueryable();
                if (!string.IsNullOrEmpty(radioApi))
                {
                    news = news
                                .Include(i => i.RadioApi)
                                .Where(i => i.title == radioApi);
                }
                return news.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }


    }
}
