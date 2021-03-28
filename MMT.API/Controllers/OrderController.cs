using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using MMT.Application.Features.Order.Commands;

namespace MMT.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<OrderController> _logger;

        public OrderController(IMediator mediator, ILogger<OrderController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost(Name = "recent")]
        public async Task<ActionResult<RecentOrderQueryResponse>> RecentOrder([FromBody] RecentOrderQuery recentOrderQuery)
        {
            var order = await _mediator.Send(recentOrderQuery);
            return Ok(order);
        }
    }
}
