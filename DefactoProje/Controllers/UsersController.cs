using Business.Interface;
using Entity.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DefactoProje.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("Users")]
        public IActionResult GetUsersAll() 
        {
            var result = _userRepository.GetUsersAll();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet("User")]
        public IActionResult GetUserById(int id)
        {
            var result = _userRepository.GetUserById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost("AddUser")]
        public IActionResult AddUser(User user)
        {
            _userRepository.AddUser(user);
            return Ok("Başarılı şekilde eklendi");
        }
        [HttpPut("UpdateUser")]
        public IActionResult UpdateUser(User user)
        {
            _userRepository.UpdateUser(user);
            return Ok("Başarılı şekilde güncellendi");
        }
        [HttpDelete("DeleteUser")]
        public IActionResult DeleteUser(User user)
        {
            _userRepository.DeleteUser(user);
            return Ok("Başarılı şekilde silindi");
        }

    }
}
