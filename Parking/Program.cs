using Microsoft.EntityFrameworkCore;
using Parking.Data;
using Parking.Data.Repositories;
using Parking.Data.Repositories.ClientRepository;
using Parking.Data.Repositories.SpaceRepository;
using Parking.Models;
using Parking.Servicess.AuthService;
using Parking.Servicess.ClienteService;
using Parking.Servicess.Space;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

//repositories
builder.Services.AddScoped<IRepository<Cliente>, RepositoryImpl<Cliente>>();
builder.Services.AddScoped<ClienteRepository>();
builder.Services.AddScoped<SpaceRepository>();

//services
builder.Services.AddScoped<ISpaceService, SpaceService>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IAuthService, AuthService>();


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost") 
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
