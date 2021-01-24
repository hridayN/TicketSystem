using System;

namespace TicketSystem.API.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string UserType { get; set; }
        public string AgentName { get; set; }
    }
}
