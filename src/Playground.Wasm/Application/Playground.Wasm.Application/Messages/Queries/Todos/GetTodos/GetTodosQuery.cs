using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.Wasm.Application.Messages.Queries.Todos.GetTodos
{
    public class GetTodosQuery : IRequest<IEnumerable<Todo>>
    {
    }
}
