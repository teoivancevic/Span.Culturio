using System;
using AutoMapper;
using Span.Culturio.Api.Data.Entities;
using Span.Culturio.Api.Models;

namespace Span.Culturio.Api.Profiles
{
	public class SubscriptionProfile : Profile
	{
		public SubscriptionProfile()
		{
			CreateMap<Subscription, SubscriptionDto>();
			CreateMap<SubscriptionDto, Subscription>();

			CreateMap<CreateSubscriptionDto, SubscriptionDto>();

			CreateMap<CreateSubscriptionDto, Subscription>();
		}
	}
}

