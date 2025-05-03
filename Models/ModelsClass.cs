using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheOptimizationBenchmarks.Models
{
    public enum OrderStatus
    {
        Pending,
        Processing,
        Completed
    }

    public class OrderHistory
    {
        public DateTime Timestamp { get; set; }
        public string Action { get; set; }
        public string PerformedBy { get; set; }
    }

    public class Order
    {
        public int Id { get; set; }
        public decimal Total { get; set; }
        public OrderStatus Status { get; set; }
        public string CustomerNotes { get; set; }
        public OrderHistory[] History { get; set; }
    }

    public class HotOrderData
    {
        public int Id { get; set; }
        public decimal Total { get; set; }
        public OrderStatus Status { get; set; }
    }
}
