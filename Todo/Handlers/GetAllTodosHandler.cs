using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Todo.Data;
using Todo.Dtos;
using Todo.Quaries;

namespace Todo.Handlers
{
    public class GetAllTodosHandler : IRequestHandler<GetAllTodosQuery, IEnumerable<TodoDto>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public GetAllTodosHandler(DataContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<TodoDto>> Handle(GetAllTodosQuery request, CancellationToken cancellationToken)
        {
            var entities = await _context.Todos.ToListAsync();

            return _mapper.Map<IEnumerable<TodoDto>>(entities);
        }
    }
}
