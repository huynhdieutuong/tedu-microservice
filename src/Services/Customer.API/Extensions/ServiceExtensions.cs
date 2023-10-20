using Customer.API.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Customer.API.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.ConfigureCustomerDbContext(configuration);
            services.AddInfrastructureService();
        }

        private static void ConfigureCustomerDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnectionString");

            services.AddDbContext<CustomerContext>(options => options.UseNpgsql(connectionString));
        }

        private static void AddInfrastructureService(this IServiceCollection services)
        {

        }
    }
}
