using Eticaret.Core.DataAccess;
using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eticaret.DataAccess.Abstract.UI
{
    public interface IProgramWebDal : IEntityRepository<ProgramList>
    {
        ProgramList GetProgramWithPodcastListByprogramUrl(string pageUrl);
    }
}
