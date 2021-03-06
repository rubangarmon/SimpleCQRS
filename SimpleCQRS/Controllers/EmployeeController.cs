using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using SimpleCQRS.Features.Queries;
using SimpleCQRS.Features.Commands;

namespace SimpleCQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>(); 


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await Mediator.Send(new GetAllEmployeesQuery()));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetEmployeeByIdQuery() { Id = id }));
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateEmployeeCommand command)
        {
            //TODO: Accept DTOs then map to CreateEmployeeCommand
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateEmployeeCommand command)
        {
            if(id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
            => Ok(await Mediator.Send(new DeleteEmployeeCommand() { Id = id }));
    }
}
