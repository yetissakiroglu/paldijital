using Eticaret.Business.Abstract.UI;
using Eticaret.Core.Utilities.Results;
using Eticaret.DataAccess.Abstract.UI;
using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eticaret.Business.Concrete.Managers.UI
{
    public class PodcastWebManager:IPodcastWebService
    {

        private IPodcastWebDal _podcastWebDal;

        public PodcastWebManager(IPodcastWebDal podcastWebDal)
        {
            _podcastWebDal = podcastWebDal;
        }

        public IDataResult<PodcastMusicList> GetPodcastbyId(int programId)
        {
            return new SuccessDataResult<PodcastMusicList>(_podcastWebDal.Get(p => p.programId == programId));
        }

        public IDataResult<PodcastMusicList> GetPodcastWithProgrambypodcastId(int podcastId)
        {
            return new SuccessDataResult<PodcastMusicList>(_podcastWebDal.GetPodcastWithProgrambypodcastId(podcastId));
        }

        public IDataResult<List<PodcastMusicList>> ListPodcast()
        {
            return new SuccessDataResult<List<PodcastMusicList>>(_podcastWebDal.GetAll().ToList());
        }

        public IDataResult<List<PodcastMusicList>> ListPodcastbyId(int programId)
        {
            return new SuccessDataResult<List<PodcastMusicList>>(_podcastWebDal.GetAll(p => p.programId == programId).ToList());
        }

        public IDataResult<List<PodcastMusicList>> ListPodcastWithProgrambyProgramId(int programId)
        {
            return new SuccessDataResult<List<PodcastMusicList>>(_podcastWebDal.ListPodcastWithProgrambyProgramId(programId));
        }
    }
}
