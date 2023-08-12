using FluentNHibernate.Mapping;
using Models;
namespace Mappings
{
   public class PeopleMapping : ClassMap<People>
   {
      public PeopleMapping()
      {
         Table("peoples");
         Id(x => x.Id).Column("id").GeneratedBy.Identity();
         Map(x => x.Name).Column("name").Length(100).Not.Nullable();
         Map(x => x.CreatedAt).Column("created_at").Not.Nullable();
      }
   }
}
