using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Login_Register.model
{
    public class UserStore: User
    {
        public readonly UserContext _context;
        public UserStore(UserContext context)
        {
            _context = context;
        }
        public async Task<IdentityResult> CreateAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return IdentityResult.Success;

        }
        public async Task<IdentityResult> DeleteAsync(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return IdentityResult.Success;

        }
         public void Dispose() => throw new NotImplementedException();

        public async Task<User?> FindByIdAsync(int userId)
        {
            return await _context.Users.FindAsync(userId);
        }


        public async Task<User?> FindByNameAsync(string userName)
        {
            return await _context.Users.FindAsync(userName);
        }


        public async Task<User?> FindByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

        }
        public Task<int> GetUserIdAsync(User user)
        {
            return Task.FromResult(user.Id);
        }
        public Task<string> GetUserPassword(User user) 
        {
            return Task.FromResult(user.Password);
        }
        public Task<string?> GetUserEmailAsync(User user)
        {
            return Task.FromResult(user.Email);
        }
        public Task SetUserNameAsync(User user, string? userName)
        {
            user.Name = userName;
            return Task.CompletedTask;
        }

        public async Task<IdentityResult> UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return IdentityResult.Success;
        }
        public async Task SetNewPassword(User user, string newPassword)
        {  
                user.Password = newPassword;
                await _context.SaveChangesAsync();
            }
        }
    }

