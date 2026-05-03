using SecureRagAgent.Application.DependencyInjection;
using SecureRagAgent.Infrastructure.DependencyInjection;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplication(builder.Configuration);
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//try
//{
//    app.MapControllers();
//}
//catch (ReflectionTypeLoadException ex)
//{
//    Console.WriteLine("=== ReflectionTypeLoadException ===");

//    foreach (var loaderException in ex.LoaderExceptions)
//    {
//        Console.WriteLine(loaderException?.GetType().FullName);
//        Console.WriteLine(loaderException?.Message);
//        Console.WriteLine(loaderException?.StackTrace);
//        Console.WriteLine("----------------------------------");
//    }

//    throw;
//}
app.MapControllers();

app.Run();

public partial class Program;