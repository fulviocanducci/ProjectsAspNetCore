using Models;
using NHibernate;
using Repositories.Base;

namespace Repositories
{
   public abstract class RepositoryPeopleImplemetation : RepositoryBase<People>, IRepositoryBase<People>
   {
      public RepositoryPeopleImplemetation(ISession session, ISessionFactory sessionFactory) : base(session, sessionFactory)
      {
      }
   }

   public class RepositoryPeople : RepositoryPeopleImplemetation
   {
      public RepositoryPeople(ISession session, ISessionFactory sessionFactory) : base(session, sessionFactory)
      {
      }
   }
}
