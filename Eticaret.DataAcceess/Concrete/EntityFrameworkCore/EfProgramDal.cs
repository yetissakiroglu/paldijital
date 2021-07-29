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
    public class EfProgramDal : EfEntityRepositoryBase<Program, WebDbContext>, IProgramDal
    {
        public int CountProgramByradioApiId(int radioApiId)
        {
            using (var context = new WebDbContext())
            {
                var news = context.Programs.AsQueryable();

                if (!string.IsNullOrEmpty(radioApiId.ToString()) && radioApiId!=0)
                {
                    news = news
                                .Include(i => i.RadioApi)
                                .Where(i => i.radioApiId == radioApiId);
                }
                return news.Count();
            }
        }

        public Program GetProgramWithRadioApiByprogramId(int programId)
        {
            using (var context = new WebDbContext())
            {
                return context.Programs
                             .Include(i => i.RadioApi)
                             .Where(i => i.programId == programId).SingleOrDefault();

            }
        }


        public List<Program> ListProgramWithRadioApi()
        {
            using (var context = new WebDbContext())
            {
                return context.Programs
                            .Include(i => i.RadioApi).ToList();

            }
        }

        public List<Program> ListProgramWithRadioApiByradioApiId(int radioApiId)
        {
            using (var context = new WebDbContext())
            {
                return context.Programs
                            .Include(i => i.RadioApi)
                            .Where(i => i.radioApiId == radioApiId)
                            .ToList();
            }
        }

        public List<Program> ListProgramPaging(int page, int pageSize)
        {
            using (var context = new WebDbContext())
            {
                var news = context.Programs.AsQueryable();

                return news.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public List<Program> ListProgramWithRadioApiPaging(int page, int pageSize)
        {
            using (var context = new WebDbContext())
            {
                var news = context.Programs.AsQueryable();
                news = news
                            .Include(i => i.RadioApi);
                return news.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public List<Program> ListProgramWithRadioApiPagingByradioApiId(int radioApiId, int page, int pageSize)
        {
            using (var context = new WebDbContext())
            {
                var news = context.Programs.AsQueryable();
                if (!string.IsNullOrEmpty(radioApiId.ToString()) && radioApiId!=0)
                {
                    news = news
                                .Include(i => i.RadioApi)
                                .Where(i => i.radioApiId == radioApiId);
                }
      

                return news.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public List<Program> ListProgramWithRadioApiPagingByradioApiTitle(string radioApi, int page, int pageSize)
        {
            using (var context = new WebDbContext())
            {
                var news = context.Programs.AsQueryable();
                if (!string.IsNullOrEmpty(radioApi))
                {
                    news = news
                                .Include(i => i.RadioApi)
                                .Where(i => i.title == radioApi);
                }
                return news.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public List<Program> ListProgramWithRadioApiAndAramaPaging(string aramametin, int page, int pageSize)
        {
            using (var context = new WebDbContext())
            {
                var news = context.Programs.AsQueryable();
                news = news
                            .Include(i => i.RadioApi);

                if (!string.IsNullOrEmpty(aramametin))
                {
                    news = news.Where(q => q.title.Contains(aramametin));
                }

                return news.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }

         

        }

        public List<Program> ListProgramWithRadioApiPagingByradioApiIdAndArama(string aramametin, int radioApiId, int page, int pageSize)
        {
            using (var context = new WebDbContext())
            {
                var news = context.Programs.AsQueryable();
                if (!string.IsNullOrEmpty(radioApiId.ToString()) && radioApiId != 0)
                {
                    news = news.Where(i => i.radioApiId == radioApiId);
                }

                if (!string.IsNullOrEmpty(aramametin))
                {
                    news = news.Where(q => q.title.Contains(aramametin));
                }
                news = news.Include(i => i.RadioApi);

                return news.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }

                 }
    }
}
