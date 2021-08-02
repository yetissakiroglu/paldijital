using Eticaret.Core.Utilities.Results;
using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eticaret.Business.Abstract.UI
{
    public interface IPodcastWebService
    {
        IDataResult<PodcastMusicList> GetPodcastbyId(int programId);
        IDataResult<List<PodcastMusicList>> ListPodcastbyId(int programId);
        IDataResult<List<PodcastMusicList>> ListPodcast();
        IDataResult<List<PodcastMusicList>> ListPodcastWithProgrambyProgramId(int programId);

    }
}
