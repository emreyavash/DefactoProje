using Business.Interface;
using Entity.Entities;
using Entity.Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DefactoProje.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;

        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }
        [HttpPost("Login")]
        public IActionResult Login(UserForLoginDto user)
        {
            var userExist = _authRepository.UserExists(user.Email);
            if (!userExist)
            {
                return BadRequest("Kullanıcı yok. Kayıt olmalısın.");
            }
            var loginUser = _authRepository.Login(user);
            var token = _authRepository.CreateAccessToken(loginUser);
            if (loginUser != null) 
            {
                return Ok(loginUser);
            }
            return BadRequest("Giriş Yapılamadı.");
        }
        [HttpPost("Register")]
        public IActionResult Register(UserForRegisterDto userForRegister) 
        {
            var userExist = _authRepository.UserExists(userForRegister.Email);
            if (userExist)
            {
                return BadRequest("Bu kullanıcı kayıtlı.");
            }
            var register = _authRepository.Register(userForRegister,userForRegister.Password);
            var token = _authRepository.CreateAccessToken(register);
            if (token != null)
            {
                return Ok(token);
            }
            return BadRequest("Kayıt oluşturulamadı.");
        }
    }
}
