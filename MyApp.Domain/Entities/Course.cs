using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp1.Domain.Entities
{
  public class Course
  {
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; } = null!;
    public int Credits { get; set; }
  }
}
