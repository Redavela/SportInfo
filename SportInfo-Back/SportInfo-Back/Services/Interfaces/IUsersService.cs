using Microsoft.AspNetCore.Mvc;
using SportInfo_Back.Models;
using SportInfo_Back.ViewModels;

namespace SportInfo_Back.Services.Interfaces
{
    public interface IUsersService
    {
        Task<User> Create(string username, string password, CancellationToken ctk);
        Task<User> Authenticate(string username, string password, CancellationToken ctk);
    }
}
