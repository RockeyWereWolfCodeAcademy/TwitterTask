using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Twitter.Core.Entities.Common;

namespace Twitter.Business.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }
        IQueryable<T> GetAll(bool notTracked = true, params string[] includes);
		Task<T> GetByIdAsync(int id, bool noTracking = true, params string[] includes);
		Task<bool> IsExistAsync(Expression<Func<T, bool>> expression);
		Task CreateAsync(T entity);
        void Delete(T entity);
        //void SoftDelete(T entity);
        Task SaveAsync();
    }
}
