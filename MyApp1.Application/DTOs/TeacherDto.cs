using System;

namespace MyApp1.Application.DTOs
{
    public record TeacherDto(
        Guid Id,
        string Name,
        string Subject
    );
}
