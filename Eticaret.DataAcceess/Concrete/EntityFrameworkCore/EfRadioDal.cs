using Eticaret.Core.DataAccess.EntityFramework;
using Eticaret.DataAccess.Abstract;
using Eticaret.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using Eticaret.Entities.ComplexTypes;
using Eticaret.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eticaret.DataAccess.Concrete.EntityFrameworkCore
{
    public class EfRadioDal : EfEntityRepositoryBase<Radio, WebDbContext>, IRadioDal
    {
        public int CountRadiosBycategoryId(int categoryId)
        {

            using (var context = new WebDbContext())
            {
                var radios = context.Radios.AsQueryable();

                if (!string.IsNullOrEmpty(categoryId.ToString()))
                {
                    radios = radios
                                .Include(i => i.RadioCategory)
                                .Where(i => i.categoryId == categoryId);
                }
                return radios.Count();
            }
        }

        public Radio GetRadioWithRadioCategoryByradioId(int radioId)
        {
            using (var context = new WebDbContext())
            {
                return context.Radios.Include(i => i.RadioCategory).SingleOrDefault(x => x.radioId == radioId);
            }
        }

        public List<RadioDetail> ListRadioDetailWithRadioCategory()
        {
            using (var context = new WebDbContext())
            {
                var result = from p in context.Radios
                             join c in context.RadioCategories on p.categoryId equals c.categoryId
                             select new RadioDetail
                             {
                                 radioId = p.radioId,
                                 categoryId = p.categoryId,
                                 categoryTitle = c.title,
                                 categoryUrl = c.url,
                                 title = p.title,
                                 slogan = p.slogan,

                                 imgPath = p.imgPath,
                                 m3u8Url = p.m3u8Url,
                                 streamUrl = p.streamUrl,
                                 webUrl = p.streamUrl,
                                 row = p.row,
                                 webstatus = p.webstatus,
                                 mobilstatus = p.mobilstatus,

                             };
                result.ToList().AsQueryable();

                return result.Include(i => i.RadioCategory).ToList();

            }
        }

        public List<RadioDetail> ListRadioDetailWithRadioCategoryPaging(int page, int pageSize)
        {

            using (var context = new WebDbContext())
            {
                var result = from p in context.Radios
                             join c in context.RadioCategories on p.categoryId equals c.categoryId
                   
                             select new RadioDetail
                             {
                                 radioId = p.radioId,
                                 categoryId = c.categoryId,
                                 categoryTitle = c.title,
                                 categoryUrl = c.url,
                                 title = p.title,
                                 slogan = p.slogan,
                                 imgPath = p.imgPath,
                                 m3u8Url = p.m3u8Url,
                                 streamUrl = p.streamUrl,
                                 webUrl = p.streamUrl,
                                 row = p.row,
                                 webstatus = p.webstatus,
                                 mobilstatus = p.mobilstatus,

                             };

                return result.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public List<RadioDetail> ListRadioDetailWithRadioCategoryPagingBycategoryId(int categoryId, int page, int pageSize)
        {
            using (var context = new WebDbContext())
            {
                var result = from p in context.Radios
                             join c in context.RadioCategories on p.categoryId equals c.categoryId
                             select new RadioDetail
                             {
                                 radioId = p.radioId,
                                 categoryId = c.categoryId,
                                 categoryTitle = c.title,
                                 categoryUrl = c.url,
                                 title = p.title,
                                 slogan = p.slogan,

                                 imgPath = p.imgPath,
                                 m3u8Url = p.m3u8Url,
                                 streamUrl = p.streamUrl,
                                 webUrl = p.streamUrl,
                                 row = p.row,
                                 webstatus = p.webstatus,
                                 mobilstatus = p.mobilstatus,

                             };
                result.ToList().AsQueryable();


                if (!string.IsNullOrEmpty(categoryId.ToString()))
                {
                    result = result
                                .Include(i => i.RadioCategory)
                                .Where(i => i.categoryId == categoryId);
                }
                return result.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public List<RadioDetail> ListRadioDetailWithRadioCategoryPagingByCategoryTitle(string category, int page, int pageSize)
        {
            using (var context = new WebDbContext())
            {
                var result = from p in context.Radios
                             join c in context.RadioCategories on p.categoryId equals c.categoryId
                             select new RadioDetail
                             {
                                 radioId = p.radioId,
                                 categoryId = p.categoryId,
                                 categoryTitle = c.title,
                                 categoryUrl = c.url,
                                 title = p.title,
                                 slogan = p.slogan,

                                 imgPath = p.imgPath,
                                 m3u8Url = p.m3u8Url,
                                 streamUrl = p.streamUrl,
                                 webUrl = p.streamUrl,
                                 row = p.row,
                                 webstatus = p.webstatus,
                                 mobilstatus = p.mobilstatus,

                             };
                result.ToList().AsQueryable();


                if (!string.IsNullOrEmpty(category))
                {
                    result = result
                                .Include(i => i.RadioCategory)
                                .Where(i => i.title == category);
                }
                return result.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public List<Radio> ListRadioWithRadioCategory()
        {
            using (var context = new WebDbContext())
            {
                return context.Radios
                            .Include(i => i.RadioCategory).ToList();

            }
        }


        //Buraya bak proje için
        public List<Radio> ListRadioWithRadioCategoryBycategoryId(int categoryId)
        {
            using (var context = new WebDbContext())
            {
                return context.Radios
                            .Include(i => i.RadioCategory)
                            .Where(i => i.categoryId == categoryId)
                            .ToList();
            }
        }

        public List<Radio> ListRadioWithRadioCategoryPaging(int page, int pageSize)
        {
            using (var context = new WebDbContext())
            {
                var radios = context.Radios.AsQueryable();
                radios = radios
                            .Include(i => i.RadioCategory);
                return radios.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public List<Radio> ListRadioWithRadioCategoryPagingBycategoryId(int categoryId, int page, int pageSize)
        {
            using (var context = new WebDbContext())
            {
                var radios = context.Radios.AsQueryable();
                if (!string.IsNullOrEmpty(categoryId.ToString()))
                {
                    radios = radios
                                .Include(i => i.RadioCategory)
                                .Where(i => i.categoryId == categoryId);
                }
                return radios.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public List<Radio> ListRadioWithRadioCategoryPagingByCategoryTitle(string category, int page, int pageSize)
        {
            using (var context = new WebDbContext())
            {
                var radios = context.Radios.AsQueryable();
                if (!string.IsNullOrEmpty(category))
                {
                    radios = radios
                                .Include(i => i.RadioCategory)
                                .Where(i => i.title == category);
                }
                return radios.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }
               

        public List<RadioDetail> ListRadioWithRadioCategoryPagingByradioCategoryIdAndArama(string aramametin, int radiocategoryId, int page, int pageSize)
        {
            using (var context = new WebDbContext())
            {
                var result = from p in context.Radios
                             join c in context.RadioCategories on p.categoryId equals c.categoryId
                             select new RadioDetail
                             {
                                 radioId = p.radioId,
                                 categoryId = p.categoryId,
                                 categoryTitle = c.title,
                                 categoryUrl = c.url,
                                 title = p.title,
                                 slogan = p.slogan,

                                 imgPath = p.imgPath,
                                 m3u8Url = p.m3u8Url,
                                 streamUrl = p.streamUrl,
                                 webUrl = p.streamUrl,
                                 row = p.row,
                                 webstatus = p.webstatus,
                                 mobilstatus = p.mobilstatus,

                             };
                result.ToList().AsQueryable();

                if (!string.IsNullOrEmpty(aramametin))
                {
                    result = result.Where(q => q.title.Contains(aramametin));
                }

                if (!string.IsNullOrEmpty(radiocategoryId.ToString()) && radiocategoryId != 0)
                {
                    result = result.Where(i => i.categoryId == radiocategoryId);
                }


                return result.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        public List<Radio> ListRadioWithRadioCategoryAndAramaPaging(string aramametin, int page, int pageSize)
        {
            using (var context = new WebDbContext())
            {
                var result = context.Radios.AsQueryable();

                result = result
                            .Include(i => i.RadioCategory);
            
                if (!string.IsNullOrEmpty(aramametin))
                {
                    result = result.Where(q => q.title.Contains(aramametin));
                }

                return result.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }
    }
}
