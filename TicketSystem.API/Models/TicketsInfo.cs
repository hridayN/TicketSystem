using System;
using System.Collections.Generic;

namespace TicketSystem.API.Models
{
    public class TicketsInfo
    {
        public TicketsInfo()
        {
            Users = new List<User>();
        }
        public List<User> Users { get; set; }

        public Guid AgentId { get; set; }
    }
}
