using SportInfo_Back.Models;
using SportInfo_Back.Services.Interfaces;
using SportInfo_Back.Tools;

namespace SportInfo_Back.Services
{
    public class UsersService : IUsersService
    {
        private readonly DataContext dataContext;

        public UsersService(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<User> Create(string username, string password, CancellationToken ctk)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User() { Username = username, PasswordHash = passwordHash, PasswordSalt = passwordSalt };
            await dataContext.Users.AddAsync(user, ctk);
            await dataContext.SaveChangesAsync(ctk);
            return user;
        }

        private void CreatePasswordHash(string password,out byte[] passwordHash,out byte[] passwordSalt) 
        {
            using var hMac = new System.Security.Cryptography.HMACSHA512();
            passwordSalt = hMac.Key;
            passwordHash = hMac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }
}
