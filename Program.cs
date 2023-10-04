using TostiElotes.Domain.Entities;
using TostiElotes.Services.Features;
using TostiElotes.Infrastructure.Repositories;
using TostiElotes.Services.Mappings;
using TostiElotes.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.
builder.Services.AddScoped<OrderServices>();
builder.Services.AddScoped<OrderRepository>();
builder.Services.AddScoped<ProductoServices>();
builder.Services.AddScoped<ProductoRepository>();
builder.Services.AddScoped<UsuarioServices>();
builder.Services.AddScoped<usuarioRepository>();

builder.Services.AddDbContext<ContexdataDB>(
    options => {
        options.UseSqlServer(configuration.GetConnectionString("gemDevelopment"));
    }, ServiceLifetime.Scoped
);

builder.Services.AddControllers();
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
