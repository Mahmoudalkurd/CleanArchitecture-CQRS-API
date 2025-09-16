using MediatR;
using MyApp1.Application.Wrappers;

namespace MyApp1.Application.Commands
{
    public class UpdateCourseCommand : IRequest<ResultWrapper<bool>>
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int Credits { get; set; }
    }
}
