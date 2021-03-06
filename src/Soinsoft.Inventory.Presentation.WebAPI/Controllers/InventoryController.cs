using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Soinsoft.Inventory.Application.Commands.FProduct.Commands;
using Soinsoft.Inventory.Application.Commands.FProduct.Queries;
using Soinsoft.Inventory.Application.Contracts.DTOs;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Soinsoft.Inventory.Application.Commands.FTransacctions.Commands;

namespace Soinsoft.Inventory.Presentation.WebAPI.Controllers
{
    //Right now missing:
    //[httpGet("ForOrder") Ordering Report (at or bellow the minimun) 
    //[httpPost("PurchaseOrder")] Increase inventory (Purchases)
    //[httpPost("Sale")] Decrease inventory (Sales)
    //[httpGet("Existence")] Product existence (current existence)

    [EnableCors("MyPolicy")]
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
    
        [HttpGet("Products")]
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

        [HttpGet("Product/{id}")]
        public async Task<ActionResult<ProductDTO>> GetProduct(int id)
        {
            try
            {
                GetProductQry p = new GetProductQry();
                p.Id=id;
                var result= await _mediator.Send(p);
                return Ok(result);
            }
            catch (System.Exception err)
            {
                return StatusCode(401,err.Message);                
            }

        }

        [HttpPost("AddProduct")]
        public async Task<ActionResult> AddProduct([FromBody] AddProductCmd product)
        {
            try
           {
                var id= await _mediator.Send(product);
                string uri=$"https://localhost:5000/api/v1/Inventory/Product/{id}";
                return Created(uri, product); 
            }
            catch (System.Exception error)
            {
                return StatusCode(401,error.Message);                
            }
          
        }

        [HttpPut("EditProduct/{id}")]
        public async Task<ActionResult> EditProduct([FromBody] EditProductCmd product, int id)
        {
            try
           {
                product.Id=id;
                var result= await _mediator.Send(product);
                return Ok(result); 
            }
            catch (System.Exception error)
            {
                return StatusCode(401,error.Message);                
            }
          
        }

        [HttpDelete("DeleteProduct/{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            try
           {
               DeleteproductCmd prd =  new DeleteproductCmd();
               prd.ProductId=id;
               var result= await _mediator.Send(prd);
               return Ok(result); 
            }
            catch (System.Exception error)
            {
                return StatusCode(401,error.Message);                
            }
          
        }

        [HttpPost("Purchase")]
        public async Task<ActionResult> Purchase([FromBody] PurchaseOrderCmd purchase)
        {
            try
           {
                var id= await _mediator.Send(purchase);
                //string uri=$"https://localhost:5000/api/v1/Inventory/Purchase/{id}";
                return Ok(purchase); 
            }
            catch (System.Exception error)
            {
                return StatusCode(401,error.Message);                
            }
          
        }

        [HttpPost("Sale")]
        public async Task<ActionResult> Sale([FromBody] SaleCmd sale)
        {
            try
           {
                var id= await _mediator.Send(sale);
                //string uri=$"https://localhost:5000/api/v1/Inventory/Sale/{id}";
                return Ok(sale); 
            }
            catch (System.Exception error)
            {
                return StatusCode(401,error.Message);                
            }
          
        }

        [HttpGet("Stock")]
        public async Task<ActionResult<IEnumerable<StockDTO>>> Stock()
        {
            try
            {
                var result= await _mediator.Send(new GetCurrentStockQry());
                return Ok(result);
            }
            catch (System.Exception err)
            {
                return StatusCode(401,err.Message);                
            }

        }


    }
}