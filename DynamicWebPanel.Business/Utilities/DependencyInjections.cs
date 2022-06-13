using System.Reflection;
using DynamicWebPanel.Data;
using DynamicWebPanel.Repository.Abstractions;
using DynamicWebPanel.Repository.Concretes;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace DynamicWebPanel.Business.Utilities;

public static class DependencyInjections
{
    public static void MyDependencyInjections(this IServiceCollection services)
    {
        services.AddScoped<DynamicWebPanelDbContext>(); //DbContext
        services.AddAutoMapper(Assembly.GetExecutingAssembly()); //AutoMapperExtensions
        services.AddMediatR(typeof(IAssemblyMarker).Assembly); //AutoMappers

        services.AddFluentValidation(fv =>
        {
            fv.ImplicitlyValidateChildProperties = true;
            fv.ImplicitlyValidateRootCollectionElements = true;
            fv.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        }); //FluentValidationAspNetCore


        //Repositories
        services.AddScoped<IDepartmentsRepository, DepartmentsRepository>();
        services.AddScoped<IUserRepository,UsersRepository>();



    }
}