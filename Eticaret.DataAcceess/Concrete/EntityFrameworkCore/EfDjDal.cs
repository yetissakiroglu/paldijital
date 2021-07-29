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
    public class EfDjDal : EfEntityRepositoryBase<Dj, WebDbContext>, IDjDal
    {
        public int CountDjByradioApiId(int radioApiId)
        {
            using (var context = new WebDbContext())
            {
                var news = context.Djs.AsQueryable();

                if (!string.IsNullOrEmpty(radioApiId.ToString()) && radioApiId != 0)
                {
                    //news = news
                    //            .Where(i => i.radioApiId == radioApiId);
                }
                return news.Count();
            }
        }

        public void DjRadioCreate(Dj djs, int[] categoryIds)
        {
            using (var context = new WebDbContext())
            {
                djs.DjsRadios = categoryIds.Select(catid => new DjRadio()
                {
                    radioApiId = catid,
                    djId = djs.djId
                }).ToList();

                context.SaveChanges();

            }
        }

        public void DjRadioUpdate(Dj djs, int[] categoryIds)
        {
            using (var context = new WebDbContext())
            {
                var entity = context.Djs
                                   .Include(i => i.DjsRadios)
                  .FirstOrDefault(i => i.djId == djs.djId);

                if (entity != null)
                {
                    entity.djId = djs.djId;
                    entity.title = djs.title;
                    entity.keywords = djs.keywords;
                    entity.description = djs.description;
                    entity.imgPath = djs.imgPath;
                    entity.detail = djs.detail;
                    entity.url = djs.url;
                    entity.fUrl = djs.fUrl;
                    entity.tUrl = djs.tUrl;
                    entity.iUrl = djs.iUrl;
                    entity.yUrl = djs.yUrl;
                    entity.spUrl = djs.spUrl;

                    entity.spUrl = djs.spUrl;
                    entity.row = djs.row;
                    entity.status = djs.status;
                    

                    entity.DjsRadios = categoryIds.Select(catid => new DjRadio()
                    {
                        radioApiId = catid,
                        djId = djs.djId
                    }).ToList();

                    context.SaveChanges();
                }
            }
        }

        public Dj GetDjWithRadioApiBydjId(int djId)
        {
            using (var context = new WebDbContext())
            {
                return context.Djs
                             .Where(i => i.djId == djId).SingleOrDefault();

            }
        }

        public List<Dj> ListDjPaging(int page, int pageSize)
        {
            using (var context = new WebDbContext())
            {
                var news = context.Djs.AsQueryable();

                return news.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public List<Dj> ListDjWithRadioApi()
        {
            using (var context = new WebDbContext())
            {
                return context.Djs.ToList();

            }
        }

        public List<Dj> ListDjWithRadioApiAndAramaPaging(string aramametin, int page, int pageSize)
        {
            using (var context = new WebDbContext())
            {
                var news = context.Djs.AsQueryable();

                if (!string.IsNullOrEmpty(aramametin))
                {
                    news = news.Where(q => q.title.Contains(aramametin));
                }

                return news.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public List<Dj> ListDjWithRadioApiByradioApiId(int radioApiId)
        {
            using (var context = new WebDbContext())
            {
                return context.Djs
                            //.Where(i => i.radioApiId == radioApiId)
                            .ToList();
            }
        }

        public List<Dj> ListDjWithRadioApiPaging(int page, int pageSize)
        {
            using (var context = new WebDbContext())
            {
                var news = context.Djs.AsQueryable();
                return news.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public List<Dj> ListDjWithRadioApiPagingByradioApiId(int radioApiId, int page, int pageSize)
        {
            using (var context = new WebDbContext())
            {
                var news = context.Djs.AsQueryable();
                if (!string.IsNullOrEmpty(radioApiId.ToString()) && radioApiId != 0)
                {
                    //news = news
                    //            .Where(i => i.radioApiId == radioApiId);
                }


                return news.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public List<Dj> ListDjWithRadioApiPagingByradioApiIdAndArama(string aramametin, int radioApiId, int page, int pageSize)
        {
            using (var context = new WebDbContext())
            {
                var news = context.Djs.AsQueryable();
                if (!string.IsNullOrEmpty(radioApiId.ToString()) && radioApiId != 0)
                {
                    //news = news.Where(i => i.radioApiId == radioApiId);
                }
                if (!string.IsNullOrEmpty(aramametin))
                {
                    news = news.Where(q => q.title.Contains(aramametin));
                }

                return news.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public List<Dj> ListDjWithRadioApiPagingByradioApiTitle(string radioApi, int page, int pageSize)
        {
            using (var context = new WebDbContext())
            {
                var news = context.Djs.AsQueryable();
                if (!string.IsNullOrEmpty(radioApi))
                {
                    news = news
                                .Where(i => i.title == radioApi);
                }
                return news.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }
    }
}
