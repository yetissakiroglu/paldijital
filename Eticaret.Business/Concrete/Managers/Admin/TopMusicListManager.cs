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
    public class TopMusicListManager : ITopMusicListService
    {

        private ITopMusicListDal _TopMusicListDal;

        public TopMusicListManager(ITopMusicListDal TopMusicListDal)
        {
            _TopMusicListDal = TopMusicListDal;
        }

        public IDataResult<int> CountTopMusicList()
        {
            return new SuccessDataResult<int>(_TopMusicListDal.GetAll().Count());
        }

        public IDataResult<int> CountTopMusicListByradioApiId(int radioApiId)
        {
            return new SuccessDataResult<int>(_TopMusicListDal.CountTopMusicListByradioApiId(radioApiId));
        }

        public IResult Create(TopMusicList TopMusicList)
        {
            _TopMusicListDal.Create(TopMusicList);
            return new SuccessResult(Messages.Creared);
        }

        public IResult Delete(TopMusicList TopMusicList)
        {
            _TopMusicListDal.Delete(TopMusicList);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<TopMusicList> GetTopMusicListByTopMusicListId(int TopMusicListId)
        {
            return new SuccessDataResult<TopMusicList>(_TopMusicListDal.Get(p => p.topmusicListId == TopMusicListId));
        }

        public IDataResult<TopMusicList> GetTopMusicListWithRadioApiByTopMusicListId(int TopMusicListId)
        {
            return new SuccessDataResult<TopMusicList>(_TopMusicListDal.GetTopMusicListWithRadioApiByTopMusicListId(TopMusicListId));
        }

        public IDataResult<List<TopMusicList>> ListTopMusicList()
        {
            return new SuccessDataResult<List<TopMusicList>>(_TopMusicListDal.GetAll().ToList());
        }

        public IDataResult<List<TopMusicList>> ListTopMusicListByradioApiId(int radioApiId)
        {
            return new SuccessDataResult<List<TopMusicList>>(_TopMusicListDal.GetAll(p => p.radioApiId == radioApiId).ToList());
        }

        public IDataResult<List<TopMusicList>> ListTopMusicListPaging(int page, int pageSize)
        {
            return new SuccessDataResult<List<TopMusicList>>(_TopMusicListDal.ListTopMusicListPaging(page, pageSize));
        }

            public IDataResult<List<TopMusicList>> ListTopMusicListWithRadioApi()
        {
            return new SuccessDataResult<List<TopMusicList>>(_TopMusicListDal.ListTopMusicListWithRadioApi());
        }

        public IDataResult<List<TopMusicList>> ListTopMusicListWithRadioApiAndAramaPaging(string aramametin, int page, int pageSize)
        {
            return new SuccessDataResult<List<TopMusicList>>(_TopMusicListDal.ListTopMusicListWithRadioApiAndAramaPaging(aramametin, page, pageSize));
        }

        public IDataResult<List<TopMusicList>> ListTopMusicListWithRadioApiByradioApiId(int radioApiId)
        {
            return new SuccessDataResult<List<TopMusicList>>(_TopMusicListDal.ListTopMusicListWithRadioApiByradioApiId(radioApiId));
        }

        public IDataResult<List<TopMusicList>> ListTopMusicListWithRadioApiPaging(int page, int pageSize)
        {
            return new SuccessDataResult<List<TopMusicList>>(_TopMusicListDal.ListTopMusicListWithRadioApiPaging(page, pageSize));
        }

        public IDataResult<List<TopMusicList>> ListTopMusicListWithRadioApiPagingByradioApiId(int radioApiId, int page, int pageSize)
        {
            return new SuccessDataResult<List<TopMusicList>>(_TopMusicListDal.ListTopMusicListWithRadioApiPagingByradioApiId(radioApiId, page, pageSize));
        }

        public IDataResult<List<TopMusicList>> ListTopMusicListWithRadioApiPagingByradioApiIdAndArama(string aramametin, int radioApiId, int page, int pageSize)
        {
            return new SuccessDataResult<List<TopMusicList>>(_TopMusicListDal.ListTopMusicListWithRadioApiPagingByradioApiIdAndArama(aramametin, radioApiId, page, pageSize));
        }

        public IDataResult<List<TopMusicList>> ListTopMusicListWithRadioApiPagingByradioApiIdAndDataArama(DateTime sData, DateTime fData, string aramametin, int radioApiId, int page, int pageSize)
        {
            return new SuccessDataResult<List<TopMusicList>>(_TopMusicListDal.ListTopMusicListWithRadioApiPagingByradioApiIdAndDataArama(sData,fData, aramametin, radioApiId, page, pageSize));
        }

        public IDataResult<List<TopMusicList>> ListTopMusicListWithRadioApiPagingByradioApiTitle(string radioApi, int page, int pageSize)
        {
            return new SuccessDataResult<List<TopMusicList>>(_TopMusicListDal.ListTopMusicListWithRadioApiPagingByradioApiTitle(radioApi, page, pageSize));
        }

        public IResult Update(TopMusicList TopMusicList)
        {
            _TopMusicListDal.Update(TopMusicList);
            return new SuccessResult(Messages.Updated);
        }
    }


}
