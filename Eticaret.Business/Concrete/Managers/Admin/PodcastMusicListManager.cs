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
    public class PodcastMusicListManager : IPodcastMusicListService
    {
        private IPodcastMusicListDal _PodcastMusicListDal;

        public PodcastMusicListManager(IPodcastMusicListDal PodcastMusicListDal)
        {
            _PodcastMusicListDal = PodcastMusicListDal;
        }

        public IDataResult<int> CountPodcastMusicList()
        {
            return new SuccessDataResult<int>(_PodcastMusicListDal.GetAll().Count());
        }


        public IDataResult<int> CountPodcastMusicListByProgramId(int ProgramId)
        {
            return new SuccessDataResult<int>(_PodcastMusicListDal.CountPodcastMusicListByProgramId(ProgramId));
        }

        public IResult Create(PodcastMusicList PodcastMusicList)
        {
            _PodcastMusicListDal.Create(PodcastMusicList);
            return new SuccessResult(Messages.Creared);
        }

        public IResult Delete(PodcastMusicList PodcastMusicList)
        {
            _PodcastMusicListDal.Delete(PodcastMusicList);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<PodcastMusicList> GetPodcastMusicListByPodcastMusicListId(int PodcastMusicListId)
        {
            return new SuccessDataResult<PodcastMusicList>(_PodcastMusicListDal.Get(p => p.podcastMusicListId == PodcastMusicListId));
        }

        public IDataResult<PodcastMusicList> GetPodcastMusicListWithPodcastByMusicListId(int PodcastMusicListId)
        {
            return new SuccessDataResult<PodcastMusicList>(_PodcastMusicListDal.GetPodcastMusicListWithPodcastByMusicListId(PodcastMusicListId));
        }

        public IDataResult<List<PodcastMusicList>> ListPodcastMusicList()
        {
            return new SuccessDataResult<List<PodcastMusicList>>(_PodcastMusicListDal.GetAll().ToList());
        }

        public IDataResult<List<PodcastMusicList>> ListPodcastMusicListByProgramId(int ProgramId)
        {
            return new SuccessDataResult<List<PodcastMusicList>>(_PodcastMusicListDal.GetAll(p => p.programId == ProgramId).ToList());
        }

        public IDataResult<List<PodcastMusicList>> ListPodcastMusicListPaging(int page, int pageSize)
        {
            return new SuccessDataResult<List<PodcastMusicList>>(_PodcastMusicListDal.ListPodcastMusicListPaging(page, pageSize));
        }

        public IDataResult<List<PodcastMusicList>> ListPodcastMusicListWithPodcast()
        {
            return new SuccessDataResult<List<PodcastMusicList>>(_PodcastMusicListDal.ListPodcastMusicListWithPodcast());
        }

        public IDataResult<List<PodcastMusicList>> ListPodcastMusicListWithPodcastAndAramaPaging(string aramametin, int page, int pageSize)
        {
            return new SuccessDataResult<List<PodcastMusicList>>(_PodcastMusicListDal.ListPodcastMusicListWithPodcastAndAramaPaging(aramametin, page, pageSize));
        }

        public IDataResult<List<PodcastMusicList>> ListPodcastMusicListWithPodcastByProgramId(int ProgramId)
        {
            return new SuccessDataResult<List<PodcastMusicList>>(_PodcastMusicListDal.ListPodcastMusicListWithPodcastByProgramId(ProgramId));
        }

        public IDataResult<List<PodcastMusicList>> ListPodcastMusicListWithPodcastPaging(int page, int pageSize)
        {
            return new SuccessDataResult<List<PodcastMusicList>>(_PodcastMusicListDal.ListPodcastMusicListWithPodcastPaging(page, pageSize));
        }

        public IDataResult<List<PodcastMusicList>> ListPodcastMusicListWithPodcastPagingByProgramId(int ProgramId, int page, int pageSize)
        {
            return new SuccessDataResult<List<PodcastMusicList>>(_PodcastMusicListDal.ListPodcastMusicListWithPodcastPagingByProgramId(ProgramId, page, pageSize));
        }

        public IDataResult<List<PodcastMusicList>> ListPodcastMusicListWithPodcastPagingByProgramIdAndArama(string aramametin, int ProgramId, int page, int pageSize)
        {
            return new SuccessDataResult<List<PodcastMusicList>>(_PodcastMusicListDal.ListPodcastMusicListWithPodcastPagingByProgramIdAndArama(aramametin, ProgramId, page, pageSize));
        }

        public IDataResult<List<PodcastMusicList>> ListPodcastMusicListWithPodcastPagingByProgramTitle(string program, int page, int pageSize)
        {
            return new SuccessDataResult<List<PodcastMusicList>>(_PodcastMusicListDal.ListPodcastMusicListWithPodcastPagingByProgramTitle(program, page, pageSize));
        }

        public IDataResult<List<PodcastMusicList>> ListPodcastMusicListWithProgramPagingByprogramIdAndDataArama(DateTime sData, DateTime fData, string aramametin, int ProgramId, int page, int pageSize)
        {
            return new SuccessDataResult<List<PodcastMusicList>>(_PodcastMusicListDal.ListPodcastMusicListWithProgramPagingByprogramIdAndDataArama(sData,fData,aramametin,ProgramId, page, pageSize));
        }

        public IResult Update(PodcastMusicList PodcastMusicList)
        {
            _PodcastMusicListDal.Update(PodcastMusicList);
            return new SuccessResult(Messages.Updated);
        }
    }
}
