using BLL;
using DAL;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using ViewModel.Insert;
using ViewModel.Update;
using WebAPI.Filters;
using WebAPI.Resources;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDALServices(builder.Configuration);
builder.Services.AddBLLServices();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
builder.Services.AddScoped<IUrlHelper>(x => {
    var actionContext = x.GetRequiredService<IActionContextAccessor>().ActionContext;
    var factory = x.GetRequiredService<IUrlHelperFactory>();
    return factory.GetUrlHelper(actionContext);
});
builder.Services.AddScoped<ItemResourceFactory>();

builder.Services.AddControllers(options =>
    options.Filters.Add(new ApiExceptionFilterAttribute()))
    .AddFluentValidation(options => {
        options.RegisterValidatorsFromAssemblyContaining<CategoryInsertModelValidator>();
        options.RegisterValidatorsFromAssemblyContaining<CategoryUpdateModelValidator>();
        options.RegisterValidatorsFromAssemblyContaining<ItemInsertModelValidator>();
        options.RegisterValidatorsFromAssemblyContaining<ItemUpdateModelValidator>();
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
