using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp1.Domain.Entities
{
  public class Teacher
  {
    public Guid Id { get; set; } = Guid.NewGuid();
    public string FullName { get; set; } = null!;
    public string Subject { get; set; } = null!;
  }
}
