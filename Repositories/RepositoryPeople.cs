using NHibernate;

namespace Repositories
{

   public class RepositoryPeople : RepositoryPeopleImplemetation
   {
      public RepositoryPeople(ISession session) : base(session)
      {
      }
   }
}
