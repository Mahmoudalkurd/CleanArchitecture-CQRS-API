using MediatR;
using MyApp1.Application.Wrappers;

namespace MyApp1.Application.Commands
{
    public class CreateCourseCommand : IRequest<ResultWrapper<Guid>>
    {
        public string Title { get; set; } = string.Empty;
        public int Credits { get; set; }
    }
}
