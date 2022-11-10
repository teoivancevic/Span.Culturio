using System;
using AutoMapper;
using Span.Culturio.Api.Data;
using Span.Culturio.Api.Models;
using Microsoft.EntityFrameworkCore;
using Span.Culturio.Api.Helpers;

namespace Span.Culturio.Api.Services.User
{
	public class UserService : IUserService
	{
		private readonly DataContext _context;
		private readonly IMapper _mapper;
		private readonly IUserService _userService;

		public UserService(DataContext context, IMapper mapper, IUserService userService)
		{
			_context = context;
			_mapper = mapper;
			_userService = userService;
		}

		public async Task<IEnumerable<UserDto>> GetUsers()
		{
			var users = await _context.Users.ToListAsync();
			var usersDto = _mapper.Map<List<UserDto>>(users);
			return usersDto;
		}

		public async Task<UserDto> GetUser(int id)
		{
			//var user = _context.Users.Where(x => x.Id.Equals(id));
			var user = await _context.Users.FindAsync(id);
			var userDto = _mapper.Map<UserDto>(user);
			return userDto;
		}


		//dolje je dio za auth controller
        public async Task<UserDto> CreateUser(UserDto user)
        {
            user.Id = 0;
            var userEntity = _mapper.Map<Data.Entities.User>(user);
            UserHelper.CreatePasswordHash(user.Password, out byte[] passwordHash, out byte[] passwordSalt);
            userEntity.PasswordHash = passwordHash;
            userEntity.PasswordSalt = passwordSalt;

            _context.Users.Add(userEntity);
            await _context.SaveChangesAsync();

            //u FairBank tu ima Account dio, msm da mi to ne treba nista

            return user;
        }


        public async Task<bool> Login(UserDto user, string password)
        {
            var userEntity = _mapper.Map<Data.Entities.User>(user);
            if (userEntity is not null && UserHelper.VerifyPasswordHash(password, userEntity.PasswordHash, userEntity.PasswordSalt))
            {
                return true;
            }

            return false;
        }

    }
}

