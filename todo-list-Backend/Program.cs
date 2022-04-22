using To_Do_List_Backend.Repositories;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using todo_list_Backend;
using todo_list_Backend.Infrastructure;
using todo_list_Backend.Repositories;
using todo_list_Backend.UnitOfWorks;
/*
namespace todo_list_Backend
{
public class Program
{
public static void Main(string[] args)
{
CreateHostBuilder(args).Build().Run();
}

public static IHostBuilder CreateHostBuilder(string[] args) =>
Host.CreateDefaultBuilder(args)
.ConfigureWebHostDefaults(webBuilder =>
{
webBuilder.UseStartup<Startup>();
});
}
}*/
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.WithOrigins("http://localhost:4200")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
        });
});

builder.Services.AddDbContext<TodoDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("Todo"));
});
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Todo", Version = "v1" });
});

builder.Services.AddScoped<ITodoRepository, TodoRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


var app = builder.Build();
app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});
app.UseCors(builder =>
{
    builder
    .WithOrigins("localhost:4200")
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});
app.Run();