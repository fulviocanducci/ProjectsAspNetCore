using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
namespace Repositories.Base
{
   public interface IRepositoryList<T>
   {
      IList<T> ToList();
      Task<IList<T>> ToListAsync(CancellationToken cancellationToken = default);
   }
}
