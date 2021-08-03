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
    public class EfProgramDal : EfEntityRepositoryBase<ProgramList, WebDbContext>, IProgramDal
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

        public ProgramList GetProgramWithRadioApiByprogramId(int programId)
        {
            using (var context = new WebDbContext())
            {
                return context.Programs
                             .Include(i => i.RadioApi)
                             .Where(i => i.programId == programId).SingleOrDefault();

            }
        }


        public List<ProgramList> ListProgramWithRadioApi()
        {
            using (var context = new WebDbContext())
            {
                return context.Programs
                            .Include(i => i.RadioApi).ToList();

            }
        }

        public List<ProgramList> ListProgramWithRadioApiByradioApiId(int radioApiId)
        {
            using (var context = new WebDbContext())
            {
                return context.Programs
                            .Include(i => i.RadioApi)
                            .Where(i => i.radioApiId == radioApiId)
                            .ToList();
            }
        }

        public List<ProgramList> ListProgramPaging(int page, int pageSize)
        {
            using (var context = new WebDbContext())
            {
                var news = context.Programs.AsQueryable();

                return news.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public List<ProgramList> ListProgramWithRadioApiPaging(int page, int pageSize)
        {
            using (var context = new WebDbContext())
            {
                var news = context.Programs.AsQueryable();
                news = news
                            .Include(i => i.RadioApi);
                return news.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public List<ProgramList> ListProgramWithRadioApiPagingByradioApiId(int radioApiId, int page, int pageSize)
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

        public List<ProgramList> ListProgramWithRadioApiPagingByradioApiTitle(string radioApi, int page, int pageSize)
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

        public List<ProgramList> ListProgramWithRadioApiAndAramaPaging(string aramametin, int page, int pageSize)
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

        public List<ProgramList> ListProgramWithRadioApiPagingByradioApiIdAndArama(string aramametin, int radioApiId, int page, int pageSize)
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
