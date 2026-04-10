using JWTPractice.Data;
using JWTPractice.Models;
using Microsoft.EntityFrameworkCore;
namespace JWTPractice.Repositories
{
    public class UserRepository:IUserRepository
    {
        private readonly MyDBContext _context;
        public UserRepository(MyDBContext context)
        {
            _context = context;
        }
        public async Task<User> GetUserByUserName(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);
        }
        public async Task<User> GetRefreshToken(string refreshToken)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);
        }
        public async Task Update(User user)
        {
            _context.Users.Update(user);
            _context.SaveChangesAsync();

        }
    }
}
