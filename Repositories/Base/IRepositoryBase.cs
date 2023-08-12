using NHibernate;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Repositories.Base
{
   public interface IRepositoryBase<T> : IDisposable where T : class, new()
   {
      T Add(T model);
      Task<T> AddAsync(T model, CancellationToken cancellationToken = default);
      T Edit(T model);
      Task<T> EditAsync(T model, CancellationToken cancellationToken = default);
      T Find(object id);
      Task<T> FindAsync(object id, CancellationToken cancellationToken = default);
      T Find(object id, LockMode lockMode);
      Task<T> FindAsync(object id, LockMode lockMode, CancellationToken cancellationToken = default);
      IList<T> ToList();
      Task<IList<T>> ToListAsync(CancellationToken cancellationToken = default);
      ISession Session();
      ISessionFactory SessionFactory();
      IList SqlQuery(string sql);
      IQuery Query(string sql);
      bool Delete(T model);
      Task<bool> DeleteAsync(T model, CancellationToken cancellationToken = default);
   }
}
