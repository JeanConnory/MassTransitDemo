using MassTransit.WebApi.Domain;

namespace MassTransit.WebApi.Consumer
{
	public class OrderConsumer : IConsumer<Order>
	{
		private readonly ILogger<OrderConsumer> _logger;

        public OrderConsumer(ILogger<OrderConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<Order> context)
		{
			try
			{
				var order = context.Message;
				_logger.LogInformation($"Order received: {order.OrderId}");

			}
			catch (Exception ex)
			{
				_logger.LogError($"Error on try to consume order. Exception: {ex}");
			}

			return Task.CompletedTask;
		}
	}
}