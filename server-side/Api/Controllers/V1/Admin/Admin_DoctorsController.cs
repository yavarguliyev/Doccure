using Core.DTOs.Admin.Admin_Doctor;
using Core.DTOs.Auth;
using Core.Enum;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Controllers.v1.Admin
{
  public class Admin_DoctorsController : BaseApiController
  {
    #region admin_doctors crud
    [HttpGet]
    public async Task<IActionResult> Get()
    {
      if (Auth.Admin == null) return Unauthorized();
      return Ok(await UserService.GetAsync(UserRole.Doctor, Auth.Admin.Id));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
      if (Auth.Admin == null) return Unauthorized();
      return Ok(Mapper.Map<UserDTO>(await UserService.GetAsync(id)));
    }

    [HttpPost]
    public async Task<IActionResult> Create(AdminCreateDoctorDTO model)
    {
      if (Auth.Admin == null) return Unauthorized();
      await UserService.CreateAsync(Mapper.Map<User>(model), UserRole.Doctor);
      return Ok(new { message = "New doctor created!" });
    }

    [HttpPut("status")]
    public async Task<IActionResult> Status(int id)
    {
      if (Auth.Admin == null) return Unauthorized();
      await UserService.StatusAsync(id);
      return Ok(new { message = "Status modified" });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      if (Auth.Admin == null) return Unauthorized();
      await UserService.DeleteAsync(await UserService.GetAsync(id));
      return Ok(new { message = "Selected doctor removed from database" });
    }
    #endregion
  }
}