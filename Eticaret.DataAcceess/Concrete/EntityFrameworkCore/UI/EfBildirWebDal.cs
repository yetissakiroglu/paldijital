using Eticaret.Core.DataAccess.EntityFramework;
using Eticaret.DataAccess.Abstract.UI;
using Eticaret.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eticaret.DataAccess.Concrete.EntityFrameworkCore.UI
{
    public class EfBildirWebDal : EfEntityRepositoryBase<Bildir, WebDbContext>, IBildirWebDal
    {
    }
}
