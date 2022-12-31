using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.BusinessObjects;
using ProductCatalog.Domain;
using ProductCatalog.EFRepositories;
using ProductCatalog.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ICatalogTypeBO, CatalogTypeBO>();
builder.Services.AddTransient<ICatalogItemBO, CatalogItemBO>();
builder.Services.AddTransient<ICatalogItemRepository, CatalogItemRepository>();
builder.Services.AddTransient<ICatalogTypeRepository, CatalogTypeRepository>();
builder.Services.AddDbContext<ProductCatalogContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection")));

var app = builder.Build();

using(var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<ProductCatalogContext>();
        context.Database.Migrate();
        ProductCatalogSeed.SeedAsync(context).Wait();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occured creating the DB.");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

