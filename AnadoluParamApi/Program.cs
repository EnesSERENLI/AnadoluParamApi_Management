using AnadoluParamApi.Base.Jwt;
using AnadoluParamApi.Data.Context;
using AnadoluParamApi.Data.Model;
using AnadoluParamApi.Extension;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

//public static JwtConfig JwtConfig { get; private set; }
var builder = WebApplication.CreateBuilder(args);

JwtConfig jwtConfig = builder.Configuration.GetSection("JwtConfig").Get<JwtConfig>();
builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection("JwtConfig"));
// Add services to the container.


builder.Services.AddDbContextDI(builder.Configuration);
builder.Services.AddServiceDI();
builder.Services.AddJwtBearerAuthentication(jwtConfig);

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddControllers();
builder.Services.AddCustomizeSwagger();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/AnadoluParamApi/swagger.json", "AnadoluParamApi");
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
