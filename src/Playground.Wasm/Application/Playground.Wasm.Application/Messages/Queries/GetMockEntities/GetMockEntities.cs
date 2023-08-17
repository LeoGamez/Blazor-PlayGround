using MediatR;
using Playground.Wasm.Domain.Entities;
using Playground.Wasm.Shared.Models.MockEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.Wasm.Application.Messages.Queries.GetMockEntities
{
    public class GetMockEntities : IRequest<IEnumerable<MockEntityDto>>
    {
    }
}
