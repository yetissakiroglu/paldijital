﻿using Eticaret.Core.DataAccess;
using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eticaret.DataAccess.Abstract.UI
{
    public interface IPodcastWebDal : IEntityRepository<PodcastMusicList>
    {
        List<PodcastMusicList> ListPodcastWithProgrambyProgramId(int programId);
        PodcastMusicList GetPodcastWithProgrambypodcastId(int podcastId);

    }
}
