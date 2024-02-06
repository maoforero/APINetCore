using APINetcore.DBManagement;
using APINetcore.Repository;
using Microsoft.Extensions.Options;
using NLog.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var SQLConnectionString = new DataAccess(builder.Configuration.GetConnectionString("SQL"));
builder.Services.AddSingleton(SQLConnectionString);
builder.Services.AddSingleton<IProductsInMemory, ProductsSQLServer>();
builder.Services.AddControllers(Options =>
{
    Options.SuppressAsyncSuffixInActionNames = false;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// NLog: Configura el proveedor de registro de NLog para ASP.NET Core
builder.Logging.ClearProviders();
builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
builder.Host.UseNLog();


var app = builder.Build();

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

