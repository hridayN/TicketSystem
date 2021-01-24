using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketSystem.API.Infrastructure
{
    /// <summary>
    /// Constant class for Schema Names
    /// </summary>
    public class TableSchema
    {
        /// <summary>
        /// Protected constructor to achieve abstraction
        /// </summary>
        protected TableSchema()
        {
        }

        /// <summary>
        /// Schema Name for ticket system db related tables
        /// </summary>
        public const string TicketSystem = "ticket_system_db";
    }
}
