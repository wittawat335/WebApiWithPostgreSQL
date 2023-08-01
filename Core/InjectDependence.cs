using Core.AutoMapper;
using Core.Services;
using Core.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace Core
{
    public static class InjectDependence
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperProfile));
            services.AddScoped<IAddressService, AddressService>();
        }
    }
}
