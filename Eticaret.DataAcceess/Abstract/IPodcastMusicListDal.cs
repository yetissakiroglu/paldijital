using Eticaret.Core.DataAccess;
using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eticaret.DataAccess.Abstract
{
   public interface IPodcastMusicListDal:IEntityRepository<PodcastMusicList>
    {
        List<PodcastMusicList> ListPodcastMusicListWithPodcast();
        List<PodcastMusicList> ListPodcastMusicListPaging(int page, int pageSize);
        List<PodcastMusicList> ListPodcastMusicListWithPodcastPaging(int page, int pageSize);
        //Arama
        List<PodcastMusicList> ListPodcastMusicListWithPodcastAndAramaPaging(string aramametin, int page, int pageSize);
        List<PodcastMusicList> ListPodcastMusicListWithPodcastPagingByProgramId(int ProgramId, int page, int pageSize);
        //Arama
        List<PodcastMusicList> ListPodcastMusicListWithPodcastPagingByProgramIdAndArama(string aramametin, int ProgramId, int page, int pageSize);

        //Arama
        List<PodcastMusicList> ListPodcastMusicListWithProgramPagingByprogramIdAndDataArama(DateTime sData, DateTime fData, string aramametin, int ProgramId, int page, int pageSize);


        List<PodcastMusicList> ListPodcastMusicListWithPodcastPagingByProgramTitle(string program, int page, int pageSize);
        PodcastMusicList GetPodcastMusicListWithPodcastByMusicListId(int PodcastMusicListId);
        List<PodcastMusicList> ListPodcastMusicListWithPodcastByProgramId(int ProgramId);
        int CountPodcastMusicListByProgramId(int ProgramId);
    }
}
