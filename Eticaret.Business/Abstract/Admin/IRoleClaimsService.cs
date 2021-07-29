using Eticaret.Core.Entities.Concrete;
using Eticaret.Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eticaret.Business.Abstract.Admin
{
    public interface IRoleClaimsService
    {

        IDataResult<RoleClaims> GetById(int Id);
        IDataResult<List<RoleClaims>> GetListByRoleId(string roleId);
        IDataResult<List<RoleClaims>> GetList();
        IResult Create(RoleClaims roleClaims);
        IResult Delete(RoleClaims roleClaims);
        IResult Update(RoleClaims roleClaims);
    }

}
