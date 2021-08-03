using Eticaret.Core.DataAccess;
using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eticaret.DataAccess.Abstract.Admin
{
    public interface IBannerDal : IEntityRepository<Banner>
    {
        List<Banner> ListBannerPaging(int page, int pageSize);
        
    }
}
