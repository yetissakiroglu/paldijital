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
    public class RadioManager : IRadioService
    {
        private IRadioDal _radioDal;
        private IRadioCategoryService _radioCategoryService;

        public RadioManager(IRadioDal radioDal, IRadioCategoryService radioCategoryService)
        {
            _radioDal = radioDal;
            _radioCategoryService = radioCategoryService;
        }

        public IDataResult<int> CountRadios()
        {
            return new SuccessDataResult<int>(_radioDal.GetAll().Count());
        }

        public IDataResult<int> CountRadiosBycategoryId(int categoryId)
        {
            return new SuccessDataResult<int>(_radioDal.CountRadiosBycategoryId(categoryId));
        }

        public IResult Create(Radio radio)
        {
            IResult result = BusinessRules.Run(CheckIfCreateDataNameExists(radio.title));
            if (result != null)
            {
                return result;
            }

        

            _radioDal.Create(radio);
            return new SuccessResult(Messages.Creared);
        }

        public IResult Delete(Radio radio)
        {
            _radioDal.Delete(radio);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<Radio> GetRadioByradioId(int radioId)
        {
            return new SuccessDataResult<Radio>(_radioDal.Get(p => p.radioId == radioId));
        }

        public IDataResult<Radio> GetRadioWithRadioCategoryByradioId(int radioId)
        {
            return new SuccessDataResult<Radio>(_radioDal.GetRadioWithRadioCategoryByradioId(radioId));
        }

        public IDataResult<List<RadioDetail>> ListRadioDetailWithRadioCategory()
        {
            return new SuccessDataResult<List<RadioDetail>>(_radioDal.ListRadioDetailWithRadioCategory());
        }

        public IDataResult<List<RadioDetail>> ListRadioDetailWithRadioCategoryPaging(int page, int pageSize)
        {
            return new SuccessDataResult<List<RadioDetail>>(_radioDal.ListRadioDetailWithRadioCategoryPaging(page,pageSize));
        }

        public IDataResult<List<RadioDetail>> ListRadioDetailWithRadioCategoryPagingBycategoryId(int categoryId, int page, int pageSize)
        {
            return new SuccessDataResult<List<RadioDetail>>(_radioDal.ListRadioDetailWithRadioCategoryPagingBycategoryId(categoryId,page, pageSize));
        }

        public IDataResult<List<RadioDetail>> ListRadioDetailWithRadioCategoryPagingByCategoryTitle(string category, int page, int pageSize)
        {
            return new SuccessDataResult<List<RadioDetail>>(_radioDal.ListRadioDetailWithRadioCategoryPagingByCategoryTitle(category, page, pageSize));
        }

        public IDataResult<List<Radio>> ListRadioWithRadioCategory()
        {
            return new SuccessDataResult<List<Radio>>(_radioDal.ListRadioWithRadioCategory());
        }

        public IDataResult<List<Radio>> ListRadioWithRadioCategoryBycategoryId(int categoryId)
        {
            return new SuccessDataResult<List<Radio>>(_radioDal.ListRadioWithRadioCategoryBycategoryId(categoryId));
        }

        public IDataResult<List<Radio>> ListRadioWithRadioCategoryPaging(int page, int pageSize)
        {
            return new SuccessDataResult<List<Radio>>(_radioDal.ListRadioWithRadioCategoryPaging(page, pageSize));
        }

        public IDataResult<List<Radio>> ListRadioWithRadioCategoryPagingBycategoryId(int categoryId, int page, int pageSize)
        {
            return new SuccessDataResult<List<Radio>>(_radioDal.ListRadioWithRadioCategoryPagingBycategoryId(categoryId,page, pageSize));
        }

        public IDataResult<List<Radio>> ListRadioWithRadioCategoryPagingByCategoryTitle(string category, int page, int pageSize)
        {
            return new SuccessDataResult<List<Radio>>(_radioDal.ListRadioWithRadioCategoryPagingByCategoryTitle(category, page, pageSize));
        }

        public IDataResult<List<Radio>> ListRadio()
        {
            return new SuccessDataResult<List<Radio>>(_radioDal.GetAll().ToList());
        }

        public IResult Update(Radio radio)
        {
            IResult result = BusinessRules.Run(CheckIfUpdateDataNameExists(radio.title, radio.radioId));
            if (result != null)
            {
                return result;
            }
            _radioDal.Update(radio);
            return new SuccessResult(Messages.Updated);
        }

        private IResult CheckIfCreateDataNameExists(string name)
        {

            var result = _radioDal.GetAll(p => p.title == name).Any();
            if (result)
            {
                return new ErrorResult(Messages.NameAlreadyExists);
            }

            return new SuccessResult();
        }

        private IResult CheckIfUpdateDataNameExists(string name, int id)
        {

            var result = _radioDal.GetAll(p => p.title == name && p.radioId != id).Any();
            if (result)
            {
                return new ErrorResult(Messages.NameAlreadyExists);

            }

            return new SuccessResult();


        }

        public IDataResult<List<Radio>> ListRadioWithRadioCategoryAndAramaPaging(string aramametin, int page, int pageSize)
        {
            return new SuccessDataResult<List<Radio>>(_radioDal.ListRadioWithRadioCategoryAndAramaPaging(aramametin,page, pageSize));
        }

        public IDataResult<List<RadioDetail>> ListRadioWithRadioCategoryPagingByradioCategoryIdAndArama(string aramametin, int radiocategoryId, int page, int pageSize)
        {
            return new SuccessDataResult<List<RadioDetail>>(_radioDal.ListRadioWithRadioCategoryPagingByradioCategoryIdAndArama(aramametin, radiocategoryId, page, pageSize));
        }
    }
}
