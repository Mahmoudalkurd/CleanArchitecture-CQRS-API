using MediatR;
using MyApp1.Application.Wrappers;
using MyApp1.Application.DTOs;

namespace MyApp1.Application.Queries
{
    public class GetAllStudentsQuery : IRequest<ResultWrapper<IEnumerable<StudentDto>>> { }
}
