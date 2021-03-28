using MediatR;
using Merchant.Application.Customers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Merchant.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("CreateCustomer")]
        [ProducesDefaultResponseType(typeof(Unit))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateUserAsync(CreateCustomerCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpDelete("DeleteCustomer")]
        [ProducesDefaultResponseType(typeof(Unit))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteUserAsync(DeleteCustomerCommand command)
        {
            return Ok(await _mediator.Send(command);
        }
    }
}
