using MediatR;
using Merchant.Application.Products;
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
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProductAsync(CreateProductCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpPut("UpdateCategory")]
        public async Task<IActionResult> UpdateProductAsync(UpdateProductCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpDelete("DeleteProduct")]
        public async Task<IActionResult> DeleteProductAsync(DeleteProductCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpGet("Products")]
        public async Task<IActionResult> GetProductsAsync()
        {
            return Ok(await _mediator.Send(new GetProductsQuery()));
        }
    }
}
