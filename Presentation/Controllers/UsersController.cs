using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace Presentation.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController(IServiceManager serviceManager) : ControllerBase
    {
        private readonly IServiceManager _serviceManager = serviceManager;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Users> users = await _serviceManager.UsersService.GetAllAsync();

            return Ok(users);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            Users user = await _serviceManager.UsersService.GetByIdAsync(id);

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Create(string Name, uint Age)
        {
            Users user = await _serviceManager.UsersService.CreateAsync(Name, Age);

            return Ok(user);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            await _serviceManager.UsersService.DeleteAsync(id);

            return Ok();
        }

        [HttpPatch("id")]
        public async Task<IActionResult> Update([FromQuery] int id, string? name, uint? age)
        {
            await _serviceManager.UsersService.UpdateAsync(id, name, age);

            return Ok();
        }
    }
}
