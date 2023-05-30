using TestTask.Persistance;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add services to the container.

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
