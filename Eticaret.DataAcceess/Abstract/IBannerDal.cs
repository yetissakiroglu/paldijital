using Eticaret.Core.DataAccess;
using Eticaret.Core.Utilities.Results;
using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eticaret.DataAccess.Abstract
{
    public interface IBannerDal : IEntityRepository<Banner>
    {
        List<Banner> ListBannerPaging(int page, int pageSize);
        
    }
}
