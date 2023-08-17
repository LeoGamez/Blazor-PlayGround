using AutoFixture;
using Playground.Wasm.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.Wasm.Infrastructure.Repositories
{
    public class MockEntityRepository : IMockEntityRepository
    {
        //Used to create mocked data
        private readonly Fixture fixture;

        public MockEntityRepository()
        {
            this.fixture = new();
        }

        public async Task<IEnumerable<MockEntity>> ReadAll()
        {
            return this.fixture.CreateMany<MockEntity>(10);
        }
    }
}
