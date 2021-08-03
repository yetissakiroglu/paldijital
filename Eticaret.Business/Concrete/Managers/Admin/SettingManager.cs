using Eticaret.Business.Abstract.Admin;
using Eticaret.Business.Constants;
using Eticaret.Core.Utilities.Results;
using Eticaret.DataAccess.Abstract.Admin;
using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eticaret.Business.Concrete.Managers.Admin
{
    public class SettingManager : ISettingService
    {
        private ISettingDal _settingDal;

        public SettingManager(ISettingDal settingDal)
        {
            _settingDal = settingDal;
        }
        public IResult Create(Setting setting)
        {
            _settingDal.Create(setting);
            return new SuccessResult(Messages.Creared);
        }

        public IResult Delete(Setting setting)
        {
            _settingDal.Delete(setting);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<Setting> GetbyId(int settingId)
        {
            return new SuccessDataResult<Setting>(_settingDal.Get(p => p.settingId == settingId));
        }

        public IDataResult<Setting> GetOne()
        {
            return new SuccessDataResult<Setting>(_settingDal.GetOne());
        }

        public IResult Update(Setting setting)
        {
            _settingDal.Update(setting);
            return new SuccessResult(Messages.Updated);
        }
    }
}
