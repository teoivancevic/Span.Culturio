using System;
using AutoMapper;
using Span.Culturio.Api.Data.Entities;
using Span.Culturio.Api.Models;

namespace Span.Culturio.Api.Profiles
{
	public class PackageCultureObjectProfile : Profile
	{
        public PackageCultureObjectProfile()
        {
            CreateMap<CreatePackageCultureObjectDto, PackageCultureObject>();

            CreateMap<PackageCultureObjectDto, PackageCultureObject>();
            CreateMap<PackageCultureObject, PackageCultureObjectDto>();
        }
            
	}
}

