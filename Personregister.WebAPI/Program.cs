using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using Personregister.Infrastructure.Persistence.Context;
using Personregister.Infrastructure.Persistence.Repository;
using Personregister.Application.Contracts.Repository;
using Personregister.Application.Contracts;
using Personregister.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IF�dselRepository, F�dselRepository>();
builder.Services.AddScoped<ID�dsfallRepository, D�dsfallRepository>();
builder.Services.AddScoped<IKallenavnRepository, KallenavnRepository>();
builder.Services.AddScoped<IF�dselService, F�dselService>();
builder.Services.AddScoped<INavnService, NavnService>();
builder.Services.AddScoped<ID�dsfallService, D�dsfallService>();    
builder.Services.AddScoped<IInitDataService, InitDataService>();
builder.Services.AddScoped<IKallenavnService, KallenavnService>();
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IDtoPersonService, PersonService>();
builder.Services.AddScoped<IDtoGetPersonService, DtoGetPersonService>();



//builder.Services.AddDbContext<Personregistercontext>(options=>options.UseInMemoryDatabase("Test"));

builder.Services.AddDbContext<Personregistercontext>(options => options.UseSqlServer("Data Source = 127.0.0.1, 1401; Initial Catalog = Personregister; User ID = SA; Password = Password9!"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// oppdatere database n�r programmet starter (istedet for � bruke
// "Update-Database  -project Personregister.WebAPI -startupproject Personregister.WebAPI  -Context Personregistercontext"
// i Package Manager Console)
using (var serviceScope = app.Services.CreateScope())
{
    var uttrekkDbContext = serviceScope.ServiceProvider.GetRequiredService<Personregistercontext>();
    //uttrekkDbContext?.Database.Migrate();
    

    //T�mme database
    uttrekkDbContext?.Database.EnsureDeleted();

    //Oppretter database p� nytt
    uttrekkDbContext?.Database.EnsureCreated();

    var initDataService = serviceScope.ServiceProvider.GetRequiredService<IInitDataService>();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
