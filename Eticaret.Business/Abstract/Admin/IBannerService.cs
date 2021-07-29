using Eticaret.Core.Utilities.Results;
using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eticaret.Business.Abstract.Admin
{
    public interface IBannerService
    {
        IDataResult<Banner> GetBannerBybannerId(int bannerId);
        IResult Create(Banner banner);
        IResult Update(Banner banner);
        IResult Delete(Banner banner);
        IDataResult<int> CountBanners();

        IDataResult<List<Banner>> ListBanner();
        IDataResult<List<Banner>> ListBannerPaging(int page, int pageSize);


    }
}
