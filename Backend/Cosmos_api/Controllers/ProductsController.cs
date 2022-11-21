using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cosmos_api.Contexts;
using Cosmos_api.Models;

namespace Cosmos_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly DataContext _context;

        public ProductsController(DataContext context)
        {
            _context = context;
        }


        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {

            var productModel = new ProductModel
            {
                Id = Guid.NewGuid(),
                PartitionKey = "Products",
                Name = product.Name,
                Price = product.Price,
                Description = product.Description
            };

            _context.Add(productModel);
            await _context.SaveChangesAsync();

            return new OkObjectResult(productModel);
        }
        // GET //

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return new OkObjectResult(await _context.Products.ToListAsync());
        }

        // GET: api/ProductModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductModel>> GetProductModel(Guid id)
        {
            if (_context.Products == null)
            {
                return NotFound();
            }
            var productModel = await _context.Products.FindAsync(id);

            if (productModel == null)
            {
                return NotFound();
            }

            return productModel;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductModel(Guid id, ProductModel productModel)
        {
            if (id != productModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(productModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/ProductModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductModel(Guid id)
        {
            if (_context.Products == null)
            {
                return NotFound();
            }
            var productModel = await _context.Products.FindAsync(id);
            if (productModel == null)
            {
                return NotFound();
            }

            _context.Products.Remove(productModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        private bool ProductModelExists(Guid id)
        {
            return (_context.Products?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}


