using Playground.Wasm.Domain.Entities;

namespace Playground.Wasm.Infrastructure.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        public async Task<Todo> Create(Todo todo)
        {
            //Todo: Add persistence

            return todo;
        }

        public async Task<Todo> Update(Todo todo)
        {
            //Todo: Add persistence

            return todo;
        }

        public async Task Delete(int id)
        {
            //Todo: Add persistence

        }

        public async Task<IEnumerable<Todo>> Get()
        {
            return Enumerable.Empty<Todo>();
        }

        public async Task<Todo> GetById(int id)
        {
            return new();
        }
    }
}
