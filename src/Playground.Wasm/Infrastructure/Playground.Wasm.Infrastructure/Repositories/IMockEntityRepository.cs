using Playground.Wasm.Domain.Entities;

namespace Playground.Wasm.Infrastructure.Repositories
{
    public interface IMockEntityRepository
    {
        Task<IEnumerable<MockEntity>> ReadAll();
    }
}