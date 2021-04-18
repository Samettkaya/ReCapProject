using Core.Utilities.Results.Abstract;
using core.Entities.Concrete;
using Entities.DTOs;
using Core.Utilities.Security.JWT;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
        IResult ChangePassword(ChangePasswordDto changePasswordDto);
        IResult UserDetailUpdate(UserDetailForUpdate userDetailForUpdate);
    }
}
