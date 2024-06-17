using Microsoft.AspNetCore.Mvc;
using SportInfo_Back.Models;
using SportInfo_Back.ViewModels;

namespace SportInfo_Back.Mediators.Interfaces
{
    public interface IUsersMediators
    {
        Task<User> Create(string username, string password, CancellationToken ctk);
        Task<User> Authenticate(ConnexionVM connexionInfo, CancellationToken ctk);
    }
}
