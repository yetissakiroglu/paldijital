using Eticaret.Business.Abstract.Admin;
using Eticaret.Business.Constants;
using Eticaret.Core.Utilities.Results;
using Eticaret.DataAccess.Abstract;
using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eticaret.Business.Concrete.Managers.Admin
{
    public class BannerManager : IBannerService
    {
        private IBannerDal _bannerDal;

        public BannerManager(IBannerDal bannerDal)
        {
            _bannerDal = bannerDal;
        }

        public IDataResult<int> CountBanners()
        {
            return new SuccessDataResult<int>(_bannerDal.GetAll().Count());
        }

        public IResult Create(Banner banner)
        {
            _bannerDal.Create(banner);
            return new SuccessResult(Messages.Creared);
        }

        public IResult Delete(Banner banner)
        {
            _bannerDal.Delete(banner);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<Banner> GetBannerBybannerId(int bannerId)
        {
            return new SuccessDataResult<Banner>(_bannerDal.Get(p => p.bannerId == bannerId));
        }



        public IDataResult<List<Banner>> ListBanner()
        {
            return new SuccessDataResult<List<Banner>>(_bannerDal.GetAll().ToList());
        }

        public IDataResult<List<Banner>> ListBannerPaging(int page, int pageSize)
        {
            return new SuccessDataResult<List<Banner>>(_bannerDal.ListBannerPaging(page,pageSize));
        }


        public IResult Update(Banner banner)
        {
            _bannerDal.Update(banner);
            return new SuccessResult(Messages.Updated);
        }
    }
}
