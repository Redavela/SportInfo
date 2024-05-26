using SportInfo_Back.Models;

namespace SportInfo_Back.Services.Interfaces
{
    public interface IUsersService
    {
        Task<User> Create(string username, string password, CancellationToken ctk);
    }
}
