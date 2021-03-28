using MediatR;

namespace MMT.Application.Features.Order.Commands
{
    public class RecentOrderQuery : IRequest<RecentOrderQueryResponse>
    {
        public string User { get; set; }
        public string CustomerId { get; set; }    
    }
}
