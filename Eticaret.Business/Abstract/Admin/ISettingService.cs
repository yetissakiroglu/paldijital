using Eticaret.Core.Utilities.Results;
using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eticaret.Business.Abstract.Admin
{
    public interface ISettingService
    {
        IDataResult<Setting> GetbyId(int settingId);
        IDataResult<Setting> GetOne();

        IResult Create(Setting setting);
        IResult Update(Setting setting);
        IResult Delete(Setting setting);

    }
}
