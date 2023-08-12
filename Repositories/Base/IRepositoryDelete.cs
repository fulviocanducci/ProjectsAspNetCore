using System.Threading;
using System.Threading.Tasks;
namespace Repositories.Base
{
   public interface IRepositoryDelete<T>
   {
      bool Delete(T model);
      Task<bool> DeleteAsync(T model, CancellationToken cancellationToken = default);
   }
}
