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
    public class PageManager : IPageService
    {
        private IPageDal _pageDal;

        public PageManager(IPageDal pageDal)
        {
            _pageDal = pageDal;
        }

        public IDataResult<int> CountPage()
        {
            return new SuccessDataResult<int>(_pageDal.GetAll().Count());
        }

        public IResult Create(Page Page)
        {
            _pageDal.Create(Page);
            return new SuccessResult(Messages.Creared);
        }

        public IResult Delete(Page Page)
        {
            _pageDal.Delete(Page);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<Page> GetPageByPageId(int PageId)
        {
            return new SuccessDataResult<Page>(_pageDal.Get(p => p.PageId == PageId));
        }

        public IDataResult<List<Page>> ListPage()
        {
            return new SuccessDataResult<List<Page>>(_pageDal.GetAll().ToList());
        }

        public IDataResult<List<Page>> ListPageByModulId(int ModulId)
        {
            return new SuccessDataResult<List<Page>>(_pageDal.GetAll(p => p.ModulId == ModulId).ToList());
        }

        public IResult Update(Page Page)
        {
            _pageDal.Update(Page);
            return new SuccessResult(Messages.Updated);
        }
    }
}
