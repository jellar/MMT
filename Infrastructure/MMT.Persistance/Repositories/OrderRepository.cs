using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MMT.Application.Contracts.Persistence;
using MMT.Domain.Entities;
using MMT.Persistence.Entities;

namespace MMT.Persistence.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        protected readonly OrderContext dbContext;
        
        public OrderRepository(OrderContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Order> GetRecentOrderByCustomerId(string customerId)
        {
            var order = await dbContext.Orders.Where(o => o.Customerid == customerId)
                .Include(i=>i.Orderitems)
                .ThenInclude(oi=>oi.Product)
                .OrderByDescending(o => o.Orderdate).FirstOrDefaultAsync();

            return order;
        }
    }
}
