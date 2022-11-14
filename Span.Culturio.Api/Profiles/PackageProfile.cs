using System;
using AutoMapper;
using Span.Culturio.Api.Data.Entities;
using Span.Culturio.Api.Models;

namespace Span.Culturio.Api.Profiles
{
	public class PackageProfile : Profile
	{
		public PackageProfile()
		{
			CreateMap<Package, PackageDto>();
			CreateMap<PackageDto, Package>();

			CreateMap<CreatePackageDto, Package>();
            CreateMap<Package, CreatePackageDto>();


            
        }
	}
}

