using Eticaret.Core.Utilities.Results;
using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eticaret.Business.Abstract.Admin
{
    public interface IProgramService
    {
        IDataResult<ProgramList> GetProgramByprogramId(int programId);
        IDataResult<List<ProgramList>> ListProgramByradioApiId(int radioApiId);
        IDataResult<List<ProgramList>> ListProgram();
        IResult Create(ProgramList program);
        IResult Update(ProgramList program);
        IResult Delete(ProgramList program);
        IDataResult<int> CountProgram();





        IDataResult<List<ProgramList>> ListProgramWithRadioApi();
        IDataResult<List<ProgramList>> ListProgramPaging(int page, int pageSize);
        IDataResult<List<ProgramList>> ListProgramWithRadioApiPaging(int page, int pageSize);

        IDataResult<List<ProgramList>> ListProgramWithRadioApiPagingByradioApiId(int radioApiId, int page, int pageSize);
        IDataResult<List<ProgramList>> ListProgramWithRadioApiPagingByradioApiTitle(string radioApi, int page, int pageSize);
        IDataResult<ProgramList> GetProgramWithRadioApiByprogramId(int programId);
        IDataResult<List<ProgramList>> ListProgramWithRadioApiByradioApiId(int radioApiId);
        IDataResult<int> CountProgramByradioApiId(int radioApiId);
        //Arama
        IDataResult<List<ProgramList>> ListProgramWithRadioApiAndAramaPaging(string aramametin, int page, int pageSize);
        //Arama
        IDataResult<List<ProgramList>> ListProgramWithRadioApiPagingByradioApiIdAndArama(string aramametin, int radioApiId, int page, int pageSize);

    }
}
