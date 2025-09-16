using MediatR;
using MyApp1.Application.Wrappers;

namespace MyApp1.Application.Commands
{
    public class DeleteCourseCommand : IRequest<ResultWrapper<bool>>
    {
        public Guid Id { get; set; }
    }
}
