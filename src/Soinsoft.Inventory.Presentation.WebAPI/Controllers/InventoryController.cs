using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Soinsoft.Inventory.Application.Commands.FProduct.Commands;
using Soinsoft.Inventory.Application.Commands.FProduct.Queries;
using Soinsoft.Inventory.Application.Contracts.DTOs;
using MediatR;

namespace Soinsoft.Inventory.Presentation.WebAPI.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class InventoryController : ControllerBase
    {
        private readonly ILogger<InventoryController> _logger;
        private readonly IMediator _mediator;

        public InventoryController(ILogger<InventoryController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }


        [HttpGet(Name ="Products")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProducts()
        {
            try
            {
                var result= await _mediator.Send(new GetProductsQry());
                return Ok(result);
            }
            catch (System.Exception err)
            {
                return StatusCode(401,err.Message);                
            }

        }

        [HttpPost(Name ="NewProduct")]
        public async Task<ActionResult> AddProduct([FromBody] AddProductCmd product)
        {
            try
           {
                var result= await _mediator.Send(product);
                return Ok(result); 
            }
            catch (System.Exception error)
            {
                return StatusCode(401,error.Message);                
            }
          
        }


    }
}