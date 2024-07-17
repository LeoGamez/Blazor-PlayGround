using MediatR;
using Playground.Wasm.Domain.Entities;
using Playground.Wasm.Infrastructure.Repositories;

namespace Playground.Wasm.Application.Messages.Queries.Todos.GetTodos;

public class GetTodosQueryHandler : IRequestHandler<GetTodosQuery, IEnumerable<Todo>>
{
    private readonly ITodoRepository _todoRepository;
    public GetTodosQueryHandler(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public async Task<IEnumerable<Todo>> Handle(GetTodosQuery request, CancellationToken cancellationToken)
    {
        return await _todoRepository.Get();
    }
}
