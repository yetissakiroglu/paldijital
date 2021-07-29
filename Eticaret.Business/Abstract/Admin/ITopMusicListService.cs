using Eticaret.Core.Utilities.Results;
using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eticaret.Business.Abstract.Admin
{
    public interface ITopMusicListService
    {
        IDataResult<TopMusicList> GetTopMusicListByTopMusicListId(int TopMusicListId);
        IDataResult<List<TopMusicList>> ListTopMusicListByradioApiId(int radioApiId);
        IDataResult<List<TopMusicList>> ListTopMusicList();
        IResult Create(TopMusicList TopMusicList);
        IResult Update(TopMusicList TopMusicList);
        IResult Delete(TopMusicList TopMusicList);
        IDataResult<int> CountTopMusicList();

        IDataResult<List<TopMusicList>> ListTopMusicListWithRadioApi();
        IDataResult<List<TopMusicList>> ListTopMusicListPaging(int page, int pageSize);
        IDataResult<List<TopMusicList>> ListTopMusicListWithRadioApiPaging(int page, int pageSize);
        //Arama
        IDataResult<List<TopMusicList>> ListTopMusicListWithRadioApiAndAramaPaging(string aramametin, int page, int pageSize);
        IDataResult<List<TopMusicList>> ListTopMusicListWithRadioApiPagingByradioApiId(int radioApiId, int page, int pageSize);
        //Arama
        IDataResult<List<TopMusicList>> ListTopMusicListWithRadioApiPagingByradioApiIdAndDataArama(DateTime sData, DateTime fData, string aramametin, int radioApiId, int page, int pageSize);

        IDataResult<List<TopMusicList>> ListTopMusicListWithRadioApiPagingByradioApiIdAndArama(string aramametin, int radioApiId, int page, int pageSize);
        IDataResult<List<TopMusicList>> ListTopMusicListWithRadioApiPagingByradioApiTitle(string radioApi, int page, int pageSize);
        IDataResult<TopMusicList> GetTopMusicListWithRadioApiByTopMusicListId(int TopMusicListId);
        IDataResult<List<TopMusicList>> ListTopMusicListWithRadioApiByradioApiId(int radioApiId);
        IDataResult<int> CountTopMusicListByradioApiId(int radioApiId);

    }
}
