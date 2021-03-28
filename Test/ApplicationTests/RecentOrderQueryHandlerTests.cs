using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using MMT.Application.Contracts.Infrastructure;
using MMT.Application.Contracts.Persistence;
using MMT.Application.Features.Order.Commands;
using MMT.Application.Models;
using MMT.Application.Profiles;
using MMT.Domain.Entities;
using Moq;
using NUnit.Framework;
using Shouldly;

namespace ApplicationTests
{
    public class RecentOrderQueryHandlerTests
    {       
        private readonly IMapper _mapper;
        private readonly Mock<ICustomerService> _mockCustomerService;
        private readonly Mock<IOrderRepository> _mockOrderRepository;
        private readonly RecentOrderQueryHandler _recentOrderQueryHandler;

        public RecentOrderQueryHandlerTests()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new MappingProfile());
                });
                var mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }

            var mockLogger = new Mock<ILogger<RecentOrderQueryHandler>>();

            _mockOrderRepository = new Mock<IOrderRepository>();
            _mockCustomerService = new Mock<ICustomerService>();

            _recentOrderQueryHandler = new RecentOrderQueryHandler(_mapper, _mockOrderRepository.Object,
                                        _mockCustomerService.Object, mockLogger.Object);
        }


        [Test]
        public void InvalidCustomerTest()
        {
            var recentOrderQuery = new RecentOrderQuery() {User = "test@test.com", CustomerId = "1234"};
            _mockCustomerService.Setup(x => x.GetCustomerDetails(It.IsAny<string>())).ThrowsAsync(new Exception());
            
            Assert.ThrowsAsync<Exception>(() => _recentOrderQueryHandler.Handle(recentOrderQuery, CancellationToken.None));
        }

        private static TestCaseData[] _testData =
        {
            new TestCaseData(Customers.GetCustomers().First(), (Order) null, false, 0, false)
                .SetName("ValidCustomerWithoutOrders"),

            new TestCaseData(Customers.GetCustomers().First(), Orders.GetOrders().OrderByDescending(o=>o.Orderdate).First(), true, 2, false)
                .SetName("ValidCustomerWithOrders"),

            new TestCaseData(Customers.GetCustomers().First(), Orders.GetOrders().Where(o=>o.Containsgift == true)
                    .OrderByDescending(t => t.Orderdate).First(), true, 1, true)
            .SetName("ValidCustomerWithOrderContainsGift")

        };
        
        [Test, TestCaseSource(nameof(_testData))]
        public async Task ValidCustomerTests(Customer customer, Order? order, bool expectOrder, int productCount, bool containsGift)
        {
            var recentOrderQuery = new RecentOrderQuery() {User = "f1.n@test.com", CustomerId = "1234"};

            _mockCustomerService.Setup(x => x.GetCustomerDetails(It.IsAny<string>())).ReturnsAsync(customer);

            _mockOrderRepository.Setup(x => x.GetRecentOrderByCustomerId(It.IsAny<string>()))
                .ReturnsAsync(order);
            
            var result = await _recentOrderQueryHandler.Handle(recentOrderQuery, CancellationToken.None);

            result.ShouldNotBeNull();
            result.Customer.ShouldNotBeNull();
            if(expectOrder)
            {
                 result.Order.ShouldNotBeNull();
                 result.Order.OrderItems.Length.ShouldBe(productCount);
                 result.Order.OrderItems.All(p => p.Product == "Gift").ShouldBe(containsGift);
            }
            else
            {
                result.Order.ShouldBeNull();
            }
            
        }
    }
}
