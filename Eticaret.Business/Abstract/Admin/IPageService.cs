using Eticaret.Core.Utilities.Results;
using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eticaret.Business.Abstract.Admin
{
    public interface IPageService
    {
        IDataResult<Page> GetPageByPageId(int PageId);
        IDataResult<List<Page>> ListPageByModulId(int ModulId);
        IDataResult<List<Page>> ListPage();
        IResult Create(Page Page);
        IResult Update(Page Page);
        IResult Delete(Page Page);
        IDataResult<int> CountPage();
    }
}
