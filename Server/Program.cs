using DBVServer.Services;
using MySqlConnector;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IDBAccessProvider, DBAccessProvider>();

const bool UseEntiryFramework = false;
if (UseEntiryFramework)
{
    // custom IDbContext class for EntityFramework ORM
    builder.Services.AddScoped<>();
}
else
{
    // No ORM
    builder.Services.AddScoped<IDbConnection>(serviceProvider =>
        new MySqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));
}

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//app.Run();
app.Run("http://0.0.0.0:5000");

// 192.168.1.169