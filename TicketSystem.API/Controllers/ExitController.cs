using Microsoft.AspNetCore.Mvc;
using TicketSystem.API.Models;
using TicketSystem.API.Services.Interfaces;

namespace TicketSystem.API.Controllers
{
    [ApiController]
    public class ExitController : ControllerBase
    {
        private readonly IExitService _exitService;

        public ExitController(IExitService exitService)
        {
            _exitService = exitService;
        }

        [HttpPost]
        [Route("exit")]
        public IActionResult ExitUser(ExitRequest exitRequest)
        {
            return Ok(_exitService.SetAgentFree(exitRequest));
        }
    }
}
