using System.Threading;
using System.Threading.Tasks;
namespace Repositories.Base
{
   public interface IRepositoryEdit<T>
   {
      T Edit(T model);
      Task<T> EditAsync(T model, CancellationToken cancellationToken = default);
   }
}
