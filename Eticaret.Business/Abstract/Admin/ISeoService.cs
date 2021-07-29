using Eticaret.Core.Utilities.Results;
using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eticaret.Business.Abstract.Admin
{
    public interface ISeoService
    {
        IDataResult<Seo> GetSeoBySeoIdandseoType(int SeoId, int seoType);
        IDataResult<List<Seo>> ListSeoByPageId(int seoPageId, int seoType);
        IDataResult<List<Seo>> ListSeo();
        IResult Create(Seo Seo);
        IResult Update(Seo Seo);
        IResult Delete(Seo Seo);
        IDataResult<int> CountSeo();

    }
}
