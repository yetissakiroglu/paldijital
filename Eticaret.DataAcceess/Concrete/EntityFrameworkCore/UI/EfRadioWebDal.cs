using Eticaret.Core.DataAccess.EntityFramework;
using Eticaret.DataAccess.Abstract.UI;
using Eticaret.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using Eticaret.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Eticaret.DataAccess.Concrete.EntityFrameworkCore.UI
{
    public class EfRadioWebDal : EfEntityRepositoryBase<Radio, WebDbContext>, IRadioWebDal
    {


    }
}
