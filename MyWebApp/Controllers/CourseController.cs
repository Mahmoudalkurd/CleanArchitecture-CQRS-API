using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyApp1.Application.Commands;
using MyApp1.Application.Queries;

namespace MyApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CoursesController(IMediator mediator) => _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> Create(CreateCourseCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(new { success = true, message = "Course created", data = id });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var courses = await _mediator.Send(new GetAllCoursesQuery());
            return Ok(new { success = true, data = courses });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var course = await _mediator.Send(new GetCourseByIdQuery { Id = id });
            return Ok(new { success = true, data = course });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateCourseCommand command)
        {
            command.Id = id;
            await _mediator.Send(command);
            return Ok(new { success = true, message = "Course updated" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteCourseCommand { Id = id });
            return Ok(new { success = true, message = "Course deleted" });
        }
    }
}
