using MediatR;
using MyApp1.Application.DTOs;
using MyApp1.Application.Wrappers;
using MyApp1.Application.DTOs;
using MyApp1.Application.Wrappers;

namespace MyApp1.Application.Queries
{
    public class GetStudentByIdQuery : IRequest<ResultWrapper<StudentDto?>>
    {
        public Guid Id { get; set; }
    }
}
