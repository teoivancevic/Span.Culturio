using System;
using Microsoft.AspNetCore.Mvc;
using Span.Culturio.Api.Models;
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
		
		[HttpGet]
		public async Task<ActionResult<List<SubscriptionDto>>> GetSubscriptions(int userId)
		{
			var subscriptions = await _subscriptionService.GetSubscriptions(userId);
			return Ok(subscriptions);
		}

		[HttpPost]
		public async Task<ActionResult<SubscriptionDto>> CreateSubscription([FromBody] CreateSubscriptionDto subscription)
		{
			var subscriptionDto = await _subscriptionService.CreateSubscription(subscription);
			return Ok(subscriptionDto);
		}

		[HttpPost("activate")]
		public async Task<ActionResult<SubscriptionDto>> ActivateSubscription([FromBody] ActivateSubscriptionDto subscription)
		{
			var subscriptionDto = await _subscriptionService.ActivateSubscription(subscription);
			return subscriptionDto;
		}

		[HttpPost("track-visit")]
		public async Task<ActionResult> TrackVisit([FromBody] TrackVisitDto trackVisit)
		{

			var result = await _subscriptionService.TrackVisit(trackVisit);
			return Ok();
		}
		



	}
}

