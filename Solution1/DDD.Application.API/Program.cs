using DDD.Application.API.Exceptions;
using DDD.Infra.Mysql;
using DDD.Infra.Mysql.Model;
using DDD.Infra.Mysql.Repositories;
using DDD.Infra.Mysql.Repositories.Product;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddControllers(options =>
{
    options.Filters.Add<EntityValidationExcptionDomain>();
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Services
builder.Services.AddScoped<MysqlServerContext, MysqlServerContext>();
builder.Services.AddScoped<IRepository<ProductModel>, ProductRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
