using Eticaret.Core.DataAccess;
using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eticaret.DataAccess.Abstract
{
   public interface IProgramDal:IEntityRepository<ProgramList>
    {


        List<ProgramList> ListProgramWithRadioApi();
        List<ProgramList> ListProgramPaging(int page, int pageSize);
        List<ProgramList> ListProgramWithRadioApiPaging(int page, int pageSize);

        //Arama
        List<ProgramList> ListProgramWithRadioApiAndAramaPaging(string aramametin,int page, int pageSize);

        List<ProgramList> ListProgramWithRadioApiPagingByradioApiId(int radioApiId, int page, int pageSize);

        //Arama
        List<ProgramList> ListProgramWithRadioApiPagingByradioApiIdAndArama(string aramametin,int radioApiId, int page, int pageSize);

        List<ProgramList> ListProgramWithRadioApiPagingByradioApiTitle(string radioApi, int page, int pageSize);

        ProgramList GetProgramWithRadioApiByprogramId(int programId);
        List<ProgramList> ListProgramWithRadioApiByradioApiId(int radioApiId);
        int CountProgramByradioApiId(int radioApiId);

    }
}
 