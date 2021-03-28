namespace MMT.Application.Features.Order.Commands
{
    public class OrderDetailsVm
    {
        public string OrderNumber { get; set; }
        public string OrderDate { get; set; }
        public string DeliveryAddress { get; set; }

        public ProductVm[] OrderItems { get; set; }
        public string DeliveryExpected { get; set; }

    }

    public class ProductVm
    {
        public string Product { get; set; }
        public int? Quantity { get; set; }
        public decimal? PriceEach { get; set; }
    }
}
