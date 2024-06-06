using SportInfo_Back.Models;

namespace SportInfo_Back.Mediators.Interfaces
{
    public interface IUsersMediators
    {
        Task<User> Create(string username, string password, CancellationToken ctk);
    }
}
