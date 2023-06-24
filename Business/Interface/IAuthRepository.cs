using Business.Security.JWT;
using Entity.Entities;
using Entity.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface IAuthRepository
    {
        User Register(UserForRegisterDto userForRegister, string password);
        User Login(UserForLoginDto userForLogin);
        bool UserExists(string email);
        AccessToken CreateAccessToken(User user);
    }
}
