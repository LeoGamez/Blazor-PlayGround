using MediatR;
using Playground.Wasm.Domain.Entities;

namespace Playground.Wasm.Application.Messages.Queries.Todos.GetTodoById
{
    public class GetTodoByIdQuery : IRequest<Todo>
    {
        public int Id { get; set; }
    }
}
