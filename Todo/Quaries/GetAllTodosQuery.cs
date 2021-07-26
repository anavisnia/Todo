using MediatR;
using System.Collections.Generic;
using Todo.Dtos;

namespace Todo.Quaries
{
    public class GetAllTodosQuery : IRequest<IEnumerable<TodoDto>>
    {

    }
}
