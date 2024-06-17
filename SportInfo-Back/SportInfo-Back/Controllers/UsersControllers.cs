using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SportInfo_Back.Mediators.Interfaces;
using SportInfo_Back.Services;
using SportInfo_Back.Services.Interfaces;
using SportInfo_Back.ViewModels;

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
            var user = await UsersMediator.Create(username, password, ctk);
            return Ok(user);
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(ConnexionVM connexionInfo, CancellationToken ctk = default)
        {
            var user = await UsersMediator.Authenticate(connexionInfo, ctk);
            return Ok(user);
        } 

    }
}
