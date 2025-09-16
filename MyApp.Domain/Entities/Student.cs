using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp1.Domain.Entities
{

    public class Student
    {
      public Guid Id { get; set; } = Guid.NewGuid();
      public string Name { get; set; } = null!;
      public int Age { get; set; }
      public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
  }

}

