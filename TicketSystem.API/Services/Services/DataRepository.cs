using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TicketSystem.API.DBConnector;
using TicketSystem.API.Infrastructure.Entities;
using TicketSystem.API.Services.Interfaces;

namespace TicketSystem.API.Services.Services
{
    public class DataRepository<T> : IDataRepository<T> where T : Entity
    {
        /// <summary>
        /// Db Context
        /// </summary>
        protected readonly TicketSystemDbContext _dbContext;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbContext"></param>
        public DataRepository(TicketSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public T Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public T Get(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();
        }

        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.Set<T>().Update(entity);
            _dbContext.SaveChanges();
        }

        public IEnumerable<T> GetAllConditional(Expression<Func<T, bool>> predicate)
        {
            return _dbContext.Set<T>().Where(predicate).ToList();
        }
    }
}
