using TostiElotes.Domain.Entities;
using TostiElotes.Services.Features;
using TostiElotes.Infrastructure.Repositories;
using TostiElotes.Services.Mappings;
using TostiElotes.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.
builder.Services.AddScoped<OrdenServices>();
builder.Services.AddTransient<OrdenRepository>();

builder.Services.AddScoped<ProductoServices>();
builder.Services.AddTransient<ProductoRepository>();

builder.Services.AddScoped<ClienteServices>();
builder.Services.AddTransient<ClienteRepository>();

builder.Services.AddScoped<DetalleOrdenServices>();
builder.Services.AddTransient<DetalleOrdenRepository>();

builder.Services.AddScoped<VendedorServices>();
builder.Services.AddTransient<VendedorRepository>();

builder.Services.AddControllers();
builder.Services.AddDbContext<SnackappDbContext>(
    options => {
        options.UseSqlServer(configuration.GetConnectionString("gemDevelopment"));
    }
);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(ResponseMappingProfile).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
    app.UseSwagger();
    app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
