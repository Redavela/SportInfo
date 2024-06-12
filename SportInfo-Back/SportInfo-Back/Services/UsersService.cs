using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportInfo_Back.Models;
using SportInfo_Back.Services.Interfaces;
using SportInfo_Back.Tools;
using SportInfo_Back.ViewModels;

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
            DateTimeOffset date = DateTimeOffset.Now;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User() { Username = username, DateCreation = date, PasswordHash = passwordHash, PasswordSalt = passwordSalt };
            await dataContext.Users.AddAsync(user, ctk);
            await dataContext.SaveChangesAsync(ctk);
            return user;
        }
        public async Task<User> Authenticate(string username, string password, CancellationToken ctk)
        {
            var user = await dataContext.Users.FirstOrDefaultAsync(u => u.Username == username,ctk);
            if (user == null || !VerifyPasswordHash(password,user.PasswordHash,user.PasswordSalt))
            {
                throw new Exception("L'utilisateur ou le mdp est erroné !");
            }
            return user;
        }

        private void CreatePasswordHash(string password,out byte[] passwordHash,out byte[] passwordSalt) 
        {
            using var hMac = new System.Security.Cryptography.HMACSHA512();
            passwordSalt = hMac.Key;
            passwordHash = hMac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
        private bool VerifyPasswordHash(string password, byte[]? passwordHash, byte[]? passwordSalt)
        {
            if(string.IsNullOrEmpty(password)) 
            {
                throw new Exception("Le mdp est obligatoire !");
            }
            if(passwordHash?.Length!= 64)
            {
                throw new Exception("L'utilisateur ou le mdp est erroné !");
            }
            if (passwordSalt?.Length != 128)
            {
                throw new Exception("L'utilisateur ou le mdp est erroné !");
            }
            using (var hMac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hMac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i]) return false;
                }
            } 
            return true;
        }
    }
}
