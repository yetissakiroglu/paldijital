using Eticaret.Business.Abstract.UI;
using Eticaret.Core.Utilities.Results;
using Eticaret.DataAccess.Abstract;
using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eticaret.Business.Concrete.Managers.UI
{
    public class TopMusicListWebManager : ITopMusicListWebService
    {
        private ITopMusicListDal _TopMusicListDal;

        public TopMusicListWebManager(ITopMusicListDal TopMusicListDal)
        {
            _TopMusicListDal = TopMusicListDal;
        }
        public IDataResult<List<TopMusicList>> ListTopMusicListWithMusicListWithRadioApi()
        {
            return new SuccessDataResult<List<TopMusicList>>(_TopMusicListDal.ListTopMusicListWithMusicListWithRadioApi());
        }
    }
}
