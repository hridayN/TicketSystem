using TicketSystem.API.Models;

namespace TicketSystem.API.Services.Interfaces
{
    public interface ILoginService
    {
        /// <summary>
        /// login a user
        /// </summary>
        /// <param name="loginRequest"></param>
        /// <returns></returns>
        LoginResponse LoginUser(LoginRequest loginRequest);

        /// <summary>
        /// fetches all the agents
        /// </summary>
        /// <returns></returns>
        LoginResponse GetAllAgents();

        /// <summary>
        /// assign an agent to customer
        /// </summary>
        /// <returns></returns>
        LoginResponse AssignAgent(string email);
    }
}
