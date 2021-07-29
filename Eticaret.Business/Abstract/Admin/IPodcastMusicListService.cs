using Eticaret.Core.Utilities.Results;
using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eticaret.Business.Abstract.Admin
{
    public interface IPodcastMusicListService
    {
        IDataResult<PodcastMusicList> GetPodcastMusicListByPodcastMusicListId(int PodcastMusicListId);
        IDataResult<List<PodcastMusicList>> ListPodcastMusicListByProgramId(int ProgramId);
        IDataResult<List<PodcastMusicList>> ListPodcastMusicList();
        IResult Create(PodcastMusicList PodcastMusicList);
        IResult Update(PodcastMusicList PodcastMusicList);
        IResult Delete(PodcastMusicList PodcastMusicList);
        IDataResult<int> CountPodcastMusicList();

        IDataResult<List<PodcastMusicList>> ListPodcastMusicListWithPodcast();
        IDataResult<List<PodcastMusicList>> ListPodcastMusicListPaging(int page, int pageSize);
        IDataResult<List<PodcastMusicList>> ListPodcastMusicListWithPodcastPaging(int page, int pageSize);
        //Arama
        IDataResult<List<PodcastMusicList>> ListPodcastMusicListWithPodcastAndAramaPaging(string aramametin, int page, int pageSize);
        IDataResult<List<PodcastMusicList>> ListPodcastMusicListWithPodcastPagingByProgramId(int ProgramId, int page, int pageSize);
        //Arama
        IDataResult<List<PodcastMusicList>> ListPodcastMusicListWithPodcastPagingByProgramIdAndArama(string aramametin, int ProgramId, int page, int pageSize);

        IDataResult<List<PodcastMusicList>> ListPodcastMusicListWithProgramPagingByprogramIdAndDataArama(DateTime sData, DateTime fData, string aramametin, int ProgramId, int page, int pageSize);


        IDataResult<List<PodcastMusicList>> ListPodcastMusicListWithPodcastPagingByProgramTitle(string program, int page, int pageSize);
        IDataResult<PodcastMusicList> GetPodcastMusicListWithPodcastByMusicListId(int PodcastMusicListId);
        IDataResult<List<PodcastMusicList>> ListPodcastMusicListWithPodcastByProgramId(int ProgramId);
        IDataResult<int> CountPodcastMusicListByProgramId(int ProgramId);


    }
}
