using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheOptimizationBenchmarks
{
    [MemoryDiagnoser]
    [RankColumn]
    public class MemoryLayoutBenchmark
    {
        private const int Size = 100000;
        private PointClass[] classArray;
        private PointStruct[] structArray;

        [GlobalSetup]
        public void Setup()
        {
            classArray = new PointClass[Size];
            structArray = new PointStruct[Size];

            var rnd = new Random();
            for (int i = 0; i < Size; i++)
            {
                classArray[i] = new PointClass { X = rnd.NextDouble(), Y = rnd.NextDouble() };
                structArray[i] = new PointStruct { X = rnd.NextDouble(), Y = rnd.NextDouble() };
            }
        }

        [Benchmark]
        public double SumClassArray()
        {
            double sum = 0;
            for (int i = 0; i < classArray.Length; i++)
            {
                sum += classArray[i].X + classArray[i].Y;
            }
            return sum;
        }

        [Benchmark]
        public double SumStructArray()
        {
            double sum = 0;
            for (int i = 0; i < structArray.Length; i++)
            {
                sum += structArray[i].X + structArray[i].Y;
            }
            return sum;
        }
    }

    public class PointClass
    {
        public double X;
        public double Y;
    }

    public struct PointStruct
    {
        public double X;
        public double Y;
    }
}
