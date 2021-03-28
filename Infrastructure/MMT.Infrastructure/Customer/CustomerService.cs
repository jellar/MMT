using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MMT.Application.Contracts.Infrastructure;
using MMT.Application.Exceptions;
using MMT.Application.Models;
using Newtonsoft.Json;

namespace MMT.Infrastructure.Customer
{
    public class CustomerService : ICustomerService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly ILogger<CustomerService> _logger;
        public CustomerApiSettings ApiSettings { get; }

        public CustomerService(IOptions<CustomerApiSettings> apiSettings, IHttpClientFactory clientFactory, ILogger<CustomerService> logger)
        {
            _clientFactory = clientFactory;
            _logger = logger;
            ApiSettings = apiSettings.Value;
        }

        public async Task<Application.Models.Customer> GetCustomerDetails(string email)
        {
            var url = $"{ApiSettings.ApiUrl}?code={ApiSettings.Code}&email={email}";
            
            try
            {
                var client = _clientFactory.CreateClient("CustomerApiClient");
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<Application.Models.Customer>(result);
                }
                _logger.LogError($"Invalid Customer Details: {response.ReasonPhrase} - {JsonConvert.SerializeObject(response)}");
                throw new NotFoundException(email);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Customer service - {ex.Message}");
                throw ex;
            }
        }
    }
}
