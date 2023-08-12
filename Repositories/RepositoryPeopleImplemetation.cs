using Models;
using NHibernate;
using Repositories.Base;

namespace Repositories
{
   public abstract class RepositoryPeopleImplemetation : RepositoryBase<People>, IRepositoryBase<People>
   {
      public RepositoryPeopleImplemetation(ISession session) : base(session)
      {
      }
   }
}
