using Eticaret.Core.Utilities.Results;
using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eticaret.Business.Abstract.UI
{
    public interface IBildirWebService
    {
        IDataResult<Bildir> GetBildirById(int Id);
        IDataResult<List<Bildir>> ListBildirById(int Id);
        IDataResult<List<Bildir>> ListBildir();
        IResult Create(Bildir bildir);
    }
}
