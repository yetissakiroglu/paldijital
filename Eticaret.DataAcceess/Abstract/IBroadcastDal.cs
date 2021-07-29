using Eticaret.Core.DataAccess;
using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eticaret.DataAccess.Abstract
{
    public interface IBroadcastDal : IEntityRepository<Broadcast>
    {
        List<Broadcast> ListBroadcastWithRadioApi();
        List<Broadcast> ListBroadcastPaging(int page, int pageSize);
        List<Broadcast> ListBroadcastWithRadioApiPaging(int page, int pageSize);

        //Arama
        List<Broadcast> ListBroadcastWithRadioApiAndAramaPaging(string aramametin, int page, int pageSize);

        List<Broadcast> ListBroadcastWithRadioApiPagingByradioApiId(int radioApiId, int page, int pageSize);

        //Arama
        List<Broadcast> ListBroadcastWithRadioApiPagingByradioApiIdAndArama(string aramametin, int radioApiId, int page, int pageSize);

        List<Broadcast> ListBroadcastWithRadioApiPagingByradioApiTitle(string radioApi, int page, int pageSize);

        Broadcast GetBroadcastWithRadioApiByBroadcastId(int BroadcastId);
        List<Broadcast> ListBroadcastWithRadioApiByradioApiId(int radioApiId);
        int CountBroadcastByradioApiId(int radioApiId);
    }
}
