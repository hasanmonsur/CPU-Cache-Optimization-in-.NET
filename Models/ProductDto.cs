using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheOptimizationBenchmarks.Models
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        // Optional: Override ToString for better debugging
        public override string ToString() =>
            $"ProductDto: Id={Id}, Name={Name}, Price={Price:C}";
    }
}
