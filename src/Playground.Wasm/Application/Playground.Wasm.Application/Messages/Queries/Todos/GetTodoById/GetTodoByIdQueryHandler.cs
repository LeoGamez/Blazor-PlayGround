using MediatR;
using Playground.Wasm.Domain.Entities;
using Playground.Wasm.Infrastructure.Repositories;

namespace Playground.Wasm.Application.Messages.Queries.Todos.GetTodoById
{
    public class GetTodoByIdQueryHandler : IRequestHandler<GetTodoByIdQuery, Todo>
    {
        private readonly ITodoRepository _todoRepository;

        public GetTodoByIdQueryHandler(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task<Todo> Handle(GetTodoByIdQuery request, CancellationToken cancellationToken)
        {
            return await _todoRepository.GetById(request.Id);
        }
    }
}
