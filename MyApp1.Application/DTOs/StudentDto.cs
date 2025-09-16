using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp1.Application.DTOs

  {
    public record StudentDto(Guid Id, string Name, int Age, DateTime CreatedAt);
  }


