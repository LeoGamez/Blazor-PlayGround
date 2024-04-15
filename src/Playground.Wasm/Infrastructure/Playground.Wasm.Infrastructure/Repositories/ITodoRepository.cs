using Playground.Wasm.Domain.Entities;

namespace Playground.Wasm.Infrastructure.Repositories
{
    public interface ITodoRepository
    {
        Task<Todo> Create(Todo todo);
        Task Delete(int id);
        Task<IEnumerable<Todo>> Get();
        Task<Todo> GetById(int id);
        Task<Todo> Update(Todo todo);
    }
}