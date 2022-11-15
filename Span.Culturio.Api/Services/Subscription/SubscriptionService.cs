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
                //var subscriptionEntity = _mapper.Map<Data.Entities.Subscription>(subscription);
				subscription.State = "active";
				subscription.ActiveFrom = DateTime.Now;
				subscription.ActiveTo = subscription.ActiveFrom.AddDays(30); // recimo da je subscription 30 dana

				_context.Subscriptions.Update(subscription);
				await _context.SaveChangesAsync();
				
            }

            SubscriptionDto subscriptionDto = _mapper.Map<SubscriptionDto>(subscription);

            return subscriptionDto;
		}

		public async Task<bool> TrackVisit(CreateTrackVisitDto trackVisit)
		{
			//nezz sta ovdije trebam napravit uopce ngl



			var subscription = await _context.Subscriptions.FindAsync(trackVisit.SubscriptionId);
			var packageCultureObject = await _context.PackageCultureObjects.Where(x => x.PackageId.Equals(subscription.PackageId)).FirstOrDefaultAsync();

			var availableVisits = packageCultureObject.AvailableVisits;
			var timesVisited = _context.TrackVisits.Count(x => x.SubscriptionId == trackVisit.SubscriptionId && x.CultureObjectId == trackVisit.CultureObjectId);


			//var trackVisitDto = new TrackVisitDto();


            if (timesVisited < availableVisits && subscription.State == "active")
			{
                var trackVisitEntity = _mapper.Map<Data.Entities.TrackVisit>(trackVisit);
                _context.TrackVisits.Add(trackVisitEntity);
                await _context.SaveChangesAsync();

				//trackVisitDto = _mapper.Map<TrackVisitDto>(trackVisitEntity);
				return true;

            }
			

            //subscription.RecordedVisits = subscription.RecordedVisits + 1;

            //var cultureObject = await _context.CultureObjects.FindAsync(trackVisit.CultureObjectId);
            //var package = await _context.Packages.Where(x => x.CultureObjects.Contains(trackVisit.cultureObjectId).FirstOrDefaultAsync();
            //package.CultureObjects.Where(x => x.Id.Equals(trackVisit.cultureObjectId)).




            return false;
		}




	}
}

