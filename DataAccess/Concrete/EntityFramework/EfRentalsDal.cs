using Core.EntityFramework;
using Core.Utilities.Results.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalsDal : EfEntityRepositoryBase<CarRentalContext, Rentals>, IRentalsDal
    {//rental - car - customer - user
        public List<RentalDetailsDto> GetRentalDetails()
        {
            using (CarRentalContext context=new CarRentalContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars
                             on r.CarId equals c.CarId

                             join cu in context.Customer
                             on r.CustomerId equals cu.CustomerId

                             join b in context.Brands
                             on c.BrandId equals b.BrandId

                             join u in context.Users
                             on cu.UserId equals u.UserId

                             select new RentalDetailsDto
                             {
                                 RentalId = r.Id,
                                 BrandName = b.BrandName,        
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate,
                                 CarId = c.CarId,
                                 CustomerName = $"{ u.FirstName} {u.LastName }"
                             };

                return result.ToList();
            }

        }
    }
}
