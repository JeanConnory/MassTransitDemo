using Microsoft.AspNetCore.Mvc;

namespace MassTransit.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class HealthCheckController : ControllerBase
	{
		private readonly ILogger<HealthCheckController> _logger;

        public HealthCheckController(ILogger<HealthCheckController> logger)
        {
            _logger = logger;
        }

		[HttpGet]
		public string Get()
		{
			return $"{DateTime.Now:o}";
		}
    }
}
