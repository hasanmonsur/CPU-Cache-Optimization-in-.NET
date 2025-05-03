using BenchmarkDotNet.Attributes;
using CacheOptimizationBenchmarks.Models;
using CacheOptimizationBenchmarks.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheOptimizationBenchmarks.Controllers
{
    // Example API Controller
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductRepository _repository;

        public ProductsController(ProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("standard")]
        public IActionResult GetProductsStandard()
        {
            var products = _repository.GetAllProductDtos();
            return Ok(products);
        }

        [HttpGet("optimized")]
        public IActionResult GetProductsOptimized()
        {
            var products = _repository.GetAllProductDtosOptimized();
            return Ok(products);
        }
    }

    // Benchmark class comparing the two approaches
    [MemoryDiagnoser]
    public class ProductDtoBenchmark
    {
        private ProductRepository _repository;

        [GlobalSetup]
        public void Setup()
        {
            _repository = new ProductRepository();
        }

        [Benchmark]
        public List<ProductDto> StandardMapping()
        {
            return _repository.GetAllProductDtos().ToList();
        }

        [Benchmark]
        public ProductDto[] OptimizedMapping()
        {
            return _repository.GetAllProductDtosOptimized().ToArray();
        }
    }
}
