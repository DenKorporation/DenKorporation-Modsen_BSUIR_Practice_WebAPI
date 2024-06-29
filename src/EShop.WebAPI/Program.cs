using EShop.BLL.Extensions;
using EShop.DAL.Extensions;
using EShop.WebAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

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