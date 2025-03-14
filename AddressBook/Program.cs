using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using ModelLayer.Model;
using RepositoryLayer.Context;
using RepositoryLayer.Interface;
using RepositoryLayer.Service;
using BusinessLayer.Interface;
using BusinessLayer.Service;
using Microsoft.OpenApi.Models;
using AutoMapper;
using BusinessLayer.FluentValidator; 

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DbContextBook>(options => options.UseSqlServer(connectionString));


// Register FluentValidation
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<AddressBookValidatorRequest>();

// Register AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

var mapperConfig = new MapperConfiguration(cfg =>
{
    cfg.CreateMap<AddressBookEntity, AddressBookEntry>().ReverseMap();
    cfg.CreateMap<AddressBookRequestDTO, AddressBookEntity>().ReverseMap();
});
var mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

// Register Services
builder.Services.AddScoped<IAddressBookBL, AddressBookBL>();
builder.Services.AddScoped<IAddressBookRL, AddressBookRL>();

// Add Controllers & Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Address Book API",
        Version = "v1",
        Description = "An API for managing address book contacts"
    });
});

var app = builder.Build();

app.UseRouting();
app.UseHttpsRedirection(); // Only once
app.UseAuthorization(); // Only once

// Enable Swagger in Development Mode
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();
