using Canducci.Pagination;
using NHibernate.Persister.Entity;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repositories.Base
{
   public interface IRepositoryPaged<T>
   {
      Paginated<T> Page(int pageNumber, int pageSize);
      Paginated<T> Page(int pageNumber, int pageSize, Expression<Func<T, bool>> where, Expression<Func<IQueryable<T>, IQueryable<T>>>? orderBy = null);
      Task<Paginated<T>> PageAsync(int pageNumber, int pageSize);
      Task<Paginated<T>> PageAsync(int pageNumber, int pageSize, Expression<Func<T, bool>> where, Expression<Func<IQueryable<T>, IQueryable<T>>>? orderBy = null);
   }
}
