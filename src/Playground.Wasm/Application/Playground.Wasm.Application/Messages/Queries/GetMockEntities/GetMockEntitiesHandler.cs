using System.Threading;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Playground.Wasm.Domain.Entities;
using Playground.Wasm.Infrastructure.Repositories;
using Playground.Wasm.Shared.Models.MockEntities;
using AutoMapper;

namespace Playground.Wasm.Application.Messages.Queries.GetMockEntities
{
    public class GetMockEntitiesHandler : IRequestHandler<GetMockEntities, IEnumerable<MockEntityDto>>
    {
        private readonly IMockEntityRepository repository;
        private readonly IMapper mapper;

        public GetMockEntitiesHandler(IMockEntityRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<MockEntityDto>> Handle(GetMockEntities request, CancellationToken cancellationToken)
        {
            return this.mapper.Map<IEnumerable<MockEntityDto>>(await this.repository.ReadAll());
        }
    }
}
