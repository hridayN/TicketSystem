using System.Collections.Generic;

namespace TicketSystem.API.Models
{
    public class LoginResponse
    {
        public List<TicketsInfo> TicketSystemInfo { get; set; }
        public LoginResponse()
        {
            TicketSystemInfo = new List<TicketsInfo>();
        }
    }
}
