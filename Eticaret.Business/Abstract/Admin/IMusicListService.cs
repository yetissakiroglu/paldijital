using Eticaret.Core.Utilities.Results;
using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eticaret.Business.Abstract.Admin
{
    public interface IMusicListService
    {
        IDataResult<MusicList> GetMusicListByMusicListId(int MusicListId);
        IDataResult<List<MusicList>> ListMusicListByTopMusicListId(int TopMusicListId);
        IDataResult<List<MusicList>> ListMusicList();
        IResult Create(MusicList MusicList);
        IResult Update(MusicList MusicList);
        IResult Delete(MusicList MusicList);
        IDataResult<int> CountMusicList();


        IDataResult<List<MusicList>> ListMusicListWithTopMusicList();
        IDataResult<List<MusicList>> ListMusicListPaging(int page, int pageSize);
        IDataResult<List<MusicList>> ListMusicListWithTopMusicListPaging(int page, int pageSize);

        //Arama
        IDataResult<List<MusicList>> ListMusicListWithTopMusicListAndAramaPaging(string aramametin, int page, int pageSize);

        IDataResult<List<MusicList>> ListMusicListWithTopMusicListPagingByTopmusicListId(int TopmusicListId, int page, int pageSize);

        //Arama
        IDataResult<List<MusicList>> ListMusicListWithTopMusicListPagingByTopmusicListIdAndArama(string aramametin, int TopmusicListId, int page, int pageSize);

        IDataResult<List<MusicList>> ListMusicListWithTopMusicListPagingByTopMusicListTitle(string TopmusicListId, int page, int pageSize);

        IDataResult<MusicList> GetMusicListWithTopMusicListByMusicListId(int MusicListId);
        IDataResult<List<MusicList>> ListMusicListWithTopMusicListByTopmusicListId(int TopmusicListId);
        IDataResult<int> CountMusicListByTopmusicListId(int TopmusicListId);
    }
}
