using Eticaret.Core.DataAccess;
using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eticaret.DataAccess.Abstract
{
    public interface IMusicListDal : IEntityRepository<MusicList>
    {
        List<MusicList> ListMusicListWithTopMusicList();
        List<MusicList> ListMusicListPaging(int page, int pageSize);
        List<MusicList> ListMusicListWithTopMusicListPaging(int page, int pageSize);

        //Arama
        List<MusicList> ListMusicListWithTopMusicListAndAramaPaging(string aramametin, int page, int pageSize);

        List<MusicList> ListMusicListWithTopMusicListPagingByTopmusicListId(int TopmusicListId, int page, int pageSize);

        //Arama
        List<MusicList> ListMusicListWithTopMusicListPagingByTopmusicListIdAndArama(string aramametin, int TopmusicListId, int page, int pageSize);

        List<MusicList> ListMusicListWithTopMusicListPagingByTopMusicListTitle(string TopmusicListId, int page, int pageSize);

        MusicList GetMusicListWithTopMusicListByMusicListId(int MusicListId);
        List<MusicList> ListMusicListWithTopMusicListByTopmusicListId(int TopmusicListId);
        int CountMusicListByTopmusicListId(int TopmusicListId);

    }
}
