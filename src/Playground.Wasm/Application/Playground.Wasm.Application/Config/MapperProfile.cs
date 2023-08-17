using AutoMapper;
using Playground.Wasm.Domain.Entities;
using Playground.Wasm.Shared.Models.MockEntities;

namespace Playground.Wasm.Application.Config
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<MockEntity, MockEntityDto>().ReverseMap();
        }
    }
}
