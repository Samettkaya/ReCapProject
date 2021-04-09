using core.Entities.Concrete;
using Core.DataAccess;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IUserDal: IEntityRepository<User>
    {

        List<OperationClaim> GetClaims(User user);
        UserDetailDto GetUserDetails(Expression<Func<UserDetailDto, bool>> filter = null);
    }
}
