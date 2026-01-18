using Domain;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost]
        public async Task<IActionResult> Create(string description, ExpenseType expenseType)
        {
            Categories category = await _serviceManager.CategoriesService.CreateAsync(description, expenseType);

            return Ok(category);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            await _serviceManager.CategoriesService.DeleteAsync(id);

            return Ok();
        }
    }
}
