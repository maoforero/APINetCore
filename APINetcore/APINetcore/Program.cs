using APINetcore.DBManagement;
using APINetcore.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var SQLConnectionString = new DataAccess(builder.Configuration.GetConnectionString("SQL"));
builder.Services.AddSingleton<IProductsInMemory, ProductsInMemory>();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

