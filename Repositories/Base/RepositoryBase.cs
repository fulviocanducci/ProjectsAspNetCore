using Canducci.Pagination;
using NHibernate;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
namespace Repositories.Base
{
   public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class, new()
   {
      private readonly ISession session;

      public RepositoryBase(ISession session)
      {
         this.session = session;
      }

      public ISession Session()
      {
         return session;
      }

      #region Simply
      public T Add(T model)
      {
         ITransaction trans = session.BeginTransaction();
         session.Save(model);
         trans.Commit();
         session.Flush();
         return model;
      }

      public T Edit(T model)
      {
         ITransaction trans = session.BeginTransaction();
         session.SaveOrUpdate(model);
         trans.Commit();
         session.Flush();
         return model;
      }

      public T Find(object id)
      {
         return session.Get<T>(id);
      }

      public T Find(object id, LockMode lockMode)
      {
         return session.Get<T>(id, lockMode);
      }

      public IList<T> ToList()
      {
         return session.CreateCriteria(typeof(T)).List<T>();
      }

      public IList SqlQuery(string sql)
      {
         return session.CreateSQLQuery(sql).List();
      }

      public IQuery Query(string sql)
      {
         return session.CreateQuery(sql);
      }

      public bool Delete(T model)
      {
         try
         {
            ITransaction trans = session.BeginTransaction();
            session.Delete(model);
            trans.Commit();
            session.Flush();
            return true;
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }
      #endregion

      public async Task<T> AddAsync(T model, CancellationToken cancellationToken = default)
      {
         ITransaction trans = session.BeginTransaction();
         await session.SaveAsync(model, cancellationToken);
         await trans.CommitAsync(cancellationToken);
         await session.FlushAsync(cancellationToken);
         return model;
      }

      public async Task<T> EditAsync(T model, CancellationToken cancellationToken = default)
      {
         ITransaction trans = session.BeginTransaction();
         await session.SaveOrUpdateAsync(model, cancellationToken);
         await trans.CommitAsync(cancellationToken);
         await session.FlushAsync(cancellationToken);
         return model;
      }

      public async Task<T> FindAsync(object id, CancellationToken cancellationToken = default)
      {
         return await session.GetAsync<T>(id);
      }

      public async Task<T> FindAsync(object id, LockMode lockMode, CancellationToken cancellationToken = default)
      {
         return await session.GetAsync<T>(id, lockMode, cancellationToken);
      }

      public async Task<IList<T>> ToListAsync(CancellationToken cancellationToken = default)
      {
         return await session.CreateCriteria(typeof(T)).ListAsync<T>(cancellationToken);
      }

      public async Task<bool> DeleteAsync(T model, CancellationToken cancellationToken = default)
      {
         try
         {
            ITransaction trans = session.BeginTransaction();
            await session.DeleteAsync(model, cancellationToken);
            await trans.CommitAsync(cancellationToken);
            await session.FlushAsync(cancellationToken);
            return true;
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }

      public void Dispose()
      {
         session?.Dispose();
      }

      public Paginated<T> Page(int pageNumber, int pageSize)
      {
         return session.Query<T>().ToPaginated(pageNumber, pageSize);
      }

      public Paginated<T> Page(int pageNumber, int pageSize, Expression<Func<T, bool>> where, Expression<Func<IQueryable<T>, IQueryable<T>>>? orderBy = null)
      {
         IQueryable<T> model = session.Query<T>();
         model = model.Where(where);
         if (orderBy != null)
         {
            model = orderBy.Compile().Invoke(model);
         }
         return model.ToPaginated(pageNumber, pageSize);
      }

      public async Task<Paginated<T>> PageAsync(int pageNumber, int pageSize)
      {
         return await session.Query<T>().ToPaginatedAsync(pageNumber, pageSize);
      }

      public async Task<Paginated<T>> PageAsync(int pageNumber, int pageSize, Expression<Func<T, bool>> where, Expression<Func<IQueryable<T>, IQueryable<T>>>? orderBy = null)
      {
         IQueryable<T> model = session.Query<T>();
         model = model.Where(where);
         if (orderBy != null)
         {
            model = orderBy.Compile().Invoke(model);
         }
         return await model.ToPaginatedAsync(pageNumber, pageSize);
      }
   }
}
