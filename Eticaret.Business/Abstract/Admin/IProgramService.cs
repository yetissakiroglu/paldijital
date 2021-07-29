using Eticaret.Core.Utilities.Results;
using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eticaret.Business.Abstract.Admin
{
    public interface IProgramService
    {
        IDataResult<Program> GetProgramByprogramId(int programId);
        IDataResult<List<Program>> ListProgramByradioApiId(int radioApiId);
        IDataResult<List<Program>> ListProgram();
        IResult Create(Program program);
        IResult Update(Program program);
        IResult Delete(Program program);
        IDataResult<int> CountProgram();





        IDataResult<List<Program>> ListProgramWithRadioApi();
        IDataResult<List<Program>> ListProgramPaging(int page, int pageSize);
        IDataResult<List<Program>> ListProgramWithRadioApiPaging(int page, int pageSize);

        IDataResult<List<Program>> ListProgramWithRadioApiPagingByradioApiId(int radioApiId, int page, int pageSize);
        IDataResult<List<Program>> ListProgramWithRadioApiPagingByradioApiTitle(string radioApi, int page, int pageSize);
        IDataResult<Program> GetProgramWithRadioApiByprogramId(int programId);
        IDataResult<List<Program>> ListProgramWithRadioApiByradioApiId(int radioApiId);
        IDataResult<int> CountProgramByradioApiId(int radioApiId);
        //Arama
        IDataResult<List<Program>> ListProgramWithRadioApiAndAramaPaging(string aramametin, int page, int pageSize);
        //Arama
        IDataResult<List<Program>> ListProgramWithRadioApiPagingByradioApiIdAndArama(string aramametin, int radioApiId, int page, int pageSize);

    }
}
