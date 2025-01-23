using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectName.Application.Features.ToDo.Create;
using ProjectName.Application.Features.ToDo.Delete;
using ProjectName.Application.Features.ToDo.Get;
using ProjectName.Application.Features.ToDo.GetAll;
using ProjectName.Application.Features.ToDo.Update;
namespace ProjectName.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoTasksController(ISender sender) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var results = await sender.Send(new GetAllToDoTaskQuery());
            bool isSuccess = results.IsSuccess;
            if (isSuccess)
                return results.Data.Any() ? Ok(results) : NotFound(results);
            else
                return BadRequest();
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await sender.Send(new GetToDoTaskQuery(id));
            bool isSuccess = result.IsSuccess;
            return isSuccess ? Ok(result) : NotFound(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateToDoTask dto)
        {
            var result = await sender.Send(new   CreateToDoTaskCommand(dto));
            bool isSuccess = result.IsSuccess;
            return isSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPut()]
        public async Task<IActionResult> Update(UpdateToDoTask dto)
        {
            var result = await sender.Send(new UpdateToDoTaskCommand(dto));
            bool isSuccess = result.IsSuccess;
            return isSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await sender.Send(new DeleteToDoTaskCommand(new DeleteToDoTask(id)));
            bool isSuccess = result.IsSuccess;
            return isSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
