using System.Linq.Expressions;

namespace Timetables.Core.IRepository.Base
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        Task Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
