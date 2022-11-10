using Span.Culturio.Api.Models;

namespace Span.Culturio.Api.Services.User
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetUsers();
        Task<UserDto> GetUser(int id);

        Task<UserDto> CreateUser(UserDto user);
        Task<bool> Login(UserDto user, string password);

    }
}