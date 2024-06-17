using Microsoft.AspNetCore.Mvc;
using SportInfo_Back.Mediators.Interfaces;
using SportInfo_Back.Models;
using SportInfo_Back.Services.Interfaces;
using SportInfo_Back.ViewModels;

namespace SportInfo_Back.Mediators
{
   
    public class UsersMediators: IUsersMediators
    {
        private readonly IUsersService UsersService;

        public UsersMediators(IUsersService usersService)
        {
            UsersService = usersService;
        }
        public async Task<User> Create(string username, string password, CancellationToken ctk)
        {
            return await UsersService.Create(username, password, ctk);
        }
        public async Task<User> Authenticate(ConnexionVM connexionInfo, CancellationToken ctk = default)
        {
            return await UsersService.Authenticate(connexionInfo.Username,connexionInfo.Password, ctk);
        }
    }
}
