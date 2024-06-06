using SportInfo_Back.Mediators.Interfaces;
using SportInfo_Back.Models;
using SportInfo_Back.Services.Interfaces;

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
    }
}
