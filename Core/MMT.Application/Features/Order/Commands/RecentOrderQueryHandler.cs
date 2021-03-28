using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using MMT.Application.Contracts.Infrastructure;
using MMT.Application.Contracts.Persistence;
using MMT.Application.Exceptions;

namespace MMT.Application.Features.Order.Commands
{
    public class RecentOrderQueryHandler : IRequestHandler<RecentOrderQuery, RecentOrderQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;
        private readonly ICustomerService _customerService;
        private readonly ILogger<RecentOrderQueryHandler> _logger;

        public RecentOrderQueryHandler(IMapper mapper, IOrderRepository orderRepository, ICustomerService customerService, ILogger<RecentOrderQueryHandler> logger)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
            _customerService = customerService;
            _logger = logger;
        }

        public async Task<RecentOrderQueryResponse> Handle(RecentOrderQuery request, CancellationToken cancellationToken)
        {
            var recentOrderResponse = new RecentOrderQueryResponse();

            var validator = new RecentOrderQueryValidator();
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (validatorResult.Errors.Count > 0)
            {
                _logger.LogError("Validation errors");
                throw new ValidationException(validatorResult);
            }


            try
            {
                var customer = await _customerService.GetCustomerDetails(request.User.ToLower());
                if (customer != null)
                {
                    if (!string.Equals(request.CustomerId, customer.CustomerId,
                        StringComparison.OrdinalIgnoreCase))
                    {
                        _logger.LogError("Requested customer id does not exists.");
                        throw new Exception("Requested customer id does not exists.");
                    }

                    var customerDetails = _mapper.Map<CustomerDetailsVm>(customer);
                    recentOrderResponse.Customer = customerDetails;
                    var order = await _orderRepository.GetRecentOrderByCustomerId(request.CustomerId);

                    UpdateProductName(order);

                    if (order != null)
                    {
                        var orderDetails = _mapper.Map<OrderDetailsVm>(order);

                        orderDetails.DeliveryAddress = customer.ToString();
                        recentOrderResponse.Order = orderDetails;
                    }
                }
                else
                {
                    _logger.LogError("Customer does not exists");
                    throw new Exception("Customer does not exists");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error happened - {ex.Message}");
                throw ex;
            }

            return recentOrderResponse;
        }

        /// <summary>
        /// to update product name to 'Gift' if order containsGift flag
        /// </summary>
        /// <param name="order"></param>
        private static void UpdateProductName(Domain.Entities.Order order)
        {
            if (order?.Containsgift != true) return;
            foreach (var orderItem in order.Orderitems)
            {
                orderItem.Product.Productname = "Gift";
            }
        }
    }
}
