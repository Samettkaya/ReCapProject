using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using core.Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetById(int userId);
        List<OperationClaim> GetClaims(User user);
        User GetByMail(string email);
        IDataResult<UserDetailDto> GetUserDetailByEmail(string email);
    }
}
