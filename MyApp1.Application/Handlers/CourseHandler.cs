using MediatR;
using MyApp1.Application.Commands;
using MyApp1.Application.DTOs;
using MyApp1.Application.Queries;
using MyApp1.Application.Wrappers;
using MyApp1.Domain.Entities;
using MyApp1.Domain.Interfaces;

namespace MyApp1.Application.Handlers
{
    // CREATE
    public class CreateCourseHandler : IRequestHandler<CreateCourseCommand, ResultWrapper<Guid>>
    {
        private readonly IGenericRepository<Course> _repo;
        public CreateCourseHandler(IGenericRepository<Course> repo) => _repo = repo;

        public async Task<ResultWrapper<Guid>> Handle(CreateCourseCommand request, CancellationToken ct)
        {
            if (string.IsNullOrWhiteSpace(request.Title))
                return new ResultWrapper<Guid> { Success = false, Message = "Title required" };

            var course = new Course { Title = request.Title, Credits = request.Credits };
            await _repo.AddAsync(course);

            return new ResultWrapper<Guid> { Success = true, Message = "Course created", Data = course.Id };
        }
    }

    // READ ALL
    public class GetAllCoursesHandler : IRequestHandler<GetAllCoursesQuery, ResultWrapper<IEnumerable<CourseDto>>>
    {
        private readonly IGenericRepository<Course> _repo;
        public GetAllCoursesHandler(IGenericRepository<Course> repo) => _repo = repo;

        public async Task<ResultWrapper<IEnumerable<CourseDto>>> Handle(GetAllCoursesQuery request, CancellationToken ct)
        {
            var list = await _repo.GetAllAsync();
            var dtos = list.Select(c => new CourseDto(c.Id, c.Title, c.Credits));
            return new ResultWrapper<IEnumerable<CourseDto>> { Success = true, Message = "Courses retrieved", Data = dtos };
        }
    }

    // READ BY ID
    public class GetCourseByIdHandler : IRequestHandler<GetCourseByIdQuery, ResultWrapper<CourseDto?>>
    {
        private readonly IGenericRepository<Course> _repo;
        public GetCourseByIdHandler(IGenericRepository<Course> repo) => _repo = repo;

        public async Task<ResultWrapper<CourseDto?>> Handle(GetCourseByIdQuery request, CancellationToken ct)
        {
            var c = await _repo.GetByIdAsync(request.Id);
            if (c == null) return new ResultWrapper<CourseDto?> { Success = false, Message = "Not found" };
            var dto = new CourseDto(c.Id, c.Title, c.Credits);
            return new ResultWrapper<CourseDto?> { Success = true, Message = "Course found", Data = dto };
        }
    }

    // UPDATE
    public class UpdateCourseHandler : IRequestHandler<UpdateCourseCommand, ResultWrapper<bool>>
    {
        private readonly IGenericRepository<Course> _repo;
        public UpdateCourseHandler(IGenericRepository<Course> repo) => _repo = repo;

        public async Task<ResultWrapper<bool>> Handle(UpdateCourseCommand request, CancellationToken ct)
        {
            var c = await _repo.GetByIdAsync(request.Id);
            if (c == null) return new ResultWrapper<bool> { Success = false, Message = "Not found", Data = false };

            c.Title = request.Title;
            c.Credits = request.Credits;
            await _repo.UpdateAsync(c);

            return new ResultWrapper<bool> { Success = true, Message = "Course updated", Data = true };
        }
    }

    // DELETE
    public class DeleteCourseHandler : IRequestHandler<DeleteCourseCommand, ResultWrapper<bool>>
    {
        private readonly IGenericRepository<Course> _repo;
        public DeleteCourseHandler(IGenericRepository<Course> repo) => _repo = repo;

        public async Task<ResultWrapper<bool>> Handle(DeleteCourseCommand request, CancellationToken ct)
        {
            var c = await _repo.GetByIdAsync(request.Id);
            if (c == null) return new ResultWrapper<bool> { Success = false, Message = "Not found", Data = false };

            await _repo.DeleteAsync(request.Id);
            return new ResultWrapper<bool> { Success = true, Message = "Course deleted", Data = true };
        }
    }
}
