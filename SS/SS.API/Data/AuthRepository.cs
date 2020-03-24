using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SS.API.Models;

namespace SS.API.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        public AuthRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Ssuser> Login(string userName, string password)
        {
            var user = await _context.Ssuser.FirstOrDefaultAsync(x => x.UserName == userName);

            if (user == null)
            {
                return null;
            }

            if (!VerifyPasswordHash(password, user.PwHash, user.PwSalt))
            {
                return null;
            }

            return user;
        }

        private bool VerifyPasswordHash(string password, byte[] pwHash, byte[] pwSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(pwSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != pwHash[i]) return false;
                }
            }

            return true;
        }

        public async Task<Ssuser> Register(Ssuser user, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PwHash = passwordHash;
            user.PwSalt = passwordSalt;

            await _context.Ssuser.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<bool> UserExists(string username)
        {
            if (await _context.Ssuser.AnyAsync(x => x.UserName == username))
            {
                return true;
            }

            return false;
        }
    }
}