using dal;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string connectionString = Environment.GetEnvironmentVariable("DBCONNECTION") ?? string.Empty;

if (string.IsNullOrEmpty(connectionString))
{
    Console.WriteLine("DBCONNECTION missing in environment variable, trying to retrieve from appsettings.json");
    connectionString = builder.Configuration.GetConnectionString("MyAppDb");
}

Console.WriteLine(connectionString);

builder.Services.AddDbContext<MyAppDbContext>(options => options.UseSqlServer(connectionString));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.Map("/", () => "OK");

app.MapControllers();

app.Run();
