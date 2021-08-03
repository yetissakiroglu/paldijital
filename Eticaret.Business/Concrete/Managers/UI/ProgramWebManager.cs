using Eticaret.Business.Abstract.UI;
using Eticaret.Core.Utilities.Results;
using Eticaret.DataAccess.Abstract.UI;
using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eticaret.Business.Concrete.Managers.UI
{
    public class ProgramWebManager : IProgramWebService
    {
        private IProgramWebDal _programWebDal;

        public ProgramWebManager(IProgramWebDal programWebDal)
        {
            _programWebDal = programWebDal;
        }
        public IDataResult<ProgramList> GetProgrambyId(int programId)
        {
            return new SuccessDataResult<ProgramList>(_programWebDal.Get(p => p.programId == programId));
        }

        public IDataResult<ProgramList> GetProgramWithPodcastListByprogramUrl(string pageUrl)
        {
            return new SuccessDataResult<ProgramList>(_programWebDal.GetProgramWithPodcastListByprogramUrl(pageUrl));
        }

        public IDataResult<List<ProgramList>> ListProgram()
        {
            return new SuccessDataResult<List<ProgramList>>(_programWebDal.GetAll().ToList());
        }

        public IDataResult<List<ProgramList>> ListProgrambyId(int programId)
        {
            return new SuccessDataResult<List<ProgramList>>(_programWebDal.GetAll(p => p.programId == programId).ToList());
        }
    }
}
