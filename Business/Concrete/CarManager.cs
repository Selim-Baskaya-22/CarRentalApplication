using Business.Abstract;
using Business.Constants;
using Core.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
      
        public IResult Add(Cars cars)
        {

            if (cars.Description.Length > 2 && cars.DailyPrice > 0)
                _carDal.Add(cars);
            else if (cars.Description.Length < 2)
                Console.WriteLine("Açıklama en az 2 karakter olmalıdır!!!");
            else if (cars.DailyPrice < 0)
                Console.WriteLine("Arabanın günlük fiyatı 0'dan büyük olmalıdır!!!");
            else if (cars.Description.Length < 2 && cars.DailyPrice < 0)
                Console.WriteLine("Açıklama en az 2 karakter olmalıdır ve arabanın günlük fiyatı 0'dan büyük olmalıdır!!!");
      
                return new SuccessResult(SuccessMessages.CarDeleted);
        }

        public IResult Delete(Cars cars)
        {
            if (cars.CarId<0)
            {
                return new ErrorResult(ErrorMessages.CouldntCarDeleted);
            }
            _carDal.Delete(cars);
            return new SuccessResult(SuccessMessages.CarDeleted);          
        }

        public IDataResult<List<Cars>> GetAll()
        {
            if (DateTime.Now.Hour==12)
            {
                return new ErrorDataResult<List<Cars>>(ErrorMessages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Cars>>(_carDal.GetAll(),SuccessMessages.CarListed);
        }

        public IDataResult<Cars> GetById(int id)
        {
            return new SuccessDataResult<Cars>(_carDal.GetById(c=>c.CarId==id),SuccessMessages.CarListed);
        }

        public IDataResult<List<CarDetailsDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailsDto>>( _carDal.GetCarDetails(),SuccessMessages.CarListed);
        }

        public IDataResult<List<ModelYearBrandNameDto>> GetModelYearBrandNameDtos()
        {
            return new SuccessDataResult<List<ModelYearBrandNameDto>>(_carDal.GetModelYearBrandNameDtos(),SuccessMessages.CarListed+"(Model ve Yıla Göre)");
        }

        public IResult Update(Cars cars)
        {
            if (cars.CarId < 0)
            {
                return new ErrorResult(ErrorMessages.CouldntCarUpdated);
            }
            _carDal.Update(cars);
            return new SuccessResult(SuccessMessages.CarUpdated);

        }

   
    }
}
