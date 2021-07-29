using Eticaret.Business.Abstract.UI;
using Eticaret.Business.Constants;
using Eticaret.Core.Utilities.Results;
using Eticaret.DataAccess.Abstract.UI;
using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eticaret.Business.Concrete.Managers.UI
{
    public class BildirWebManager : IBildirWebService
    {
        private IBildirWebDal _bildirWebDal;

        public BildirWebManager(IBildirWebDal bildirWebDal)
        {
            _bildirWebDal = bildirWebDal;
        }



        public IResult Create(Bildir bildir)
        {
            _bildirWebDal.Create(bildir);
            return new SuccessResult(Messages.Creared);
        }

     

        public IDataResult<Bildir> GetBildirById(int Id)
        {
            return new SuccessDataResult<Bildir>(_bildirWebDal.Get(p => p.Id == Id));
        }

        public IDataResult<List<Bildir>> ListBildir()
        {
            return new SuccessDataResult<List<Bildir>>(_bildirWebDal.GetAll().ToList());
        }

        public IDataResult<List<Bildir>> ListBildirById(int Id)
        {
            return new SuccessDataResult<List<Bildir>>(_bildirWebDal.GetAll(p => p.Id == Id).ToList());
        }


    }
}
