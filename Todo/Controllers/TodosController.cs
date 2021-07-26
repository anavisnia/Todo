using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Todo.Commands;
using Todo.Dtos;
using Todo.Quaries;

namespace Todo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TodosController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        public async Task<IEnumerable<TodoDto>> Get()
        {
            return await _mediator.Send(new GetAllTodosQuery());
        }

        [HttpPost]
        public async Task<TodoDto> Create(TodoDto todoDto)
        {
            return await _mediator.Send(new CreateNewTodo() { Todo = todoDto });
        }
    }
}
