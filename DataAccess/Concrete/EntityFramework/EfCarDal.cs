using Core.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;
namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<CarRentalContext, Cars>, ICarDal
    {
        public List<CarDetailsDto> GetCarDetails()
        {
            using (CarRentalContext context=new CarRentalContext())
            {

                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join cl in context.Colors
                             on c.ColorId equals cl.ColorId
                             select new CarDetailsDto
                             {
                                 BrandName = b.BrandName,
                                 DailyPrice = c.DailyPrice,
                                 //cl.ColorName=ColorName,
                                 ColorName = cl.ColorName,
                                 CarName = c.Description
                             };
                return result.ToList();
            }
        }

        public List<ModelYearBrandNameDto> GetModelYearBrandNameDtos()
        {
            using (CarRentalContext context=new CarRentalContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             select new ModelYearBrandNameDto
                             {
                                 BrandName = b.BrandName,
                                 ModelYear = c.ModelYear
                             };
                return result.ToList();
            }
           
        }
    }
}
