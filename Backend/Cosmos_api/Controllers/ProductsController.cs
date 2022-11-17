using Cosmos_api.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            _context.Add(product);
            await _context.SaveChangesAsync();
            return new OkResult();
        }
    }
}
