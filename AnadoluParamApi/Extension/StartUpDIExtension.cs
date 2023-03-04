using AnadoluParamApi.Data.UnitOfWork.Abstract;
using AnadoluParamApi.Data.UnitOfWork.Concrete;
using AnadoluParamApi.Service.Abstract;
using AnadoluParamApi.Service.Concrete;
using AnadoluParamApi.Service.Mapper;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace AnadoluParamApi.Extension
{
    public static class StartUpDIExtension
    {
        public static void AddServiceDI(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService,CategoryService>();
            services.AddScoped<ISubCategoryService,SubCategoryService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ITokenManagementService, TokenManagementService>();
            services.AddScoped<IBasketService, BasketService>();

            //For Session
            services.AddSession(x =>
            {
                x.IdleTimeout = TimeSpan.FromMinutes(15);//We set Time here 
                x.Cookie.HttpOnly = true;
                x.Cookie.IsEssential = true;
            });
            services.AddDistributedMemoryCache(); //For use session

            // mapper
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            services.AddSingleton(mapperConfig.CreateMapper());
        }

        public static void AddCustomizeSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("AnadoluParamApi", new OpenApiInfo()
                {
                    Title = "RESTful API",
                    Version = "V1",
                    Description = "AnadoluPrmPracticum FinalCase",
                    Contact = new OpenApiContact()
                    {
                        Email = "enes.serenli@hotmail.com",
                        Name = "Enes Serenli",
                        Url = new Uri("https://github.com/EnesSERENLI/AnadoluParamApi_Management")
                    },
                    License = new OpenApiLicense()
                    {
                        Name = "MIT Licence",
                        Url = new Uri("https://opensource.org/licenses/MIT")
                    }
                });

                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "Techa Management for IT Company",
                    Description = "Enter JWT Bearer token **_only_**",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer", // Must be lower case
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };
                options.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {securityScheme, new string[] { }}
                });
            });
        }
    }
}
