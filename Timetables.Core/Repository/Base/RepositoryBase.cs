using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
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

        public IQueryable<T> FindAll(bool trackChanges) =>
            !trackChanges ?
                Context.Set<T>()
                    .AsNoTracking()
            : Context.Set<T>();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) =>
            !trackChanges ?
                Context.Set<T>().Where(expression)
                .AsNoTracking()
            : Context.Set<T>().Where(expression);

        public async Task Create(T entity) => await Context.Set<T>().AddAsync(entity);

        public void Update(T entity) => Context.Set<T>().Update(entity);

        public void Delete(T entity) => Context.Set<T>().Remove(entity);
    }
}
