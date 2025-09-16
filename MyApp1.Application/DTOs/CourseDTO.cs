using System;

namespace MyApp1.Application.DTOs
{
    public record CourseDto(
        Guid Id,
        string Title,
        int Credits
    );
}