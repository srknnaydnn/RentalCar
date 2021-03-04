using Business.Abstract;
using Business.Constans;
using Core.Entities;
using Core.Utilities;
using Core.Utilities.Jwt.Hashing;
using Core.Utilities.Jwt.Security;
using Core.Utilities.Result;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }
        public IDataResult<AccessToken> CreateAccessToken(User user)
        {

            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateAccessToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, Message.AccessTokenCreated);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Message.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordSalt, userToCheck.PasswordHash))
            {
                return new ErrorDataResult<User>(Message.ErrorPassword);
            }

            return new SuccessDataResult<User>(userToCheck, "giriş başarılı");

        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {

            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordSalt, out passwordHash);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordSalt = passwordSalt,
                PasswordHash = passwordHash,
                Status = true
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user, Message.UserRegistered);
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email) != null)
            {
                return new ErrorResult(Message.UserAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}
