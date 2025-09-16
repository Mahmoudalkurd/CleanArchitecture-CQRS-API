using MediatR;
using MyApp1.Application.Wrappers;

namespace MyApp1.Application.Commands
{
    public class CreateStudentCommand : IRequest<ResultWrapper<Guid>>
    {
        public string Name { get; set; } = null!;
        public int Age { get; set; }
    }
}
