using Business.Interface;
using Business.Security.Hashing;
using Business.Security.JWT;
using Entity.Entities;
using Entity.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenHelper _tokenHelper;

        public AuthRepository(IUserRepository userRepository, ITokenHelper tokenHelper)
        {
            _userRepository = userRepository;
            _tokenHelper = tokenHelper;
        }

        public AccessToken CreateAccessToken(User user)
        {
            var claims = _userRepository.GetRoles(user);
            var token = _tokenHelper.CreateToken(user, claims);
            return token;
        }

        public User Login(UserForLoginDto userForLogin)
        {
            var userCheck  = _userRepository.GetUserByMail(userForLogin.Email);
           if(!HashingHelper.VerifyPasswordHash(userForLogin.Password,userCheck.PasswordHash,userCheck.PasswordSalt))
            {
                return null;
            }
            return userCheck;
           
        }

        public User Register(UserForRegisterDto userForRegister, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password,out passwordHash, out passwordSalt);

            var user = new User
            {
                Email = userForRegister.Email,
                FirstName = userForRegister.FirstName,
                LastName = userForRegister.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };
            _userRepository.AddUser(user);
            return user;
        }
        public bool UserExists(string email)
        {
            var userMail=  _userRepository.GetUserByMail(email);
            if (userMail != null)
            {
                return false;
            }
            return true;
        }
    }
}
