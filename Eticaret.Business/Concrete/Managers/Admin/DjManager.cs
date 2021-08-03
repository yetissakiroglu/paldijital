using Eticaret.Business.Abstract.Admin;
using Eticaret.Business.Constants;
using Eticaret.Core.Utilities.Results;
using Eticaret.DataAccess.Abstract.Admin;
using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eticaret.Business.Concrete.Managers.Admin
{
    public class DjManager : IDjService
    {
        private IDjDal _djDal;

        public DjManager(IDjDal djDal)
        {
            _djDal = djDal;
        }

        public IDataResult<int> CountDj()
        {
            return new SuccessDataResult<int>(_djDal.GetAll().Count());
        }

        public IDataResult<int> CountDjByradioApiId(int radioApiId)
        {
            return new SuccessDataResult<int>(_djDal.CountDjByradioApiId(radioApiId));
        }

        public IResult Create(Dj dj)
        {
            _djDal.Create(dj);
            return new SuccessResult(Messages.Creared);
        }

        public IResult Delete(Dj dj)
        {
            _djDal.Delete(dj);
            return new SuccessResult(Messages.Deleted);
        }

        public IResult DjRadioCreate(Dj dj, int[] categoryIds)
        {
            _djDal.DjRadioCreate(dj, categoryIds);
            return new SuccessResult(Messages.Creared);
        }

        public IResult DjRadioUpdate(Dj dj, int[] categoryIds)
        {
            _djDal.DjRadioUpdate(dj, categoryIds);
            return new SuccessResult(Messages.Creared);
        }

        public IDataResult<Dj> GetDjBydjId(int djId)
        {
            return new SuccessDataResult<Dj>(_djDal.Get(p => p.djId == djId));
        }

        public IDataResult<Dj> GetDjWithRadioApiBydjId(int djId)
        {
            return new SuccessDataResult<Dj>(_djDal.GetDjWithRadioApiBydjId(djId));
        }

        public IDataResult<List<Dj>> ListDj()
        {
            return new SuccessDataResult<List<Dj>>(_djDal.GetAll().ToList());
        }

        public IDataResult<List<Dj>> ListDjByradioApiId(int radioApiId)
        {
            return new SuccessDataResult<List<Dj>>(_djDal.GetAll().ToList());
        }

        public IDataResult<List<Dj>> ListDjPaging(int page, int pageSize)
        {
            return new SuccessDataResult<List<Dj>>(_djDal.ListDjPaging(page, pageSize));
        }

        public IDataResult<List<Dj>> ListDjWithRadioApi()
        {
            return new SuccessDataResult<List<Dj>>(_djDal.ListDjWithRadioApi());
        }

        public IDataResult<List<Dj>> ListDjWithRadioApiAndAramaPaging(string aramametin, int page, int pageSize)
        {
            return new SuccessDataResult<List<Dj>>(_djDal.ListDjWithRadioApiAndAramaPaging(aramametin, page, pageSize));
        }

        public IDataResult<List<Dj>> ListDjWithRadioApiByradioApiId(int radioApiId)
        {
            return new SuccessDataResult<List<Dj>>(_djDal.ListDjWithRadioApiByradioApiId(radioApiId));
        }

        public IDataResult<List<Dj>> ListDjWithRadioApiPaging(int page, int pageSize)
        {
            return new SuccessDataResult<List<Dj>>(_djDal.ListDjWithRadioApiPaging(page, pageSize));
        }

        public IDataResult<List<Dj>> ListDjWithRadioApiPagingByradioApiId(int radioApiId, int page, int pageSize)
        {
            return new SuccessDataResult<List<Dj>>(_djDal.ListDjWithRadioApiPagingByradioApiId(radioApiId, page, pageSize));
        }

        public IDataResult<List<Dj>> ListDjWithRadioApiPagingByradioApiIdAndArama(string aramametin, int radioApiId, int page, int pageSize)
        {
            return new SuccessDataResult<List<Dj>>(_djDal.ListDjWithRadioApiPagingByradioApiIdAndArama(aramametin, radioApiId, page, pageSize));
        }

        public IDataResult<List<Dj>> ListDjWithRadioApiPagingByradioApiTitle(string radioApi, int page, int pageSize)
        {
            return new SuccessDataResult<List<Dj>>(_djDal.ListDjWithRadioApiPagingByradioApiTitle(radioApi, page, pageSize));
        }

        public IResult Update(Dj dj)
        {
            _djDal.Update(dj);
            return new SuccessResult(Messages.Updated);
        }
    }
}
