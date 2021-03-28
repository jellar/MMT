using System.Threading.Tasks;
using MMT.Application.Models;

namespace MMT.Application.Contracts.Infrastructure
{
    public interface ICustomerService
    {
        Task<Customer> GetCustomerDetails(string email);
    }
}
