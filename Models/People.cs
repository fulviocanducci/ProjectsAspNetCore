using System;
namespace Models
{
   public class People
   {
      public long Id { get; set; }
      public string Name { get; set; } = null!;
      public DateTime CreatedAt { get; set; }
   }
}
