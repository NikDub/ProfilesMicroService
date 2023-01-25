using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ProfilesMicroService.Application.Consumers;
using ProfilesMicroService.Application.Services;
using ProfilesMicroService.Application.Services.Abstractions;
using ProfilesMicroService.Infrastructure;
using ProfilesMicroService.Infrastructure.Repository;
using ProfilesMicroService.Infrastructure.Repository.Abstractions;

namespace ProfilesMicroService.Api.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
            {
                options.Authority = configuration.GetValue<string>("Routes:AuthorityRoute") ??
                                    throw new NotImplementedException();
                options.Audience = configuration.GetValue<string>("Routes:Scopes") ??
                                   throw new NotImplementedException();
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = true,
                    ValidAudience = configuration.GetValue<string>("Routes:Scopes") ??
                                    throw new NotImplementedException(),
                    ValidateIssuer = true,
                    ValidIssuer = configuration.GetValue<string>("Routes:AuthorityRoute") ??
                                  throw new NotImplementedException(),
                    ValidateLifetime = true
                };
            });
    }

    public static void ConfigureDbConnection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                assembly => assembly.MigrationsAssembly("ProfilesMicroService.Api"));
        });
    }

    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<IDoctorRepository, DoctorRepository>();
        services.AddScoped<IPatientRepository, PatientRepository>();
        services.AddScoped<IReceptionistRepository, ReceptionistRepository>();
        services.AddScoped<IStatusRepository, StatusRepository>();
        services.AddScoped<IReceptionistService, ProfileService>();
        services.AddScoped<IDoctorService, DoctorService>();
        services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
        services.AddAutoMapper(typeof(MappingProfile));
    }

    public static void ConfigureMassTransit(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddMassTransit(r =>
        {
            r.AddConsumer<SpecializationConsumer>();
            r.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(new Uri(configuration.GetValue<string>("RabbitMQ:ConnectionStrings") ??
                                 throw new NotImplementedException()));
                cfg.ReceiveEndpoint(configuration.GetValue<string>("RabbitMQ:QueueName:Consumer:Specialization") ??
                               throw new NotImplementedException(),
                  e =>
                  {
                      e.ConfigureConsumer<SpecializationConsumer>(context);
                  });
            });
        });
    }

    public static void ConfigureSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(setup =>
        {
            setup.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Place to add JWT with Bearer",
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });

            setup.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        },
                        Name = "Bearer"
                    },
                    new List<string>()
                }
            });
        });
    }
}