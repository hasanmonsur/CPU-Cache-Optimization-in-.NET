using BenchmarkDotNet.Attributes;
using CacheOptimizationBenchmarks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheOptimizationBenchmarks
{
    [MemoryDiagnoser]
    [RankColumn]
    public class HotColdBenchmark
    {
        private Order[] orders;
        private HotOrderData[] hotOrders;

        [Params(1000, 10000)]
        public int OrderCount;

        [GlobalSetup]
        public void Setup()
        {
            orders = new Order[OrderCount];
            hotOrders = new HotOrderData[OrderCount];

            var rnd = new Random(42); // Fixed seed for reproducible results

            for (int i = 0; i < OrderCount; i++)
            {
                // Create cold data with large fields
                orders[i] = new Order
                {
                    Id = i,
                    Total = (decimal)rnd.NextDouble() * 1000,
                    Status = (OrderStatus)rnd.Next(3),
                    CustomerNotes = new string('x', 1000),
                    History = new OrderHistory[rnd.Next(5, 20)]
                };

                // Initialize history entries
                for (int j = 0; j < orders[i].History.Length; j++)
                {
                    orders[i].History[j] = new OrderHistory
                    {
                        Timestamp = DateTime.Now.AddDays(-rnd.Next(365)),
                        Action = $"Action_{j}",
                        PerformedBy = $"User_{rnd.Next(1000)}"
                    };
                }

                // Create hot data (only frequently accessed fields)
                hotOrders[i] = new HotOrderData
                {
                    Id = orders[i].Id,
                    Total = orders[i].Total,
                    Status = orders[i].Status
                };
            }

            // Warm up the memory/cache
            ProcessOrders();
            ProcessHotOrders();
        }

        [Benchmark(Baseline = true)]
        public decimal ProcessOrders()
        {
            decimal total = 0;
            for (int i = 0; i < orders.Length; i++)
            {
                if (orders[i].Status == OrderStatus.Completed)
                    total += orders[i].Total;
            }
            return total;
        }

        [Benchmark]
        public decimal ProcessHotOrders()
        {
            decimal total = 0;
            for (int i = 0; i < hotOrders.Length; i++)
            {
                if (hotOrders[i].Status == OrderStatus.Completed)
                    total += hotOrders[i].Total;
            }
            return total;
        }

        [Benchmark]
        public decimal ProcessHotOrders_Span()
        {
            decimal total = 0;
            var span = new Span<HotOrderData>(hotOrders);
            for (int i = 0; i < span.Length; i++)
            {
                if (span[i].Status == OrderStatus.Completed)
                    total += span[i].Total;
            }
            return total;
        }
    }
}
