using MediatR;
using Merchant.Application.Carts;
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
    public class CartController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CartController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("AddItem")]
        public async Task<IActionResult> AddItemToCartAsync(AddItemCartCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpPost("CreateCart")]
        public async Task<IActionResult> CreateCartAsync(CreateCartCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpPut("UpdateItemQuantity")]
        public async Task<IActionResult> UpdateItemQuantityAsync(UpdateCartItemQuantityCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpDelete("DeleteItem")]
        public async Task<IActionResult> DeleteCartItemAsync(DeleteCartItemCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

    }
}
