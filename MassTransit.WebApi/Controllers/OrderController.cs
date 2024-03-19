using MassTransit.WebApi.Domain;
using Microsoft.AspNetCore.Mvc;

namespace MassTransit.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrderController : ControllerBase
	{
		private readonly ILogger<OrderController> _logger;
		private readonly IBusControl _bus;

        public OrderController(ILogger<OrderController> logger, IBusControl bus)
        {
            _logger = logger;
			_bus = bus;
        }

		[HttpPost]
		public async Task<IActionResult> Post([FromBody] long orderId)
		{
			await _bus.Publish<Order>( new Order { OrderId = orderId });
			_logger.LogInformation($"Message received. OrderId: {orderId}");

			return Ok($"{DateTime.Now:o}");
		}
    }
}
