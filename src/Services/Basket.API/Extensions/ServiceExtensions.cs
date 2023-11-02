using Basket.API.Repositories;
using Basket.API.Repositories.Interfaces;
using Contracts.Common.Interfaces;
using Infrastructure.Common;

namespace Basket.API.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

            services.ConfigureRedis(configuration);
            services.AddInfrastructureService();
        }

        private static void ConfigureRedis(this IServiceCollection services, IConfiguration configuration)
        {
            var redisConnectionString = configuration.GetSection("CacheSetttings:ConnectionString").Value;
            if (string.IsNullOrEmpty(redisConnectionString))
            {
                throw new ArgumentException("Redis Conenction string is not configured!");
            }

            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = redisConnectionString;
            });
        }

        private static void AddInfrastructureService(this IServiceCollection services)
        {
            services.AddScoped<IBasketRepository, BasketRepository>()
                    .AddTransient<ISerializerService, SerializerService>();
        }
    }
}
