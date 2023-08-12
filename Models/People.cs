using System;
namespace Models
{
   public class People
   {
      public virtual long Id { get; set; }
      public virtual string Name { get; set; } = null!;
      public virtual DateTime CreatedAt { get; set; }
   }
}
