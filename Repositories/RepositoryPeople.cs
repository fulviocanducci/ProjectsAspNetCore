using NHibernate;

namespace Repositories
{

   public class RepositoryPeople : RepositoryPeopleImplemetation
   {
      public RepositoryPeople(ISessionFactory sessionFactory) : base(sessionFactory)
      {
      }
   }
}
