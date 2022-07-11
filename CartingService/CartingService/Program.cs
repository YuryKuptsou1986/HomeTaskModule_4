using CartingService.DAL.Interfaces;
using CartingService.DAL.LiteDb.Repositories;
using CartingService.Filters;
using CartService.BLL.Entities.Insert;
using CartService.BLL.Mappings;
using CartService.BLL.Services;
using CartService.DAL.Interfaces;
using CartService.DAL.LiteDb.DbContext;
using CartService.DAL.LiteDb.Providers;
using CartService.DAL.LiteDb.Repositories;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ILiteDbSettingsProvider, LiteDbSettingsProvider>();
builder.Services.AddScoped<ILiteDBContext, LiteDBContext>();
builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped<ICartService, CartService.BLL.Services.CartService>();

builder.Services.AddAutoMapper(typeof(AppMappingProfile));

// Add services to the container.
builder.Services.AddControllers(options => options.Filters.Add(new ApiExceptionFilterAttribute()))
    .AddFluentValidation(options => {
        options.RegisterValidatorsFromAssemblyContaining<CartInsertViewModelValidator>(includeInternalTypes: true);
        options.RegisterValidatorsFromAssemblyContaining<ImageInfoInsertViewModelValidator>(includeInternalTypes: true);
        options.RegisterValidatorsFromAssemblyContaining<ItemInsertViewModelValidator>(includeInternalTypes: true);
    });
builder.Services.AddApiVersioning(config => {
    config.DefaultApiVersion = new ApiVersion(1, 0);
    config.AssumeDefaultVersionWhenUnspecified = true;
    config.ReportApiVersions = true;
    //config.ApiVersionReader = new HeaderApiVersionReader("api-version");
});

builder.Services.AddVersionedApiExplorer(options => { 
    options.GroupNameFormat = "'v'VVV";  
    options.SubstituteApiVersionInUrl = true;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
c => {
    c.SwaggerDoc("v1", new OpenApiInfo { Version = "v1", Title = "Cart Service" });
    c.SwaggerDoc("v2", new OpenApiInfo { Version = "v2", Title = "Cart Service" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "version v1");
        c.SwaggerEndpoint("/swagger/v2/swagger.json", "version v2");
    });
}

app.UseAuthorization();

app.MapControllers();

app.Run();
