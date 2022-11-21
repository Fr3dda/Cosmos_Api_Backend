using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Cosmos_api.Models
{
    public class Product
    {
 
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public string Description { get; set; } = null!;
    }
}
