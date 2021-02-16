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
    public class UserManager : IUsersService
    {
        IUsersDal _usersDal;

        public UserManager(IUsersDal usersDal)
        {
            _usersDal = usersDal;
        }

        public IResult Add(Users users)
        {
            _usersDal.Add(users);
            return new SuccessResult(SuccessMessages.UserAdded);
        }

        public IResult Delete(Users users)
        {
            _usersDal.Delete(users);
            return new SuccessResult(SuccessMessages.UserDeleted);
        }

        public IDataResult<List<Users>> GetAll()
        {
            return new SuccessDataResult<List<Users>>(_usersDal.GetAll(),SuccessMessages.UserListed);
        }

        public IDataResult<Users> GetById(int id)
        {
            return new SuccessDataResult<Users>(_usersDal.GetById(u=>u.UserId==id), SuccessMessages.UserListed);
        }

        public IResult Update(Users users)
        {
            _usersDal.Update(users);
            return new SuccessResult(SuccessMessages.UserUpdated);
        }
    }
}
