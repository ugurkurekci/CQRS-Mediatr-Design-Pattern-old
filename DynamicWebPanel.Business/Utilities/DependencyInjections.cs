using DynamicWebPanel.Data;
using DynamicWebPanel.Repository.Abstractions;
using DynamicWebPanel.Repository.Concretes;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace DynamicWebPanel.Business.Utilities;

public static class DependencyInjections
{
    public static void MyDependencyInjections(this IServiceCollection services)
    {

        //DbContext
        services.AddScoped<DynamicWebPanelDbContext>();

        //AutoMapperExtensions
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        //AutoMappers
        services.AddMediatR(typeof(IAssemblyMarker).Assembly);

        //FluentValidationAspNetCore
        services.AddFluentValidation(fv =>
        {
            fv.ImplicitlyValidateChildProperties = true;
            fv.ImplicitlyValidateRootCollectionElements = true;
            fv.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        });

        //Repositories
        services.AddScoped<IDepartmentsRepository, DepartmentsRepository>();
        services.AddScoped<IUserRepository, UsersRepository>();

        //SWAGGER//
        services.AddSwaggerGen(c =>
        {

            c.EnableAnnotations();
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = JwtBearerDefaults.AuthenticationScheme
                }
            },
            Array.Empty<string>()
        }
    });
        });
    }
}