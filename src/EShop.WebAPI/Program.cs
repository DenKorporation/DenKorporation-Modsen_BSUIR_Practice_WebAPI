using EShop.BLL.Validators;
using EShop.BLL.Extensions;
using EShop.DAL.Extensions;
using EShop.WebAPI.Extensions;
using FluentValidation;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidatorsFromAssembly(typeof(OrderDtoValidator).Assembly);
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDataAccessLayer(builder.Configuration);
builder.Services.AddBusinessLogicLayer(builder.Configuration);

var app = builder.Build();

app.UseErrorHandler();

if (app.Environment.IsDevelopment())
{
    await app.EnsureDeletedAsync();
    await app.ApplyMigrationAsync();
    await app.SeedAsync(app.Logger);
    
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();