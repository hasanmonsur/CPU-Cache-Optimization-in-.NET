// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Running;
using CacheOptimizationBenchmarks;
using CacheOptimizationBenchmarks.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;



var builder = WebApplication.CreateBuilder(args);


Console.WriteLine("Hello, World!");

//var summary = BenchmarkRunner.Run<MemoryLayoutBenchmark>();
//var summary = BenchmarkRunner.Run<FalseSharingBenchmark>();

var summary = BenchmarkRunner.Run<HotColdBenchmark>();


builder.Services.AddControllers();
builder.Services.AddSingleton<ProductRepository>();
// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

builder.WebHost.UseUrls("http://localhost:9001", "https://localhost:9002");





var app = builder.Build();


// Middleware Pipeline - ORDER MATTERS!
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll"); // Apply CORS policy

app.UseHttpsRedirection();

app.MapControllers();

app.Run();