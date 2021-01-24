using Microsoft.AspNetCore.Mvc;
using TicketSystem.API.Models;
using TicketSystem.API.Services.Interfaces;

namespace TicketSystem.API.Controllers
{
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult LoginUser(LoginRequest loginRequest)
        {
            return Ok(_loginService.LoginUser(loginRequest));
        }
    }
}
