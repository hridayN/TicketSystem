using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketSystem.API.Infrastructure.Entities
{
    /// <summary>
    /// User entity, Table("tablename")
    /// </summary>
    [Table("user", Schema = TableSchema.TicketSystem)]
    public class UserEntity : Entity
    {
        /// <summary>
        /// User id
        /// </summary>
        [Key]
        [Column("user_id")]
        public Guid Id { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("user_type")]
        public string UserType { get; set; }

        [Column("agent_id")]
        public Guid AgentId { get; set; }

        [Column("is_assigned")]
        public bool IsAssigned { get; set; }

        [Column("agent_name")]
        public string AgentName { get; set; }
    }
}
