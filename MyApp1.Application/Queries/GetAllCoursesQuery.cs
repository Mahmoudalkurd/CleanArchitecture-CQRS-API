using MediatR;
using MyApp1.Application.DTOs;
using MyApp1.Application.Wrappers;

namespace MyApp1.Application.Queries
{


    public class GetCourseByIdQuery : IRequest<ResultWrapper<CourseDto?>>
    {
        public Guid Id { get; set; }
    }
}
