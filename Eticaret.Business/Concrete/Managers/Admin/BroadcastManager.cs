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
   public class BroadcastManager:IBroadcastService
    {
        private IBroadcastDal _BroadcastDal;

        public BroadcastManager(IBroadcastDal BroadcastDal)
        {
            _BroadcastDal = BroadcastDal;
        }

        public IDataResult<int> CountBroadcast()
        {
            return new SuccessDataResult<int>(_BroadcastDal.GetAll().Count());
        }

        public IDataResult<int> CountBroadcastByradioApiId(int radioApiId)
        {
            return new SuccessDataResult<int>(_BroadcastDal.CountBroadcastByradioApiId(radioApiId));
        }

        public IResult Create(Broadcast Broadcast)
        {
            _BroadcastDal.Create(Broadcast);
            return new SuccessResult(Messages.Creared);
        }

        public IResult Delete(Broadcast Broadcast)
        {
            _BroadcastDal.Delete(Broadcast);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<Broadcast> GetBroadcastByBroadcastId(int BroadcastId)
        {
            return new SuccessDataResult<Broadcast>(_BroadcastDal.Get(p => p.broadcastId == BroadcastId));
        }

        public IDataResult<Broadcast> GetBroadcastWithRadioApiByBroadcastId(int BroadcastId)
        {
            return new SuccessDataResult<Broadcast>(_BroadcastDal.GetBroadcastWithRadioApiByBroadcastId(BroadcastId));
        }

        public IDataResult<List<Broadcast>> ListBroadcast()
        {
            return new SuccessDataResult<List<Broadcast>>(_BroadcastDal.GetAll().ToList());
        }

        public IDataResult<List<Broadcast>> ListBroadcastByradioApiId(int radioApiId)
        {
            return new SuccessDataResult<List<Broadcast>>(_BroadcastDal.GetAll(p => p.radioApiId == radioApiId).ToList());
        }

        public IDataResult<List<Broadcast>> ListBroadcastPaging(int page, int pageSize)
        {
            return new SuccessDataResult<List<Broadcast>>(_BroadcastDal.ListBroadcastPaging(page, pageSize));
        }

        public IDataResult<List<Broadcast>> ListBroadcastWithRadioApi()
        {
            return new SuccessDataResult<List<Broadcast>>(_BroadcastDal.ListBroadcastWithRadioApi());
        }

        public IDataResult<List<Broadcast>> ListBroadcastWithRadioApiAndAramaPaging(string aramametin, int page, int pageSize)
        {
            return new SuccessDataResult<List<Broadcast>>(_BroadcastDal.ListBroadcastWithRadioApiAndAramaPaging(aramametin, page, pageSize));
        }

        public IDataResult<List<Broadcast>> ListBroadcastWithRadioApiByradioApiId(int radioApiId)
        {
            return new SuccessDataResult<List<Broadcast>>(_BroadcastDal.ListBroadcastWithRadioApiByradioApiId(radioApiId));
        }

        public IDataResult<List<Broadcast>> ListBroadcastWithRadioApiPaging(int page, int pageSize)
        {
            return new SuccessDataResult<List<Broadcast>>(_BroadcastDal.ListBroadcastWithRadioApiPaging(page, pageSize));
        }

        public IDataResult<List<Broadcast>> ListBroadcastWithRadioApiPagingByradioApiId(int radioApiId, int page, int pageSize)
        {
            return new SuccessDataResult<List<Broadcast>>(_BroadcastDal.ListBroadcastWithRadioApiPagingByradioApiId(radioApiId, page, pageSize));
        }

        public IDataResult<List<Broadcast>> ListBroadcastWithRadioApiPagingByradioApiIdAndArama(string aramametin, int radioApiId, int page, int pageSize)
        {
            return new SuccessDataResult<List<Broadcast>>(_BroadcastDal.ListBroadcastWithRadioApiPagingByradioApiIdAndArama(aramametin, radioApiId, page, pageSize));
        }

        public IDataResult<List<Broadcast>> ListBroadcastWithRadioApiPagingByradioApiTitle(string radioApi, int page, int pageSize)
        {
            return new SuccessDataResult<List<Broadcast>>(_BroadcastDal.ListBroadcastWithRadioApiPagingByradioApiTitle(radioApi, page, pageSize));
        }

        public IResult Update(Broadcast Broadcast)
        {
            _BroadcastDal.Update(Broadcast);
            return new SuccessResult(Messages.Updated);
        }
    }
}
