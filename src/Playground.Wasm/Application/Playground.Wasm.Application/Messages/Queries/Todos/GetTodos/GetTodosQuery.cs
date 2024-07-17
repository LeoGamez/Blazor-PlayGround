using MediatR;
using Playground.Wasm.Domain.Entities;

namespace Playground.Wasm.Application.Messages.Queries.Todos.GetTodos;

public class GetTodosQuery : IRequest<IEnumerable<Todo>>
{
}
