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
    public class MusicListManager : IMusicListService
    {
        private IMusicListDal _MusicListDal;

        public MusicListManager(IMusicListDal MusicListDal)
        {
            _MusicListDal = MusicListDal;
        }

        public IDataResult<int> CountMusicList()
        {
            return new SuccessDataResult<int>(_MusicListDal.GetAll().Count());
        }

        public IDataResult<int> CountMusicListByTopmusicListId(int TopmusicListId)
        {
            return new SuccessDataResult<int>(_MusicListDal.CountMusicListByTopmusicListId(TopmusicListId));
        }

        public IResult Create(MusicList MusicList)
        {
            _MusicListDal.Create(MusicList);
            return new SuccessResult(Messages.Creared);
        }

        public IResult Delete(MusicList MusicList)
        {
            _MusicListDal.Delete(MusicList);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<MusicList> GetMusicListByMusicListId(int MusicListId)
        {
            return new SuccessDataResult<MusicList>(_MusicListDal.Get(p => p.musicListId == MusicListId));
        }

        public IDataResult<MusicList> GetMusicListWithTopMusicListByMusicListId(int MusicListId)
        {
            return new SuccessDataResult<MusicList>(_MusicListDal.GetMusicListWithTopMusicListByMusicListId(MusicListId));
        }

        public IDataResult<List<MusicList>> ListMusicList()
        {
            return new SuccessDataResult<List<MusicList>>(_MusicListDal.GetAll().ToList());
        }

        public IDataResult<List<MusicList>> ListMusicListByTopMusicListId(int TopMusicListId)
        {
            return new SuccessDataResult<List<MusicList>>(_MusicListDal.GetAll(p => p.topmusicListId == TopMusicListId).ToList());
        }

        public IDataResult<List<MusicList>> ListMusicListPaging(int page, int pageSize)
        {
            return new SuccessDataResult<List<MusicList>>(_MusicListDal.ListMusicListPaging(page, pageSize));
        }

        public IDataResult<List<MusicList>> ListMusicListWithTopMusicList()
        {
            return new SuccessDataResult<List<MusicList>>(_MusicListDal.ListMusicListWithTopMusicList());
        }

        public IDataResult<List<MusicList>> ListMusicListWithTopMusicListAndAramaPaging(string aramametin, int page, int pageSize)
        {
            return new SuccessDataResult<List<MusicList>>(_MusicListDal.ListMusicListWithTopMusicListAndAramaPaging(aramametin, page, pageSize));
        }

        public IDataResult<List<MusicList>> ListMusicListWithTopMusicListByTopmusicListId(int TopmusicListId)
        {
            return new SuccessDataResult<List<MusicList>>(_MusicListDal.ListMusicListWithTopMusicListByTopmusicListId(TopmusicListId));
        }

        public IDataResult<List<MusicList>> ListMusicListWithTopMusicListPaging(int page, int pageSize)
        {
            return new SuccessDataResult<List<MusicList>>(_MusicListDal.ListMusicListWithTopMusicListPaging(page, pageSize));
        }

        public IDataResult<List<MusicList>> ListMusicListWithTopMusicListPagingByTopmusicListId(int TopmusicListId, int page, int pageSize)
        {
            return new SuccessDataResult<List<MusicList>>(_MusicListDal.ListMusicListWithTopMusicListPagingByTopmusicListId(TopmusicListId, page, pageSize));
        }

        public IDataResult<List<MusicList>> ListMusicListWithTopMusicListPagingByTopmusicListIdAndArama(string aramametin, int TopmusicListId, int page, int pageSize)
        {
            return new SuccessDataResult<List<MusicList>>(_MusicListDal.ListMusicListWithTopMusicListPagingByTopmusicListIdAndArama(aramametin, TopmusicListId, page, pageSize));
        }

        public IDataResult<List<MusicList>> ListMusicListWithTopMusicListPagingByTopMusicListTitle(string TopmusicListId, int page, int pageSize)
        {
            return new SuccessDataResult<List<MusicList>>(_MusicListDal.ListMusicListWithTopMusicListPagingByTopMusicListTitle(TopmusicListId, page, pageSize));
        }

        public IResult Update(MusicList MusicList)
        {
            _MusicListDal.Update(MusicList);
            return new SuccessResult(Messages.Updated);
        }
    }
}
