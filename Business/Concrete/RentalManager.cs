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
    public class RentalManager:IRentalsService
    {
        IRentalsDal _rentalsDal;
        Rentals _rental;

        public RentalManager(Rentals rental)
        {
            _rental = rental;
        }

        public RentalManager(IRentalsDal rentalsDal)
        {
            _rentalsDal = rentalsDal;
        }

        public IResult Add(Rentals rentals)
        {
            if (_rental.ReturnDate == null)
            {
                _rentalsDal.Add(rentals);
                return new SuccessResult(SuccessMessages.RentalAdded);
            }
            return new ErrorResult(ErrorMessages.CouldntRentalAdded);
        }

        public IResult Delete(Rentals rentals)
        {
            _rentalsDal.Delete(rentals);
            return new SuccessResult(SuccessMessages.RentalDeleted);
        }

        public IDataResult<List<Rentals>> GetAll()
        {
            return new SuccessDataResult<List<Rentals>>(_rentalsDal.GetAll(),SuccessMessages.RentalListed);
        }

        public IDataResult<Rentals> GetById(int id)
        {
            return new SuccessDataResult<Rentals>(_rentalsDal.GetById(r=>r.Id==id),SuccessMessages.RentalListed);
        }

        public IResult Update(Rentals rentals)
        {
            _rentalsDal.Update(rentals);
            return new SuccessResult(SuccessMessages.RentalUpdated);
        }
    }
}
