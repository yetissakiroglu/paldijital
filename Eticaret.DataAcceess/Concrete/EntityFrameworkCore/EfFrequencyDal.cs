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
   public class EfFrequencyDal:EfEntityRepositoryBase<Frequency, WebDbContext>, IFrequencyDal
    {
        public int CountFrequencyByradioApiId(int radioApiId)
        {
            using (var context = new WebDbContext())
            {
                var news = context.Frequencys.AsQueryable();

                if (!string.IsNullOrEmpty(radioApiId.ToString()) && radioApiId != 0)
                {
                    news = news
                                .Include(i => i.RadioApi)
                                .Where(i => i.radioApiId == radioApiId);
                }
                return news.Count();
            }
        }

        public Frequency GetFrequencyWithRadioApiByFrequencyId(int FrequencyId)
        {
            using (var context = new WebDbContext())
            {
                return context.Frequencys
                             .Include(i => i.RadioApi)
                             .Where(i => i.frequencyId == FrequencyId).SingleOrDefault();

            }
        }

        public List<Frequency> ListFrequencyPaging(int page, int pageSize)
        {
            using (var context = new WebDbContext())
            {
                var news = context.Frequencys.AsQueryable();

                return news.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public List<Frequency> ListFrequencyWithRadioApi()
        {
            using (var context = new WebDbContext())
            {
                return context.Frequencys
                            .Include(i => i.RadioApi).ToList();

            }
        }

        public List<Frequency> ListFrequencyWithRadioApiAndAramaPaging(string aramametin, int page, int pageSize)
        {
            using (var context = new WebDbContext())
            {
                var news = context.Frequencys.AsQueryable();
                news = news
                            .Include(i => i.RadioApi);

                if (!string.IsNullOrEmpty(aramametin))
                {
                    news = news.Where(q => q.cityName.Contains(aramametin));
                }

                return news.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public List<Frequency> ListFrequencyWithRadioApiByradioApiId(int radioApiId)
        {
            using (var context = new WebDbContext())
            {
                return context.Frequencys
                            .Include(i => i.RadioApi)
                            .Where(i => i.radioApiId == radioApiId)
                            .ToList();
            }
        }

        public List<Frequency> ListFrequencyWithRadioApiPaging(int page, int pageSize)
        {
            using (var context = new WebDbContext())
            {
                var news = context.Frequencys.AsQueryable();
                news = news
                            .Include(i => i.RadioApi);
                return news.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public List<Frequency> ListFrequencyWithRadioApiPagingByradioApiId(int radioApiId, int page, int pageSize)
        {
            using (var context = new WebDbContext())
            {
                var news = context.Frequencys.AsQueryable();
                if (!string.IsNullOrEmpty(radioApiId.ToString()) && radioApiId != 0)
                {
                    news = news
                                .Include(i => i.RadioApi)
                                .Where(i => i.radioApiId == radioApiId);
                }


                return news.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public List<Frequency> ListFrequencyWithRadioApiPagingByradioApiIdAndArama(string aramametin, int radioApiId, int page, int pageSize)
        {
            using (var context = new WebDbContext())
            {
                var news = context.Frequencys.OrderByDescending(x => x.frequencyId).AsQueryable();
                if (!string.IsNullOrEmpty(radioApiId.ToString()) && radioApiId != 0)
                {
                    news = news
                                .Where(i => i.radioApiId == radioApiId);
                }
                
                news = news
                             .Include(i => i.RadioApi);

                if (!string.IsNullOrEmpty(aramametin))
                {
                    news = news.Where(q => q.cityName.Contains(aramametin));
                }

                return news.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public List<Frequency> ListFrequencyWithRadioApiPagingByradioApiTitle(string radioApi, int page, int pageSize)
        {
            using (var context = new WebDbContext())
            {
                var news = context.Frequencys.AsQueryable();
                if (!string.IsNullOrEmpty(radioApi))
                {
                    news = news
                                .Include(i => i.RadioApi)
                                .Where(i => i.cityName == radioApi);
                }
                return news.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }
    }
}
