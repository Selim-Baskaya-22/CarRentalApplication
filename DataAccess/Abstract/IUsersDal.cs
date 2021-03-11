using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess;
using Core.Entites.Concrete;
using Entities.Concrete;
namespace DataAccess.Abstract
{
    public interface IUsersDal : IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
    }
}
