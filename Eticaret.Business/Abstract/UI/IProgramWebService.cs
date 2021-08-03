using Eticaret.Core.Utilities.Results;
using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eticaret.Business.Abstract.UI
{
    public interface IProgramWebService
    {
        IDataResult<ProgramList> GetProgrambyId(int programId);
        IDataResult<List<ProgramList>> ListProgrambyId(int programId);
        IDataResult<List<ProgramList>> ListProgram();
        IDataResult<ProgramList> GetProgramWithPodcastListByprogramUrl(string pageUrl);

    }
}
