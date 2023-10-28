using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MediatRSample.Controllers;

[ApiController]
[Route("[controller]")]
public class todoController : ControllerBase
{
    private readonly IMediator _mediator;
    public todoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async ValueTask<IActionResult> GetAll(){
        var query = new GetAllToDoCollectionQuery();
        return Ok(await _mediator.Send(query));
    }

    [HttpPost]
    public async ValueTask<IActionResult> Create([FromBody] TodoItem toDo)
    {
        var create = new CreateToDoCommand(toDo);

        var result = await _mediator.Send(create);

        if(result == null) return BadRequest();

        return Ok(result);
    }

}