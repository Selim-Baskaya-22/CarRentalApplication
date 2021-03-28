using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Core.Entites.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
        //[SecuredOperation("")]
        public IResult Add(User users)
        {
            _usersDal.Add(users);
            return new SuccessResult(SuccessMessages.UserAdded);
        }

        public IResult Delete(User users)
        {
            _usersDal.Delete(users);
            return new SuccessResult(SuccessMessages.UserDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_usersDal.GetAll(),SuccessMessages.UserListed);
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_usersDal.GetById(u=>u.UserId ==id), SuccessMessages.UserListed);
        }

        public User GetByMail(string email)
        {
            return _usersDal.GetById(c=>c.Email==email);
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _usersDal.GetClaims(user);
        }

        public IResult Update(User users)
        {
            _usersDal.Update(users);
            return new SuccessResult(SuccessMessages.UserUpdated);
        }
    }
}
