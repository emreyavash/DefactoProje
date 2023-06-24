using Business.Interface;
using Entity.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DefactoProje.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleRepository _roleRepository;

        public RolesController(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        [HttpGet("Roles")]
        public IActionResult GetCategoriesAll()
        {
            var result = _roleRepository.GetRolesAll();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("Role")]
        public IActionResult GetCategoryById(int id)
        {
            var result = _roleRepository.GetRoleById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost("AddRole")]
        public IActionResult AddCategory(Role role)
        {
            _roleRepository.AddRole(role);
            return Ok("Başarılı şekilde eklendi.");
        }
        [HttpPut("UpdateRole")]
        public IActionResult UpdateRole(Role role)
        {
            _roleRepository.UpdateRole(role);
            return Ok("Başarılı şekilde güncellendi");
        }
        [HttpDelete("DeleteRole")]
        public IActionResult DeleteRole(Role role)
        {
            _roleRepository.DeleteRole(role);
            return Ok("Başarılı bir şekilde silindi");
        }
    }
}
