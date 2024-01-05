﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Twitter.Business.Repositories.Interfaces;
using Twitter.Core.Entities.Common;
using Twitter.DAL.Contexts;

namespace Twitter.Business.Repositories.Implements
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        readonly TwitterContext _context;

        public GenericRepository(TwitterContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task CreateAsync(T entity)
        {
            await Table.AddAsync(entity);
        }

		public void Delete(T data)
		{
			Table.Remove(data);
		}

        public IQueryable<T> GetAll(bool notTracked = true)
            => notTracked ? Table.AsNoTracking() : Table;

		public async Task<T> GetByIdAsync(int id, bool noTracking = true)
		{
			return noTracking ? await Table.AsNoTracking().SingleOrDefaultAsync(t => t.Id == id) : await Table.FindAsync(id);
		}

		public async Task<bool> IsExistAsync(Expression<Func<T, bool>> expression)
		{
			return await Table.AnyAsync(expression);
		}

		public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
	}
}
