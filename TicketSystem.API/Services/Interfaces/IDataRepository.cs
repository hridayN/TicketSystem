using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TicketSystem.API.Infrastructure.Entities;

namespace TicketSystem.API.Services.Interfaces
{
    public interface IDataRepository<T> where T : Entity
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAllConditional(Expression<Func<T, bool>> predicate);
        T Get(long id);
        T Add(T entity);
        void Update(T entity);
        void Delete(T entity); 
    }
}
