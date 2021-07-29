using Eticaret.Business.Abstract.Admin;
using Eticaret.Business.Constants;
using Eticaret.Core.Entities.Concrete;
using Eticaret.Core.Utilities.Results;
using Eticaret.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eticaret.Business.Concrete.Managers.Admin
{
    public class RoleClaimsManager : IRoleClaimsService

    {
        private IRoleClaimsDal _roleclaimsDal;

        public RoleClaimsManager(IRoleClaimsDal roleclaimsDal)
        {
            _roleclaimsDal = roleclaimsDal;
        }

        public IResult Create(RoleClaims roleClaims)
        {
            _roleclaimsDal.Create(roleClaims);
            return new SuccessResult(Messages.Creared);
        }

        public IResult Delete(RoleClaims roleClaims)
        {

            _roleclaimsDal.Delete(roleClaims);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<RoleClaims> GetById(int Id)
        {
            return new SuccessDataResult<RoleClaims>(_roleclaimsDal.Get(p => p.Id == Id));
        }

        public IDataResult<List<RoleClaims>> GetList()
        {
            return new SuccessDataResult<List<RoleClaims>>(_roleclaimsDal.GetAll().ToList());
        }

        public IDataResult<List<RoleClaims>> GetListByRoleId(string roleId)
        {
            return new SuccessDataResult<List<RoleClaims>>(_roleclaimsDal.GetAll(p => p.RoleId.Contains(roleId)).ToList());
        }

        public IResult Update(RoleClaims roleClaims)
        {
            _roleclaimsDal.Update(roleClaims);
            return new SuccessResult(Messages.Updated);
        }
    }

}
