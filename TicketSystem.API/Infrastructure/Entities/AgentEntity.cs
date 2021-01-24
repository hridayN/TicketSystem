using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TicketSystem.API.Infrastructure;
using TicketSystem.API.Infrastructure.Entities;

namespace TicketSystem.API.Entities
{
    /// <summary>
    /// Agent entity, Table("tablename")
    /// </summary>
    [Table("agent", Schema = TableSchema.TicketSystem)]
    public class AgentEntity : Entity
    {
        /// <summary>
        /// Agent id
        /// </summary>
        [Key]
        [Column("agent_id")]
        public Guid AgentId { get; set; }

        [Column("agent_name")]
        public string AgentName { get; set; }
    }
}
