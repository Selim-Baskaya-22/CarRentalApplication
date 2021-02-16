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
    public class CustomerManager:ICustomersService
    {
        ICustomersDal _customersDal;

        public CustomerManager(ICustomersDal customersDal)
        {
            _customersDal = customersDal;
        }

        public IResult Add(Customers customers)
        {
            _customersDal.Add(customers);
            return new SuccessResult(SuccessMessages.CustomerAdded);
        }

        public IResult Delete(Customers customers)
        {
            _customersDal.Delete(customers);
            return new SuccessResult(SuccessMessages.CustomerDeleted);
        }

        public IDataResult<List<Customers>> GetAll()
        {
             
            return new SuccessDataResult<List<Customers>>(_customersDal.GetAll(),SuccessMessages.CustomerListed);
        }

        public IDataResult<Customers> GetById(int id)
        {
            return new SuccessDataResult<Customers>(_customersDal.GetById(c=>c.CustomerId==id), SuccessMessages.CustomerListed);
        }

        public IResult Update(Customers customers)
        {
            _customersDal.Update(customers);
            return new SuccessResult(SuccessMessages.CustomerUpdated);
        }
    }
}
