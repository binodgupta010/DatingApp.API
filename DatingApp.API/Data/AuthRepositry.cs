using System;
using System.Threading.Tasks;
using DatingApp.API.Models;

namespace DatingApp.API.Data
{
    public class AuthRepositry : IAuthRepository
    {

        private readonly DataContext _context;
        public AuthRepositry(DataContext context)
        {
            _context = context;
        }
        public Task<User> Login(string userName, string password)
        {
            throw new System.NotImplementedException();
        }

        public async Task<User> Register(User user, string password)
        {
           byte[] passwordHash, passwordSalt;
           CreatePasswordHash(password, out passwordHash, out passwordSalt);
           user.PasswordHash = passwordHash;
           user.PasswordSalt = passwordSalt;
           await _context.AddAsync(user);
           await _context.SaveChangesAsync();
           return user;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
           using(var hmac= new System.Security.Cryptography.HMACSHA512())
           {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
           }
        }

        public Task<bool> UserExist(string userName)
        {
            throw new System.NotImplementedException();
        }
    }
}