using Eticaret.Business.Abstract.Admin;
using Eticaret.Business.Constants;
using Eticaret.Core.Utilities.Results;
using Eticaret.DataAccess.Abstract;
using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eticaret.Business.Concrete.Managers.Admin
{
    public class ProgramManager : IProgramService
    {
        private IProgramDal _programDal;

        public ProgramManager(IProgramDal programDal)
        {
            _programDal = programDal;
        }

        public IDataResult<int> CountProgram()
        {
            return new SuccessDataResult<int>(_programDal.GetAll().Count());
        }

        public IDataResult<int> CountProgramByradioApiId(int radioApiId)
        {
            return new SuccessDataResult<int>(_programDal.CountProgramByradioApiId(radioApiId));
        }

        public IResult Create(ProgramList program)
        {
            _programDal.Create(program);
            return new SuccessResult(Messages.Creared);
        }

        public IResult Delete(ProgramList program)
        {
            _programDal.Delete(program);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<ProgramList> GetProgramByprogramId(int programId)
        {
            return new SuccessDataResult<ProgramList>(_programDal.Get(p => p.programId == programId));
        }

        public IDataResult<ProgramList> GetProgramWithRadioApiByprogramId(int programId)
        {
            return new SuccessDataResult<ProgramList>(_programDal.GetProgramWithRadioApiByprogramId(programId));
        }

        public IDataResult<List<ProgramList>> ListProgram()
        {
            return new SuccessDataResult<List<ProgramList>>(_programDal.GetAll().ToList());
        }

        public IDataResult<List<ProgramList>> ListProgramByradioApiId(int radioApiId)
        {
            return new SuccessDataResult<List<ProgramList>>(_programDal.GetAll(p => p.radioApiId == radioApiId).ToList());
        }

        public IDataResult<List<ProgramList>> ListProgramPaging(int page, int pageSize)
        {
            return new SuccessDataResult<List<ProgramList>>(_programDal.ListProgramPaging(page,pageSize));
        }

        public IDataResult<List<ProgramList>> ListProgramWithRadioApi()
        {
            return new SuccessDataResult<List<ProgramList>>(_programDal.ListProgramWithRadioApi());
        }

        public IDataResult<List<ProgramList>> ListProgramWithRadioApiAndAramaPaging(string aramametin, int page, int pageSize)
        {
            return new SuccessDataResult<List<ProgramList>>(_programDal.ListProgramWithRadioApiAndAramaPaging(aramametin,page,pageSize));
        }

        public IDataResult<List<ProgramList>> ListProgramWithRadioApiByradioApiId(int radioApiId)
        {
            return new SuccessDataResult<List<ProgramList>>(_programDal.ListProgramWithRadioApiByradioApiId(radioApiId));
        }

        public IDataResult<List<ProgramList>> ListProgramWithRadioApiPaging(int page, int pageSize)
        {
            return new SuccessDataResult<List<ProgramList>>(_programDal.ListProgramWithRadioApiPaging(page, pageSize));
        }

        public IDataResult<List<ProgramList>> ListProgramWithRadioApiPagingByradioApiId(int radioApiId, int page, int pageSize)
        {
            return new SuccessDataResult<List<ProgramList>>(_programDal.ListProgramWithRadioApiPagingByradioApiId(radioApiId,page, pageSize));
        }

        public IDataResult<List<ProgramList>> ListProgramWithRadioApiPagingByradioApiIdAndArama(string aramametin, int radioApiId, int page, int pageSize)
        {
            return new SuccessDataResult<List<ProgramList>>(_programDal.ListProgramWithRadioApiPagingByradioApiIdAndArama(aramametin, radioApiId, page, pageSize));
        }

        public IDataResult<List<ProgramList>> ListProgramWithRadioApiPagingByradioApiTitle(string radioApi, int page, int pageSize)
        {
            return new SuccessDataResult<List<ProgramList>>(_programDal.ListProgramWithRadioApiPagingByradioApiTitle(radioApi, page, pageSize));
        }

        public IResult Update(ProgramList program)
        {
            _programDal.Update(program);
            return new SuccessResult(Messages.Updated);
        }
    }
}
