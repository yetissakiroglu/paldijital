using Eticaret.Core.DataAccess;
using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eticaret.DataAccess.Abstract
{
   public interface IProgramDal:IEntityRepository<Program>
    {


        List<Program> ListProgramWithRadioApi();
        List<Program> ListProgramPaging(int page, int pageSize);
        List<Program> ListProgramWithRadioApiPaging(int page, int pageSize);

        //Arama
        List<Program> ListProgramWithRadioApiAndAramaPaging(string aramametin,int page, int pageSize);

        List<Program> ListProgramWithRadioApiPagingByradioApiId(int radioApiId, int page, int pageSize);

        //Arama
        List<Program> ListProgramWithRadioApiPagingByradioApiIdAndArama(string aramametin,int radioApiId, int page, int pageSize);

        List<Program> ListProgramWithRadioApiPagingByradioApiTitle(string radioApi, int page, int pageSize);

        Program GetProgramWithRadioApiByprogramId(int programId);
        List<Program> ListProgramWithRadioApiByradioApiId(int radioApiId);
        int CountProgramByradioApiId(int radioApiId);

    }
}
 