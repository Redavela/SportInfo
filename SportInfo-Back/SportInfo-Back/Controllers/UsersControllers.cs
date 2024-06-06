using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SportInfo_Back.Mediators.Interfaces;
using SportInfo_Back.Services;
using SportInfo_Back.Services.Interfaces;

namespace SportInfo_Back.Controllers
{
    [ApiController]
    [EnableCors("CorsPolicy")]
    [Route("[controller]")]
    public class UsersControllers : ControllerBase
    {
        private readonly IUsersMediators UsersMediator;
        public UsersControllers(IUsersMediators usersMediator)
        {
            UsersMediator = usersMediator;
        }
        [HttpPost]
        public async Task<IActionResult> Create(string username, string password, CancellationToken ctk = default) 
        {
            var user = UsersMediator.Create(username, password, ctk);
            return Ok(user);
        }
    }
}
