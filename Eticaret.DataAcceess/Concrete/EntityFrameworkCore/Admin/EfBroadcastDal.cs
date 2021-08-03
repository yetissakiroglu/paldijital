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
    public class EfBroadcastDal : EfEntityRepositoryBase<Broadcast, WebDbContext>, IBroadcastDal
    {
        public int CountBroadcastByradioApiId(int radioApiId)
        {
            using (var context = new WebDbContext())
            {
                var news = context.Broadcasts.AsQueryable();

                if (!string.IsNullOrEmpty(radioApiId.ToString()) && radioApiId != 0)
                {
                    news = news
                                .Include(i => i.RadioApi)
                                .Where(i => i.radioApiId == radioApiId);
                }
                return news.Count();
            }
        }

        public Broadcast GetBroadcastWithRadioApiByBroadcastId(int BroadcastId)
        {
            using (var context = new WebDbContext())
            {
                return context.Broadcasts
                             .Include(i => i.RadioApi)
                             .Where(i => i.broadcastId == BroadcastId).SingleOrDefault();

            }
        }

        public List<Broadcast> ListBroadcastPaging(int page, int pageSize)
        {
            using (var context = new WebDbContext())
            {
                var news = context.Broadcasts.AsQueryable();

                return news.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public List<Broadcast> ListBroadcastWithRadioApi()
        {
            using (var context = new WebDbContext())
            {
                return context.Broadcasts
                            .Include(i => i.RadioApi).ToList();

            }
        }

        public List<Broadcast> ListBroadcastWithRadioApiAndAramaPaging(string aramametin, int page, int pageSize)
        {
            using (var context = new WebDbContext())
            {
                var news = context.Broadcasts.AsQueryable();
                news = news
                            .Include(i => i.RadioApi);

                if (!string.IsNullOrEmpty(aramametin))
                {
                    news = news.Where(q => q.title.Contains(aramametin));
                }

                return news.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public List<Broadcast> ListBroadcastWithRadioApiByradioApiId(int radioApiId)
        {
            using (var context = new WebDbContext())
            {
                return context.Broadcasts
                            .Include(i => i.RadioApi)
                            .Where(i => i.radioApiId == radioApiId)
                            .ToList();
            }
        }

        public List<Broadcast> ListBroadcastWithRadioApiPaging(int page, int pageSize)
        {
            using (var context = new WebDbContext())
            {
                var news = context.Broadcasts.AsQueryable();
                news = news
                            .Include(i => i.RadioApi);
                return news.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public List<Broadcast> ListBroadcastWithRadioApiPagingByradioApiId(int radioApiId, int page, int pageSize)
        {
            using (var context = new WebDbContext())
            {
                var news = context.Broadcasts.AsQueryable();
                if (!string.IsNullOrEmpty(radioApiId.ToString()) && radioApiId != 0)
                {
                    news = news
                                .Include(i => i.RadioApi)
                                .Where(i => i.radioApiId == radioApiId);
                }


                return news.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public List<Broadcast> ListBroadcastWithRadioApiPagingByradioApiIdAndArama(string aramametin, int radioApiId, int page, int pageSize)
        {
            using (var context = new WebDbContext())
            {
                var news = context.Broadcasts.AsQueryable();
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

                return news.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public List<Broadcast> ListBroadcastWithRadioApiPagingByradioApiTitle(string radioApi, int page, int pageSize)
        {
            using (var context = new WebDbContext())
            {
                var news = context.Broadcasts.AsQueryable();
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
