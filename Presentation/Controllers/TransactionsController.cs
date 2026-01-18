using Domain.DataTransferObjects.Transactions;
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
    [Route("api/transactions")]
    [ApiController]
    public class TransactionsController(IServiceManager serviceManager) : ControllerBase
    {
        private readonly IServiceManager _serviceManager = serviceManager;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<TransactionDTO> transactions = await _serviceManager.TransactionsService.GetAllAsync();

            return Ok(transactions);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            TransactionDTO transaction = await _serviceManager.TransactionsService.GetByIdAsync(id);

            return Ok(transaction);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TransactionForCreationDTO body)
        {
            Transactions transaction = await _serviceManager.TransactionsService.CreateAsync(body);

            return Ok(transaction);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            await _serviceManager.TransactionsService.DeleteAsync(id);

            return Ok();
        }

        [HttpPatch("id")]
        public async Task<IActionResult> Update([FromQuery] int id, [FromBody] TransactionForUpdateDTO body)
        {
            await _serviceManager.TransactionsService.UpdateAsync(id, body);

            return Ok();
        }
    }
}
