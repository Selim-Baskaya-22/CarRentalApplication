using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class CarImagesManager : ICarImagesService
    {
        ICarImagesDal _carImagesDal;
        public CarImagesManager(ICarImagesDal carImagesDal)
        {
            _carImagesDal = carImagesDal;
        }
        //[ValidationAspect(typeof(CarImagesValidator))]
        public IResult Add(IFormFile formFile, CarImages entity)
        {

           var result= BusinessRules.Run(CheckImagesLimited(entity.CarId));
            
            if (result != null)
            {
                return result;
            }
            entity.ImagePath = FileHelper.Add(formFile);
            entity.Date = DateTime.Now;
            _carImagesDal.Add(entity);

            return new SuccessResult(SuccessMessages.CarAdded);
        }

        public IResult Delete(CarImages entity)
        {
            FileHelper.Delete(entity.ImagePath);
            _carImagesDal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<List<CarImages>> GetAll(Expression<Func<CarImages, bool>> filter = null)
        {
            return new SuccessDataResult<List<CarImages>>(_carImagesDal.GetAll());
        }

        public IDataResult<CarImages> GetById(int id)
        {
            return new SuccessDataResult<CarImages>(CheckIfCarImageNull(id));
        }
       
        public IResult Update(IFormFile formFile, CarImages entity)
        {

            var result = BusinessRules.Run(CheckImagesLimited(entity.CarId));
            if (result != null)
            {
                return result;
            }
            entity.ImagePath = FileHelper.Update(_carImagesDal.GetById(p => p.Id == entity.Id).ImagePath, formFile);
            entity.Date = DateTime.Now;
            _carImagesDal.Update(entity);
            return new SuccessResult();
        }
        private IResult CheckImagesLimited(int id)
        {
            var result = _carImagesDal.GetAll(ci => ci.CarId == id).Count;
            if (result >= 5)
            {
                return new ErrorResult(ErrorMessages.CouldntCarAdded);
            }
            return new SuccessResult();
        }
        private CarImages CheckIfCarImageNull(int id)
        {
            string path = Environment.CurrentDirectory + @"\\CompanyLogo";
            var result = _carImagesDal.GetAll(c => c.CarId == id).Count();
            if (result==0)
            {
                return new CarImages{ CarId = id, ImagePath = path, Date = DateTime.Now  };
            }
            return _carImagesDal.GetById(p => p.CarId == id);
        }
    }
}
