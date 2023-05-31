using System.Reflection;
using TestTask.Aplication;
using TestTask.Aplication.Common.Mappings;
using TestTask.Aplication.Interfaces;
using TestTask.Persistance;
using TestTask.WebApp.Middleware;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add services to the container.

services.AddAutoMapper(config =>
{
    config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
    config.AddProfile(new AssemblyMappingProfile(typeof(ITestTaskDbContext).Assembly));
});

services.AddAplication();
services.AddPersistance(builder.Configuration);

builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = services.BuildServiceProvider().CreateScope()) // invoke method of Db initialization
{
    var serviceProvider = scope.ServiceProvider;
    try
    {
        var context = serviceProvider.GetRequiredService<TestTaskDbContext>(); // for accessing dependencies
        DbInitializer.Initialize(context); // initialize database
    }
    catch (Exception e) { }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCustomExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
