using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using Personregister.Infrastructure.Persistence.Context;
using Personregister.Infrastructure.Persistence.Repository;
using Personregister.Application.Contracts.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IFødselRepository, FødselRepository>();
builder.Services.AddScoped<IDødsfallRepository, DødsfallRepository>();


//builder.Services.AddDbContext<Personregistercontext>(options=>options.UseInMemoryDatabase("Test"));

builder.Services.AddDbContext<Personregistercontext>(options => options.UseSqlServer("Data Source = 127.0.0.1, 1401; Initial Catalog = Personregister; User ID = SA; Password = Password9!"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// oppdatere database når programmet starter (istedet for å bruke
// "Update-Database  -project Personregister.WebAPI -startupproject Personregister.WebAPI  -Context Personregistercontext"
// i Package Manager Console)
using (var serviceScope = app.Services.CreateScope())
{
    var uttrekkDbContext = serviceScope.ServiceProvider.GetRequiredService<Personregistercontext>();
    uttrekkDbContext?.Database.Migrate();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
