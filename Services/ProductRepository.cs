using CacheOptimizationBenchmarks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheOptimizationBenchmarks.Services
{
    // Example repository
    public class ProductRepository
    {
        private readonly List<Product> _products = new();

        public ProductRepository()
        {
            // Seed some sample data
            _products.AddRange(new[]
            {
            new Product { Id = 1, Name = "Laptop", Price = 999.99m, Description = "High performance laptop", Category = "Electronics" },
            new Product { Id = 2, Name = "Smartphone", Price = 699.99m, Description = "Latest model smartphone", Category = "Electronics" },
            new Product { Id = 3, Name = "Headphones", Price = 149.99m, Description = "Noise cancelling", Category = "Accessories" }
        });
        }

        public IEnumerable<ProductDto> GetAllProductDtos()
        {
            return _products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price
            });
        }

        public IEnumerable<ProductDto> GetAllProductDtosOptimized()
        {
            var dtos = new ProductDto[_products.Count];
            for (int i = 0; i < _products.Count; i++)
            {
                dtos[i] = new ProductDto
                {
                    Id = _products[i].Id,
                    Name = _products[i].Name,
                    Price = _products[i].Price
                };
            }
            return dtos;
        }
    }
}
