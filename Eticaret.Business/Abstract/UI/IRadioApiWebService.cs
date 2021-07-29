using Eticaret.Core.Utilities.Results;
using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eticaret.Business.Abstract.UI
{
    public interface IRadioApiWebService
    {
        IDataResult<List<RadioApi>> ListRadioApiWithFull();
        IDataResult<RadioApi> GetRadioApiWithFullByradioApiId(int? radioapiId);
        IDataResult<List<RadioApi>> ListRadioApiWithFullByradioApiId(int? radioapiId);

   

    }
}
