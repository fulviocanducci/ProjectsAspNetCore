using System.Threading;
using System.Threading.Tasks;
namespace Repositories.Base
{
   public interface IRepositoryAdd<T>
   {
      T Add(T model);
      Task<T> AddAsync(T model, CancellationToken cancellationToken = default);
   }
}
