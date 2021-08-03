using Eticaret.Core.DataAccess.EntityFramework;
using Eticaret.Core.Entities.Concrete;
using Eticaret.DataAccess.Abstract.Admin;
using Eticaret.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eticaret.DataAccess.Concrete.EntityFrameworkCore.Admin
{
    public class EfRoleClaimsDal : EfEntityRepositoryBase<RoleClaims, WebDbContext>, IRoleClaimsDal
    {
    }
}
