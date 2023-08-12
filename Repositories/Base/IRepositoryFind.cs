using NHibernate;
using System.Threading;
using System.Threading.Tasks;
namespace Repositories.Base
{
   public interface IRepositoryFind<T>
   {
      T Find(object id);
      Task<T> FindAsync(object id, CancellationToken cancellationToken = default);
      T Find(object id, LockMode lockMode);
      Task<T> FindAsync(object id, LockMode lockMode, CancellationToken cancellationToken = default);
   }
}
