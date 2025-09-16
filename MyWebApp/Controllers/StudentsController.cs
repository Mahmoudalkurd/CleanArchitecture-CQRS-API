using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyApp1.Application.Commands;
using MyApp1.Application.Queries;

namespace MyApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public StudentsController(IMediator mediator) => _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> Create(CreateStudentCommand command)
            => Ok(await _mediator.Send(command));

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _mediator.Send(new GetAllStudentsQuery()));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
            => Ok(await _mediator.Send(new GetStudentByIdQuery { Id = id }));

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateStudentCommand command)
        {
            if (id != command.Id) return BadRequest("ID mismatch");
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
            => Ok(await _mediator.Send(new DeleteStudentCommand { Id = id }));
    }
}
