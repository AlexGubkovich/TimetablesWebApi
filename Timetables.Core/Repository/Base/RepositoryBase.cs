using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Timetables.Core.IRepository.Base;
using Timetables.Data;

namespace Timetables.Core.Repository.Base
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected TimetableDbContext Context { get; set; }
        public RepositoryBase(TimetableDbContext context)
        {
            Context = context;
        }

        public IQueryable<T> FindAll() => Context.Set<T>().AsNoTracking();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) =>
            Context.Set<T>().Where(expression).AsNoTracking();

        public async Task Create(T entity) => await Context.Set<T>().AddAsync(entity);

        public void Update(T entity) => Context.Set<T>().Update(entity);

        public void Delete(T entity) => Context.Set<T>().Remove(entity);
    }
}
