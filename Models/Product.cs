using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheOptimizationBenchmarks.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }

        // Conversion method to DTO
        public ProductDto ToDto() => new ProductDto
        {
            Id = this.Id,
            Name = this.Name,
            Price = this.Price
        };
    }
}
