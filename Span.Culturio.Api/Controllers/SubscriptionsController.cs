using System;
using Microsoft.AspNetCore.Mvc;
using Span.Culturio.Api.Services.Subscription;

namespace Span.Culturio.Api.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class SubscriptionsController : ControllerBase
	{
		private readonly ILogger _logger;
		private readonly ISubscriptionService _subscriptionService;
		private readonly IConfiguration _configuration;

		public SubscriptionsController(ILogger<SubscriptionsController> logger, ISubscriptionService subscriptionService, IConfiguration configuration)
		{
			_logger = logger;
			_subscriptionService = subscriptionService;
			_configuration = configuration;
		}



	}
}

