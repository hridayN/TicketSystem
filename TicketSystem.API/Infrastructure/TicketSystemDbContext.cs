using Microsoft.EntityFrameworkCore;
using System;
using TicketSystem.API.Entities;
using TicketSystem.API.Infrastructure.Entities;

namespace TicketSystem.API.DBConnector
{
    public class TicketSystemDbContext : DbContext
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public TicketSystemDbContext() : base()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public TicketSystemDbContext(DbContextOptions<TicketSystemDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// Agent table
        /// </summary>
        public DbSet<AgentEntity> Agent { get; set; }

        /// <summary>
        /// User table
        /// </summary>
        public DbSet<UserEntity> User { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AgentEntity>().HasData(
                new AgentEntity {
                    AgentId = Guid.NewGuid(),
                    AgentName = "Agent " + Guid.NewGuid()
                },
                new AgentEntity
                {
                    AgentId = Guid.NewGuid(),
                    AgentName = "Agent " + Guid.NewGuid()
                });
            modelBuilder.Entity<UserEntity>().HasData(
                new UserEntity {
                    Id = Guid.NewGuid(),
                    AgentId = Guid.NewGuid(),
                    Email = "a@gmail.com",
                    IsAssigned = true,
                    UserType = "Customer",
                    AgentName = "Agent " + Guid.NewGuid()
                },
                new UserEntity
                {
                    Id = Guid.NewGuid(),
                    AgentId = Guid.NewGuid(),
                    Email = "b@gmail.com",
                    IsAssigned = true,
                    UserType = "Customer",
                    AgentName = "Agent " + Guid.NewGuid()
                },
                new UserEntity
                {
                    Id = Guid.NewGuid(),
                    AgentId = Guid.NewGuid(),
                    Email = "c@gmail.com",
                    IsAssigned = false,
                    UserType = "Customer",
                    AgentName = "Agent " + Guid.NewGuid()
                });
        }
    }
}
