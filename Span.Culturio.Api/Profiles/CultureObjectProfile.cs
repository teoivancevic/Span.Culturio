using System;
using AutoMapper;
using Span.Culturio.Api.Data.Entities;
using Span.Culturio.Api.Models;

namespace Span.Culturio.Api.Profiles
{
	public class CultureObjectProfile : Profile
	{
		public CultureObjectProfile()
		{
			CreateMap<CultureObject, CultureObjectDto>();
			CreateMap<CultureObjectDto, CultureObject>();

			CreateMap<CreateCultureObjectDto, CultureObjectDto>();

			CreateMap<CreateCultureObjectDto, CultureObject>();


			//CreateMap<PackageCultureObject, PackageCultureObjectDto>();
            //CreateMap<PackageCultureObjectDto, PackageCultureObject>();
        }
	}
}

