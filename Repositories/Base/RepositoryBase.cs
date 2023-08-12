using NHibernate;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
namespace Repositories.Base
{
   public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class, new()
   {
      private readonly ISessionFactory sessionFactory;
      private readonly ISession session;

      public RepositoryBase(ISession session, ISessionFactory sessionFactory)
      {
         this.session = session;
         this.sessionFactory = sessionFactory;
      }

      public ISession Session()
      {
         return session;
      }

      public ISessionFactory SessionFactory()
      {
         return sessionFactory;
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

      public void Dispose()
      {
         session?.Close();
         sessionFactory?.Close();
         session?.Dispose();
         sessionFactory?.Dispose();
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
   }
}
