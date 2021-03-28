using System.Threading.Tasks;
using MMT.Domain.Entities;

namespace MMT.Application.Contracts.Persistence
{
    public interface IOrderRepository : IAsyncRepository<Order>
    {
        Task<Order> GetRecentOrderByCustomerId(string customerId);
    }
}
