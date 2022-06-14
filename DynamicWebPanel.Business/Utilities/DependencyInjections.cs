using System.Reflection;
using System.Text;
using DynamicWebPanel.Business.CrossCuttingConcerns.Jwt.Abstracts;
using DynamicWebPanel.Business.CrossCuttingConcerns.Jwt.Concretes;
using DynamicWebPanel.Business.Utilities.Constans;
using DynamicWebPanel.Data;
using DynamicWebPanel.Repository.Abstractions;
using DynamicWebPanel.Repository.Concretes;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using static DynamicWebPanel.Business.CrossCuttingConcerns.Jwt.Abstracts.ITokenService;

namespace DynamicWebPanel.Business.Utilities;

public static class DependencyInjections
{
    public static void MyDependencyInjections(this IServiceCollection services)
    {
        // JWT

        IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        var jwtSettings = new JwtSettings();
        config.Bind(nameof(JwtSettings), jwtSettings);

        services.AddSingleton(jwtSettings);

        services.AddAuthorization(x =>
        {
            x.AddPolicy(JwtBearerDefaults.AuthenticationScheme, builder =>
            {
                builder.RequireAuthenticatedUser();
            });
        });


        services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
            .AddJwtBearer(x =>
            {
                var jwtSettings = services.BuildServiceProvider().GetService<JwtSettings>()!;
                x.SaveToken = true;
                x.RequireHttpsMetadata = false;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.AccessTokenSecret)),
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience
                };
            });

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            c.EnableAnnotations();

            c.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
            {
                Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = JwtBearerDefaults.AuthenticationScheme
            });

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
        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        services.AddScoped<IAuthenticateService, AuthenticateService>();
        services.AddScoped<IRefreshTokenValidator, RefreshTokenValidator>();
        services.AddScoped<ITokenGenerator, TokenGenerator>();
        services.AddScoped<IAccessTokenService, AccessTokenService>();
        services.AddScoped<IRefreshTokenService, RefreshTokenService>();


        //SWAGGER//
        services.AddSwaggerGen(c =>
        {
            
            c.EnableAnnotations();

            //c.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
            //{
            //    Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
            //    Name = "Authorization",
            //    In = ParameterLocation.Header,
            //    Type = SecuritySchemeType.ApiKey,
            //    Scheme = JwtBearerDefaults.AuthenticationScheme
            //});

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