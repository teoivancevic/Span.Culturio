using System;
using AutoMapper;
using Span.Culturio.Api.Data.Entities;
using Span.Culturio.Api.Models;

namespace Span.Culturio.Api.Profiles
{
	public class UserProfile : Profile
	{
		public UserProfile()
		{
			CreateMap<UserDto, User>();
			CreateMap<User, UserDto>();

			//CreateMap<UserDto, RegisterUserDto>();
			CreateMap<RegisterUserDto, UserDto>(); //iz registeruserdto u userdto

			//CreateMap<User, RegisterUserDto>();
			CreateMap<RegisterUserDto, User>();
		}
	}
}

