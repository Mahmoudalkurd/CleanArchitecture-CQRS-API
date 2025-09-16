using MediatR;
using MyApp1.Application.Wrappers;

namespace MyApp1.Application.Commands
{
    public class DeleteStudentCommand : IRequest<ResultWrapper<bool>>
    {
        public Guid Id { get; set; }
    }
}
