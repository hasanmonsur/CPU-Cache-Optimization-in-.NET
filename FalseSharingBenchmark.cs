using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheOptimizationBenchmarks
{
    [MemoryDiagnoser]
    public class FalseSharingBenchmark
    {
        private const int Iterations = 100000000;
        private readonly SharedData sharedData = new();
        private readonly PaddedData paddedData = new();

        [Benchmark]
        public void SharedCounter()
        {
            Parallel.For(0, 2, i =>
            {
                for (int j = 0; j < Iterations; j++)
                {
                    if (i == 0) sharedData.Counter1++;
                    else sharedData.Counter2++;
                }
            });
        }

        [Benchmark]
        public void PaddedCounter()
        {
            Parallel.For(0, 2, i =>
            {
                for (int j = 0; j < Iterations; j++)
                {
                    if (i == 0) paddedData.Counter1++;
                    else paddedData.Counter2++;
                }
            });
        }
    }

    // Bad: Counters share cache line (typically 64 bytes)
    public class SharedData
    {
        public int Counter1;
        public int Counter2;
    }

    // Good: Counters on separate cache lines
    public class PaddedData
    {
        public int Counter1;
        private readonly long p1, p2, p3, p4, p5, p6, p7; // Padding
        public int Counter2;
        private readonly long p8, p9, p10, p11, p12, p13, p14; // Padding
    }
}
