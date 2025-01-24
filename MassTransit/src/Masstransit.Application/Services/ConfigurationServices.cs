using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MassTransit.Application.Services;

public static class ConfigurationService 
{ 
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
 { 
    services.AddMassTransit(x=>
    {
      x.AddConsumers(Assembly.GetExecutingAssembly());
      x.UsingRabbitMq((ctx,cfg)=>
        { 
            cfg.Host(configuration["RabbitMQ:Host"], "/" , c=> 
            { 
              c.Username(configuration["RabbitMQ:Username"]);
              c.Password(configuration["RabbitMQ:Password"]); 
             }); 
            cfg.ConfigureEndpoints(ctx); 
        }); 
      }); 
   return services; 
 } 
}   