using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketSystem.API.Infrastructure.Entities;
using TicketSystem.API.Models;
using TicketSystem.API.Services.Interfaces;

namespace TicketSystem.API.Services.Services
{
    public class ExitService : IExitService
    {
        private readonly IDataRepository<UserEntity> _userRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="userRepository"></param>
        public ExitService(IDataRepository<UserEntity> userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Set agent as free from current customer
        /// </summary>
        /// <param name="exitRequest">ExitRequest object</param>
        /// <returns></returns>
        public ExitResponse SetAgentFree(ExitRequest exitRequest)
        {
            ExitResponse exitResponse = new ExitResponse();
            var userEntity = _userRepository.GetAllConditional(x => x.Email == exitRequest.Email && x.IsAssigned == true);

            if (userEntity?.Any() ?? false)
            {
                UserEntity entity = new UserEntity()
                {
                    Email = userEntity.ToList().FirstOrDefault().Email,
                    //Id = userEntity.ToList().FirstOrDefault().Id,
                    AgentId = userEntity.ToList().FirstOrDefault().AgentId,
                    UserType = userEntity.ToList().FirstOrDefault().UserType,
                    IsAssigned = false
                };

                _userRepository.Update(entity);
                exitResponse.Email = "Success";
            }
            return exitResponse;
        }
    }
}
