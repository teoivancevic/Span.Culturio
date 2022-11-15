using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Span.Culturio.Api.Data;
using Span.Culturio.Api.Models;

namespace Span.Culturio.Api.Services.Subscription
{
	public class SubscriptionService : ISubscriptionService
	{

		private readonly DataContext _context;
		private readonly IMapper _mapper;


		public SubscriptionService(DataContext context, IMapper mapper) 
		{
			_context = context;
			_mapper = mapper;
		}


		public async Task<IEnumerable<SubscriptionDto>> GetSubscriptions(int id)
		{
			var subscriptions = await _context.Subscriptions.Where(x => x.UserId.Equals(id)).ToListAsync();
			var subscriptionsDto = _mapper.Map<List<SubscriptionDto>>(subscriptions);

			return subscriptionsDto;

		}


		public async Task<SubscriptionDto> CreateSubscription(CreateSubscriptionDto subscription)
		{
			var subscriptionEntity = _mapper.Map<Data.Entities.Subscription>(subscription);

			subscriptionEntity.State = "not active";
			
			_context.Subscriptions.Add(subscriptionEntity);
			await _context.SaveChangesAsync();

			var subscriptionDto = _mapper.Map<SubscriptionDto>(subscription);

			return subscriptionDto;
		}


		//ovo je update za ovaj subscription
		public async Task<SubscriptionDto> ActivateSubscription(ActivateSubscriptionDto activateSubscription)
		{
			var subscription = await _context.Subscriptions.FindAsync(activateSubscription.SubscriptionId);
			if(subscription is not null && subscription.State != "active")
			{
				var package = await _context.Packages.FindAsync(subscription.PackageId);

				subscription.State = "active";
				subscription.ActiveFrom = DateTime.Now;
				subscription.ActiveTo = subscription.ActiveFrom.AddDays(package.ValidDays); // uzima broj valid dana iz paketa na koji se subscribea

				_context.Subscriptions.Update(subscription);
				await _context.SaveChangesAsync();
				
            }

            SubscriptionDto subscriptionDto = _mapper.Map<SubscriptionDto>(subscription);

            return subscriptionDto;
		}


		public async Task<bool> TrackVisit(CreateTrackVisitDto trackVisit)
		{

			var subscription = await _context.Subscriptions.FindAsync(trackVisit.SubscriptionId);
			if(subscription is not null && subscription.ActiveTo >= DateTime.Now && subscription.State == "active")
			{
                var packageCultureObject = await _context.PackageCultureObjects.Where(x => x.PackageId.Equals(subscription.PackageId)).FirstOrDefaultAsync();

				if (packageCultureObject is null)
				{
					return false;
				}

                var availableVisits = packageCultureObject.AvailableVisits;
                var timesVisited = _context.TrackVisits.Count(x => x.SubscriptionId == trackVisit.SubscriptionId && x.CultureObjectId == trackVisit.CultureObjectId);


                if (timesVisited < availableVisits)
                {
                    var trackVisitEntity = _mapper.Map<Data.Entities.TrackVisit>(trackVisit);
                    trackVisitEntity.TimeEntered = DateTime.Now;

                    _context.TrackVisits.Add(trackVisitEntity);
                    await _context.SaveChangesAsync();

                    return true;

                }
            }
			

            return false;
		}




	}
}

