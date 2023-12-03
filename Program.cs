using TostiElotes.Domain.Entities;
using TostiElotes.Services.Features;
using TostiElotes.Infrastructure.Repositories;
using TostiElotes.Services.Mappings;
using TostiElotes.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.
builder.Services.AddScoped<OrdenService>();
builder.Services.AddTransient<OrdenRepository>();

builder.Services.AddScoped<ProductoService>();
builder.Services.AddTransient<ProductoRepository>();

builder.Services.AddScoped<ClienteService>();
builder.Services.AddTransient<ClienteRepository>();

builder.Services.AddScoped<CarritoService>();
builder.Services.AddTransient<CarritoComprasRepository>();

builder.Services.AddScoped<VendedorService>();
builder.Services.AddTransient<VendedorRepository>();

builder.Services.AddScoped<ClienteService>();
builder.Services.AddTransient<ClienteRepository>();

builder.Services.AddScoped<CredencialesClienteService>();
builder.Services.AddTransient<CredencialesClienteRepository>();

builder.Services.AddScoped<CredencialesVendedorService>();
builder.Services.AddTransient<CredencialesVendedorRepository>();

builder.Services.AddScoped<DetalleCarritoService>();
builder.Services.AddTransient<DetalleCarritoRepository>();

builder.Services.AddScoped<NotificacionService>();
builder.Services.AddTransient<NotificacionesRepository>();

builder.Services.AddScoped<PuestoNegocioService>();
builder.Services.AddTransient<PuestonegocioRepository>();

builder.Services.AddScoped<RepartidorService>();
builder.Services.AddTransient<RepartidorRepository>();

builder.Services.AddScoped<SeguimientoEstadoService>();
builder.Services.AddTransient<SeguimientoEstadoRepository>();

builder.Services.AddScoped<VendedoProductoService>();
builder.Services.AddTransient<VendedorProductoRepository>();

builder.Services.AddScoped<VendedorPuestoService>();
builder.Services.AddTransient<VendedorPuestoRepository>();




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
