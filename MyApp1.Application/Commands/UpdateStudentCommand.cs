using MediatR;
using MyApp1.Application.Wrappers;


namespace MyApp1.Application.Commands
{
    public class UpdateStudentCommand : IRequest<ResultWrapper<bool>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public int Age { get; set; }
    }
}
