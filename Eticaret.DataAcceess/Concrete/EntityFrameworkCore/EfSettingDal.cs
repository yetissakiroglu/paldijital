using Eticaret.Core.DataAccess.EntityFramework;
using Eticaret.DataAccess.Abstract;
using Eticaret.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eticaret.DataAccess.Concrete.EntityFrameworkCore
{
    public class EfSettingDal : EfEntityRepositoryBase<Setting, WebDbContext>, ISettingDal
    {
    }
}
