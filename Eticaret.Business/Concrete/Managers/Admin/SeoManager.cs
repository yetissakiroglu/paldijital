using Eticaret.Business.Abstract.Admin;
using Eticaret.Business.Constants;
using Eticaret.Core.Utilities.Results;
using Eticaret.DataAccess.Abstract.Admin;
using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eticaret.Business.Concrete.Managers.Admin
{
    public class SeoManager : ISeoService
    {
        private ISeoDal _seoDal;

        public SeoManager(ISeoDal seoDal)
        {
            _seoDal = seoDal;
        }
        public IDataResult<int> CountSeo()
        {
            return new SuccessDataResult<int>(_seoDal.GetAll().Count());
        }

        public IResult Create(Seo Seo)
        {
            _seoDal.Create(Seo);
            return new SuccessResult(Messages.Creared);
        }

        public IResult Delete(Seo Seo)
        {
            _seoDal.Delete(Seo);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<Seo> GetSeoBySeoId(int SeoId)
        {
            return new SuccessDataResult<Seo>(_seoDal.Get(p => p.seoId == SeoId));
        }

        public IDataResult<Seo> GetSeoBySeoIdandseoType(int SeoId, int seoType)
        {
            return new SuccessDataResult<Seo>(_seoDal.Get(p => p.seoId == SeoId && p.seoType == seoType));
        }

        public IDataResult<List<Seo>> ListSeo()
        {
            return new SuccessDataResult<List<Seo>>(_seoDal.GetAll().ToList());
        }

        public IDataResult<List<Seo>> ListSeoByPageId(int seoPageId)
        {
            return new SuccessDataResult<List<Seo>>(_seoDal.GetAll(p => p.seoPageId == seoPageId).ToList());
        }

        public IDataResult<List<Seo>> ListSeoByPageId(int seoPageId, int seoType)
        {
            return new SuccessDataResult<List<Seo>>(_seoDal.GetAll(p => p.seoPageId == seoPageId && p.seoType == seoType).ToList());
        }

        public IResult Update(Seo Seo)
        {
            _seoDal.Update(Seo);
            return new SuccessResult(Messages.Updated);
        }
    }
}
