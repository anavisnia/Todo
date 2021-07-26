using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Todo.Data;
using Todo.Dtos;
using Todo.Entities;

namespace Todo.Commands
{
    public class CreateNewTodo : IRequest<TodoDto>
    {
        public TodoDto Todo { get; set; }
        public class CreateNewTodoComandHandler : IRequestHandler<CreateNewTodo, TodoDto>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public CreateNewTodoComandHandler(DataContext context, IMapper mapper)
            {
                _context = context ?? throw new ArgumentNullException(nameof(context));
                _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }

            public async Task<TodoDto> Handle(CreateNewTodo command, CancellationToken cancellationToken)
            {
                var todo = _mapper.Map<TodoItem>(command.Todo);

                _context.Todos.Add(todo);

                await _context.SaveChangesAsync();

                var returnTodo = _mapper.Map<TodoDto>(todo);

                return returnTodo;
            }

        }
    }
}
