using System;
using AutoMapper;
using Span.Culturio.Api.Data.Entities;
using Span.Culturio.Api.Models;

namespace Span.Culturio.Api.Profiles
{
	public class TrackVisitProfile : Profile
	{
		public TrackVisitProfile()
		{
			CreateMap<TrackVisitDto, TrackVisit>();
			CreateMap<TrackVisit, TrackVisitDto>();

			CreateMap<CreateTrackVisitDto, TrackVisit>();
			CreateMap<CreateTrackVisitDto, TrackVisitDto>();
		}
	}
}

