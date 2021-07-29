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

        public IResult Create(Program program)
        {
            _programDal.Create(program);
            return new SuccessResult(Messages.Creared);
        }

        public IResult Delete(Program program)
        {
            _programDal.Delete(program);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<Program> GetProgramByprogramId(int programId)
        {
            return new SuccessDataResult<Program>(_programDal.Get(p => p.programId == programId));
        }

        public IDataResult<Program> GetProgramWithRadioApiByprogramId(int programId)
        {
            return new SuccessDataResult<Program>(_programDal.GetProgramWithRadioApiByprogramId(programId));
        }

        public IDataResult<List<Program>> ListProgram()
        {
            return new SuccessDataResult<List<Program>>(_programDal.GetAll().ToList());
        }

        public IDataResult<List<Program>> ListProgramByradioApiId(int radioApiId)
        {
            return new SuccessDataResult<List<Program>>(_programDal.GetAll(p => p.radioApiId == radioApiId).ToList());
        }

        public IDataResult<List<Program>> ListProgramPaging(int page, int pageSize)
        {
            return new SuccessDataResult<List<Program>>(_programDal.ListProgramPaging(page,pageSize));
        }

        public IDataResult<List<Program>> ListProgramWithRadioApi()
        {
            return new SuccessDataResult<List<Program>>(_programDal.ListProgramWithRadioApi());
        }

        public IDataResult<List<Program>> ListProgramWithRadioApiAndAramaPaging(string aramametin, int page, int pageSize)
        {
            return new SuccessDataResult<List<Program>>(_programDal.ListProgramWithRadioApiAndAramaPaging(aramametin,page,pageSize));
        }

        public IDataResult<List<Program>> ListProgramWithRadioApiByradioApiId(int radioApiId)
        {
            return new SuccessDataResult<List<Program>>(_programDal.ListProgramWithRadioApiByradioApiId(radioApiId));
        }

        public IDataResult<List<Program>> ListProgramWithRadioApiPaging(int page, int pageSize)
        {
            return new SuccessDataResult<List<Program>>(_programDal.ListProgramWithRadioApiPaging(page, pageSize));
        }

        public IDataResult<List<Program>> ListProgramWithRadioApiPagingByradioApiId(int radioApiId, int page, int pageSize)
        {
            return new SuccessDataResult<List<Program>>(_programDal.ListProgramWithRadioApiPagingByradioApiId(radioApiId,page, pageSize));
        }

        public IDataResult<List<Program>> ListProgramWithRadioApiPagingByradioApiIdAndArama(string aramametin, int radioApiId, int page, int pageSize)
        {
            return new SuccessDataResult<List<Program>>(_programDal.ListProgramWithRadioApiPagingByradioApiIdAndArama(aramametin, radioApiId, page, pageSize));
        }

        public IDataResult<List<Program>> ListProgramWithRadioApiPagingByradioApiTitle(string radioApi, int page, int pageSize)
        {
            return new SuccessDataResult<List<Program>>(_programDal.ListProgramWithRadioApiPagingByradioApiTitle(radioApi, page, pageSize));
        }

        public IResult Update(Program program)
        {
            _programDal.Update(program);
            return new SuccessResult(Messages.Updated);
        }
    }
}
