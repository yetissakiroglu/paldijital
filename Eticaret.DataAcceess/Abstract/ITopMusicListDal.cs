using Eticaret.Core.DataAccess;
using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Eticaret.DataAccess.Abstract
{
   public interface ITopMusicListDal:IEntityRepository<TopMusicList>
    {
        List<TopMusicList> ListTopMusicListWithRadioApi();
        List<TopMusicList> ListTopMusicListPaging(int page, int pageSize);
        List<TopMusicList> ListTopMusicListWithRadioApiPaging(int page, int pageSize);

        //Arama
        List<TopMusicList> ListTopMusicListWithRadioApiAndAramaPaging(string aramametin, int page, int pageSize);

        List<TopMusicList> ListTopMusicListWithRadioApiPagingByradioApiId(int radioApiId, int page, int pageSize);

        //Arama
        List<TopMusicList> ListTopMusicListWithRadioApiPagingByradioApiIdAndArama(string aramametin, int radioApiId, int page, int pageSize);
      
        //Arama
        List<TopMusicList> ListTopMusicListWithRadioApiPagingByradioApiIdAndDataArama(DateTime sData, DateTime fData, string aramametin, int radioApiId, int page, int pageSize);

        List<TopMusicList> ListTopMusicListWithRadioApiPagingByradioApiTitle(string radioApi, int page, int pageSize);

        TopMusicList GetTopMusicListWithRadioApiByTopMusicListId(int TopMusicListId);
        List<TopMusicList> ListTopMusicListWithRadioApiByradioApiId(int radioApiId);
        int CountTopMusicListByradioApiId(int radioApiId);

        //Web
        List<TopMusicList> ListTopMusicListWithMusicListWithRadioApi();




    }
}
