```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.3915)
Intel Core i7-8750H CPU 2.20GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET SDK 10.0.100-preview.3.25201.16
  [Host]     : .NET 9.0.1 (9.0.124.61010), X64 RyuJIT AVX2
  DefaultJob : .NET 9.0.1 (9.0.124.61010), X64 RyuJIT AVX2


```
| Method                | OrderCount | Mean       | Error     | StdDev    | Ratio | RatioSD | Rank | Allocated | Alloc Ratio |
|---------------------- |----------- |-----------:|----------:|----------:|------:|--------:|-----:|----------:|------------:|
| **ProcessOrders**         | **1000**       |   **4.874 μs** | **0.0926 μs** | **0.0909 μs** |  **1.00** |    **0.03** |    **2** |         **-** |          **NA** |
| ProcessHotOrders      | 1000       |   4.613 μs | 0.1097 μs | 0.3217 μs |  0.95 |    0.07 |    2 |         - |          NA |
| ProcessHotOrders_Span | 1000       |   4.049 μs | 0.0810 μs | 0.1025 μs |  0.83 |    0.03 |    1 |         - |          NA |
|                       |            |            |           |           |       |         |      |           |             |
| **ProcessOrders**         | **10000**      | **146.733 μs** | **2.8419 μs** | **2.6583 μs** |  **1.00** |    **0.03** |    **2** |         **-** |          **NA** |
| ProcessHotOrders      | 10000      | 140.182 μs | 2.7100 μs | 3.0121 μs |  0.96 |    0.03 |    2 |         - |          NA |
| ProcessHotOrders_Span | 10000      | 123.996 μs | 2.4487 μs | 2.2905 μs |  0.85 |    0.02 |    1 |         - |          NA |
