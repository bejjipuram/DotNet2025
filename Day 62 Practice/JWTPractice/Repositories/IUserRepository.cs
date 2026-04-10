using JWTPractice.Models;
namespace JWTPractice.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByUserName(string username);
        Task<User> GetRefreshToken(string refreshToken);
        Task Update(User user);
    }
}
