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


		public async Task<CreateSubscriptionDto> CreateSubscription(CreateSubscriptionDto subscription)
		{
			var subscriptionEntity = _mapper.Map<Data.Entities.Subscription>(subscription);
			_context.Subscriptions.Add(subscriptionEntity);
			await _context.SaveChangesAsync();

			return subscription;
		}


		//ovo je update za ovaj subscription
		public async Task<SubscriptionDto> ActivateSubscription(int id)
		{
			var subscription = await _context.Subscriptions.FindAsync(id);
			if(subscription is not null && subscription.State != "active")
			{
                //var subscriptionEntity = _mapper.Map<Data.Entities.Subscription>(subscription);
				subscription.State = "active";
				subscription.ActiveFrom = DateTime.Now;
				subscription.ActiveTo = DateTime.Now; // PLACEHOLDER

				_context.Subscriptions.Update(subscription);
				await _context.SaveChangesAsync();
				
            }

            SubscriptionDto subscriptionDto = _mapper.Map<SubscriptionDto>(subscription);

            return subscriptionDto;
		}

		public async Task<TrackVisitDto> TrackVisit(TrackVisitDto trackVisit)
		{
			//nezz sta ovdije trebam napravit uopce ngl 

			return trackVisit;
		}




	}
}

