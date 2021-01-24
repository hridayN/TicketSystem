using System;
using System.Collections.Generic;
using System.Linq;
using TicketSystem.API.DBConnector;
using TicketSystem.API.Entities;
using TicketSystem.API.Infrastructure.Entities;
using TicketSystem.API.Models;
using TicketSystem.API.Services.Interfaces;
using static TicketSystem.API.Models.Enum;

namespace TicketSystem.API.Services.Services
{
    public class LoginService : ILoginService
    {
        private readonly IDataRepository<UserEntity> _userRepository;
        private readonly IDataRepository<AgentEntity> _agentRepository;
        private readonly TicketSystemDbContext _dbContext;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="userRepository"></param>
        /// <param name="agentRepository"></param>
        /// <param name="dbContext"></param>
        public LoginService(IDataRepository<UserEntity> userRepository,
            IDataRepository<AgentEntity> agentRepository,
            TicketSystemDbContext dbContext)
        {
            _userRepository = userRepository;
            _agentRepository = agentRepository;
            _dbContext = dbContext;
        }

        /// <summary>
        /// login a user
        /// </summary>
        /// <param name="loginRequest"></param>
        /// <returns></returns>
        public LoginResponse LoginUser(LoginRequest loginRequest)
        {
            LoginResponse loginResponse = new LoginResponse();
            if (loginRequest?.User != null)
            {
                switch (loginRequest.User.UserType)
                {
                    case "Admin": loginResponse = GetAllAgents(); break;
                    default: loginResponse = AssignAgent(loginRequest.User.Email); break;
                }
            }

            return loginResponse;
        }

        /// <summary>
        /// fetches all the agents
        /// </summary>
        /// <returns></returns>
        public LoginResponse GetAllAgents()
        {
            LoginResponse loginResponse = new LoginResponse();
            var dbResponse = _userRepository.GetAllConditional(x => x.IsAssigned == true);
            if (dbResponse != null)
            {
                List<TicketsInfo> ticketsInfo = new List<TicketsInfo>();
                foreach (var record in dbResponse)
                {
                    TicketsInfo ticket = new TicketsInfo();
                    User user = new User()
                    {
                        Email = record.Email,
                        Id = record.Id,
                        UserType = record.UserType,
                        AgentName = record.AgentName
                    };

                    ticket.Users.Add(user);
                    ticket.AgentId = record.AgentId;
                    ticketsInfo.Add(ticket);
                }
                loginResponse.TicketSystemInfo = ticketsInfo;
            }
            return loginResponse;
        }

        public LoginResponse AssignAgent(string email)
        {
            LoginResponse loginResponse = GetAllAgents();
            bool isAssigned = false;
            if (loginResponse?.TicketSystemInfo?.Any() ?? false)
            {
                // case 1: if agent exists
                var agentIds = loginResponse.TicketSystemInfo.Select(t => t.AgentId).Distinct().ToList();
                if (agentIds != null && agentIds.Any())
                {
                    foreach (var agentId in agentIds)
                    {
                        // agent with less than 4 customers assigned
                        if (loginResponse.TicketSystemInfo.Find(x => x.AgentId == agentId).Users.Count() < 4 && !isAssigned)
                        {
                            var requiredAgent = loginResponse.TicketSystemInfo.Find(x => x.AgentId == agentId);
                            // assign this agent to this customer
                            UserEntity entity = SetAgentAssigned(email, requiredAgent.AgentId);
                            loginResponse = new LoginResponse();
                            loginResponse.TicketSystemInfo.Add(new TicketsInfo()
                            {
                                AgentId = entity.AgentId,
                                Users = new List<User>()
                                {
                                    new User()
                                    {
                                        AgentName = entity.AgentName,
                                        UserType = entity.UserType,
                                        Email = entity.Email
                                    }
                                }
                            });
                            isAssigned = true;
                            return loginResponse;
                        }
                    }

                    // no agent has less than 4 customers assigned
                    if (!isAssigned)
                    {
                        loginResponse = CreateAndAssignNewAgent(email);
                        return loginResponse;
                    }
                }
            }
            else
            {
                loginResponse = CreateAndAssignNewAgent(email);
                return loginResponse;
            }

            return loginResponse;
        }

        /// <summary>
        /// Creates new agent in DB
        /// </summary>
        /// <param name="email">email of customer</param>
        /// <returns></returns>
        private Agent CreateAgent()
        {
            AgentEntity newAgent = _agentRepository.Add(new AgentEntity()
            {
                AgentId = Guid.NewGuid(),
                AgentName = "Agent " + Guid.NewGuid()
            });
            Agent agent = new Agent()
            {
                Id = newAgent.AgentId
            };
            return agent;
        }

        /// <summary>
        /// Set agent as assigned to current customer
        /// </summary>
        /// <param name="email">email of customer</param>
        /// <returns></returns>
        private UserEntity SetAgentAssigned(string email, Guid agentId)
        {
            // save customer into db
            UserEntity userEntity = new UserEntity()
            {
                Email = email,
                Id = Guid.NewGuid(),
                AgentId = agentId,
                UserType = "Customer",
                IsAssigned = true,
                AgentName = "Agent " + Guid.NewGuid()
            };

            userEntity = _userRepository.Add(userEntity);
            return userEntity;
        }

        private LoginResponse CreateAndAssignNewAgent(string email)
        {
            Agent agent = CreateAgent();
            UserEntity userEntity = SetAgentAssigned(email, agent.Id);
            LoginResponse loginResponse = new LoginResponse();
            loginResponse.TicketSystemInfo.Add(new TicketsInfo()
            {
                AgentId = agent.Id,
                Users = new List<User>()
                {
                    new User()
                    {
                        AgentName = userEntity.AgentName,
                        UserType = userEntity.UserType,
                        Email = userEntity.Email
                    }
                }
            });
            return loginResponse;
        }

        /*private List<TicketsInfo> ArrangeData(List<TicketsInfo> ticketsInfos)
        {
            List<TicketsInfo> SortedList = new List<TicketsInfo>();
            if (ticketsInfos.Any())
            {
                var distinctAgentIds = ticketsInfos.Select(x => x.AgentId).Distinct().ToList();
                foreach(var agentId in distinctAgentIds)
                {
                    foreach(var info in ticketsInfos)
                    {
                        if ()
                    }
                }
            }
            return SortedList;
        }*/
    }
}
