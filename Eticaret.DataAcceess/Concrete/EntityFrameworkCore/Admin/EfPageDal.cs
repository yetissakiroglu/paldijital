using Eticaret.Core.DataAccess.EntityFramework;
using Eticaret.DataAccess.Abstract.Admin;
using Eticaret.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eticaret.DataAccess.Concrete.EntityFrameworkCore.Admin
{
    public class EfPageDal : EfEntityRepositoryBase<Page, WebDbContext>, IPageDal
    {

    }
}
