using NHibernate;
using System;
using System.Collections;
namespace Repositories.Base
{
   public interface IRepositoryBase<T> : 
      IRepositoryAdd<T>, 
      IRepositoryFind<T>,
      IRepositoryEdit<T>,
      IRepositoryList<T>,
      IRepositoryDelete<T>,
      IRepositoryPaged<T>,
      IDisposable where T : class, new()
   {  
      ISession Session();
      IList SqlQuery(string sql);
      IQuery Query(string sql);
   }
}
