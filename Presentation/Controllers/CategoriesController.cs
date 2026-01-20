using Domain.DataTransferObjects.Categories;
using Domain.Entities;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController(IServiceManager serviceManager) : ControllerBase
    {
        private readonly IServiceManager _serviceManager = serviceManager;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Categories> categories = await _serviceManager.CategoriesService.GetAllAsync();

            return Ok(categories);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            Categories category = await _serviceManager.CategoriesService.GetByIdAsync(id);

            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryForCreationDTO body)
        {
            Categories category = await _serviceManager.CategoriesService.CreateAsync(body.Description, body.ExpenseType);

            return Ok(category);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            await _serviceManager.CategoriesService.DeleteAsync(id);

            return Ok();
        }

        [HttpPatch("id")]
        public async Task<IActionResult> Update([FromQuery] int id, string description)
        {
            await _serviceManager.CategoriesService.UpdateAsync(id, description);

            return Ok();
        }
    }
}
