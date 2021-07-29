using Eticaret.Core.Utilities.Results;
using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eticaret.Business.Abstract.Admin
{
    public interface IBroadcastService
    {
        IDataResult<Broadcast> GetBroadcastByBroadcastId(int BroadcastId);
        IDataResult<List<Broadcast>> ListBroadcastByradioApiId(int radioApiId);
        IDataResult<List<Broadcast>> ListBroadcast();
        IResult Create(Broadcast Broadcast);
        IResult Update(Broadcast Broadcast);
        IResult Delete(Broadcast Broadcast);
        IDataResult<int> CountBroadcast();

        IDataResult<List<Broadcast>> ListBroadcastWithRadioApi();
        IDataResult<List<Broadcast>> ListBroadcastPaging(int page, int pageSize);
        IDataResult<List<Broadcast>> ListBroadcastWithRadioApiPaging(int page, int pageSize);
        //Arama
        IDataResult<List<Broadcast>> ListBroadcastWithRadioApiAndAramaPaging(string aramametin, int page, int pageSize);
        IDataResult<List<Broadcast>> ListBroadcastWithRadioApiPagingByradioApiId(int radioApiId, int page, int pageSize);
        //Arama
        IDataResult<List<Broadcast>> ListBroadcastWithRadioApiPagingByradioApiIdAndArama(string aramametin, int radioApiId, int page, int pageSize);
        IDataResult<List<Broadcast>> ListBroadcastWithRadioApiPagingByradioApiTitle(string radioApi, int page, int pageSize);
        IDataResult<Broadcast> GetBroadcastWithRadioApiByBroadcastId(int BroadcastId);
        IDataResult<List<Broadcast>> ListBroadcastWithRadioApiByradioApiId(int radioApiId);
        IDataResult<int> CountBroadcastByradioApiId(int radioApiId);
    }
}
