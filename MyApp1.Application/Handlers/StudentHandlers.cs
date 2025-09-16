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
    public class CreateStudentHandler : IRequestHandler<CreateStudentCommand, ResultWrapper<Guid>>
    {
        private readonly IGenericRepository<Student> _repo;
        public CreateStudentHandler(IGenericRepository<Student> repo) => _repo = repo;

        public async Task<ResultWrapper<Guid>> Handle(CreateStudentCommand request, CancellationToken ct)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
                return new ResultWrapper<Guid> { Success = false, Message = "Name required" };

            var student = new Student { Name = request.Name, Age = request.Age };
            await _repo.AddAsync(student);

            return new ResultWrapper<Guid> { Success = true, Message = "Student created", Data = student.Id };
        }
    }

    // READ ALL
    public class GetAllStudentsHandler : IRequestHandler<GetAllStudentsQuery, ResultWrapper<IEnumerable<StudentDto>>>
    {
        private readonly IGenericRepository<Student> _repo;
        public GetAllStudentsHandler(IGenericRepository<Student> repo) => _repo = repo;

        public async Task<ResultWrapper<IEnumerable<StudentDto>>> Handle(GetAllStudentsQuery request, CancellationToken ct)
        {
            var list = await _repo.GetAllAsync();
            var dtos = list.Select(s => new StudentDto(s.Id, s.Name, s.Age, s.CreatedAt));
            return new ResultWrapper<IEnumerable<StudentDto>> { Success = true, Message = "Students retrieved", Data = dtos };
        }
    }

    // READ BY ID
    public class GetStudentByIdHandler : IRequestHandler<GetStudentByIdQuery, ResultWrapper<StudentDto?>>
    {
        private readonly IGenericRepository<Student> _repo;
        public GetStudentByIdHandler(IGenericRepository<Student> repo) => _repo = repo;

        public async Task<ResultWrapper<StudentDto?>> Handle(GetStudentByIdQuery request, CancellationToken ct)
        {
            var s = await _repo.GetByIdAsync(request.Id);
            if (s == null) return new ResultWrapper<StudentDto?> { Success = false, Message = "Not found" };
            var dto = new StudentDto(s.Id, s.Name, s.Age, s.CreatedAt);
            return new ResultWrapper<StudentDto?> { Success = true, Message = "Student found", Data = dto };
        }
    }

    // UPDATE
    public class UpdateStudentHandler : IRequestHandler<UpdateStudentCommand, ResultWrapper<bool>>
    {
        private readonly IGenericRepository<Student> _repo;
        public UpdateStudentHandler(IGenericRepository<Student> repo) => _repo = repo;

        public async Task<ResultWrapper<bool>> Handle(UpdateStudentCommand request, CancellationToken ct)
        {
            var s = await _repo.GetByIdAsync(request.Id);
            if (s == null) return new ResultWrapper<bool> { Success = false, Message = "Not found", Data = false };

            s.Name = request.Name;
            s.Age = request.Age;
            await _repo.UpdateAsync(s);

            return new ResultWrapper<bool> { Success = true, Message = "Student updated", Data = true };
        }
    }

    // DELETE
    public class DeleteStudentHandler : IRequestHandler<DeleteStudentCommand, ResultWrapper<bool>>
    {
        private readonly IGenericRepository<Student> _repo;
        public DeleteStudentHandler(IGenericRepository<Student> repo) => _repo = repo;

        public async Task<ResultWrapper<bool>> Handle(DeleteStudentCommand request, CancellationToken ct)
        {
            var s = await _repo.GetByIdAsync(request.Id);
            if (s == null) return new ResultWrapper<bool> { Success = false, Message = "Not found", Data = false };

            await _repo.DeleteAsync(request.Id);
            return new ResultWrapper<bool> { Success = true, Message = "Student deleted", Data = true };
        }
    }
}
