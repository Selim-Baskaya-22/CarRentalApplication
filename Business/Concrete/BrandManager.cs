using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager:IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brands brands)
        {
            if (brands.BrandId<0)
            {
                return new ErrorResult(ErrorMessages.CouldntBrandAdded);
            }
            _brandDal.Add(brands);
            return new SuccessResult(SuccessMessages.BrandAdded);
        }

        public IResult Delete(Brands brands)
        {
            if (brands.BrandId<0)
            {
                return new ErrorResult(ErrorMessages.CouldntBrandDeleted);            
            }
            _brandDal.Delete(brands);
            return new SuccessResult(SuccessMessages.BrandDeleted);
        }

        public IDataResult<List<Brands>> GetAll()
        {
            if (DateTime.Now.Hour==12)
            {
                return new ErrorDataResult<List<Brands>>(ErrorMessages.MaintenanceTime);
            }            
            return new SuccessDataResult<List<Brands>>(_brandDal.GetAll(),SuccessMessages.BrandListed);
        }

        public IDataResult<Brands> GetById(int id)
        {
            return new SuccessDataResult<Brands>(_brandDal.GetById(b => b.BrandId == id),SuccessMessages.BrandListed);
        }

        public IResult Update(Brands brands)
        {
            if (brands.BrandId<0)
            {
                return new ErrorResult(ErrorMessages.CouldntBrandUpdated);
            }
            _brandDal.Update(brands);
            return new SuccessResult(SuccessMessages.BrandUpdated);
        }
    }
}
