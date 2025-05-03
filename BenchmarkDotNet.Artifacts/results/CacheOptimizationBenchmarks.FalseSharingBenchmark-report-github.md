```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.3915)
Intel Core i7-8750H CPU 2.20GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET SDK 10.0.100-preview.3.25201.16
  [Host]     : .NET 9.0.1 (9.0.124.61010), X64 RyuJIT AVX2
  DefaultJob : .NET 9.0.1 (9.0.124.61010), X64 RyuJIT AVX2


```
| Method        | Mean     | Error   | StdDev  | Allocated |
|-------------- |---------:|--------:|--------:|----------:|
| SharedCounter | 213.4 ms | 4.09 ms | 5.17 ms |   2.18 KB |
| PaddedCounter | 212.4 ms | 4.15 ms | 5.25 ms |   2.12 KB |
