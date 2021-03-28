using MediatR;
using Merchant.Application.Categories;
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
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("CreateCategory")]
        [ProducesDefaultResponseType(typeof(Unit))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateCategoryAsync(CreateCategoryCommand command)
        {
           return Ok(await _mediator.Send(command));
        } 
        [HttpPut("UpdateCategory")]
        [ProducesDefaultResponseType(typeof(Unit))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateCategoryAsync(UpdateCategoryCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpDelete("DeleteCategory")]
        [ProducesDefaultResponseType(typeof(Unit))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteCategoryAsync(DeleteCategoryCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        
    }
}
