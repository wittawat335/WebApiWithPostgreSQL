using Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class InjectDependence
    {
        public static void RegisterDBConnectionString(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<sampleDBContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("PostgreSQl"));
            });
        }

        public static void RegisterRepository(this IServiceCollection services)
        {

        }
    }
}
