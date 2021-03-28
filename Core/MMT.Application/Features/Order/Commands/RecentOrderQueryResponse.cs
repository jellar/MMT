namespace MMT.Application.Features.Order.Commands
{
    public class RecentOrderQueryResponse 
    {
        public CustomerDetailsVm Customer { get; set; }
        public OrderDetailsVm Order { get; set; }
       
    }
}
