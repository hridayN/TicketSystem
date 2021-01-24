using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketSystem.API.Models;

namespace TicketSystem.API.Services.Interfaces
{
    public interface IExitService
    {
        /// <summary>
        /// Set agent as free from current customer
        /// </summary>
        /// <param name="email">email of customer</param>
        /// <returns></returns>
        ExitResponse SetAgentFree(ExitRequest exitRequest);
    }
}
