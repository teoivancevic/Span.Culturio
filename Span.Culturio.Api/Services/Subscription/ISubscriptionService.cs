using System;
using Span.Culturio.Api.Models;

namespace Span.Culturio.Api.Services.Subscription
{
	public interface ISubscriptionService
	{
		public Task<IEnumerable<SubscriptionDto>> GetSubscriptions(int id);

		public Task<SubscriptionDto> CreateSubscription(CreateSubscriptionDto subscription);
		public Task<TrackVisitDto> TrackVisit(TrackVisitDto visit);
		public Task<SubscriptionDto> ActivateSubscription(ActivateSubscriptionDto activateSubscription);
	}
}

