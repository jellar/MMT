using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MMT.Application.Contracts.Infrastructure;
using MMT.Application.Models;
using MMT.Infrastructure.Customer;

namespace MMT.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<CustomerApiSettings>(configuration.GetSection("CustomerApiSettings"));
            services.AddHttpClient("CustomerApiClient", config =>
            {
                //config.BaseAddress = new Uri("CustomerAPIUrl");
                config.DefaultRequestHeaders.Add("accept", "application/json");
            });
            services.AddTransient<ICustomerService, CustomerService>();
            return services;
        }
    }
}
