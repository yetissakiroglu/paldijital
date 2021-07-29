using Eticaret.Business.Abstract.Admin;
using Eticaret.Business.Constants;
using Eticaret.Core.Utilities.Business;
using Eticaret.Core.Utilities.Results;
using Eticaret.DataAccess.Abstract;
using Eticaret.Entities.ComplexTypes;
using Eticaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eticaret.Business.Concrete.Managers.Admin
{
    class RadioCategoryManager : IRadioCategoryService
    {
        private IRadioCategoryDal _radioCategoryDal;

        public RadioCategoryManager(IRadioCategoryDal radioCategoryDal)
        {
            _radioCategoryDal = radioCategoryDal;
        }

        public IDataResult<int> CountRadioCategories()
        {
            return new SuccessDataResult<int>(_radioCategoryDal.GetAll().Count);
        }

        public IResult Create(RadioCategory radioCategory)
        {
            IResult result = BusinessRules.Run(CheckIfCreateDataNameExists(radioCategory.title));
            if (result != null)
            {
                return result;
            }
            _radioCategoryDal.Create(radioCategory);
            return new SuccessResult(Messages.Creared);
        }

        public IResult Delete(RadioCategory radioCategory)
        {
            _radioCategoryDal.Delete(radioCategory);
            return new SuccessResult(Messages.Deleted);
        }

        public IResult DeleteFromRadioCategoryandRadios(RadioCategory radioCategory)
        {
            _radioCategoryDal.DeleteFromRadioCategoryandRadios(radioCategory);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<RadioCategory> GetRadioCategoryBycategoryId(int categoryId)
        {
            return new SuccessDataResult<RadioCategory>(_radioCategoryDal.Get(p => p.categoryId == categoryId));
        }

        public IDataResult<RadioCategory> GetRadioCategoryWithRadiosBycategoryId(int categoryId)
        {
            return new SuccessDataResult<RadioCategory>(_radioCategoryDal.GetRadioCategoryWithRadiosBycategoryId(categoryId));
        }

        public IDataResult<List<RadioCategory>> ListRadioCategory()
        {
            return new SuccessDataResult<List<RadioCategory>>(_radioCategoryDal.GetAll().ToList());
        }

        public IDataResult<List<RadioCategory>> ListRadioCategoryWithRadios()
        {
            return new SuccessDataResult<List<RadioCategory>>(_radioCategoryDal.ListRadioCategoryWithRadios());
        }

        public IDataResult<List<RadioCategory>> ListRadioCategoryWithRadiosPaging(int page, int pageSize)
        {
            return new SuccessDataResult<List<RadioCategory>>(_radioCategoryDal.ListRadioCategoryWithRadiosPaging(page,pageSize));
        }

        public IResult Update(RadioCategory radioCategory)
        {
            IResult result = BusinessRules.Run(CheckIfUpdateDataNameExists(radioCategory.title, radioCategory.categoryId));
            if (result != null)
            {
                return result;
            }
            _radioCategoryDal.Update(radioCategory);
            return new SuccessResult(Messages.Updated);
        }


        private IResult CheckIfCreateDataNameExists(string radioName)
        {

            var result = _radioCategoryDal.GetAll(p => p.title == radioName).Any();
            if (result)
            {
                return new ErrorResult(Messages.NameAlreadyExists);
            }

            return new SuccessResult();
        }

        private IResult CheckIfUpdateDataNameExists(string radioName, int id)
        {

            var result = _radioCategoryDal.GetAll(p => p.title == radioName && p.categoryId != id).Any();
            if (result)
            {
                return new ErrorResult(Messages.NameAlreadyExists);

            }

            return new SuccessResult();


        }

    }
}
