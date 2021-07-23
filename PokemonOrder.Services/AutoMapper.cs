using AutoMapper;
using PokemonOrder.DAL.Entities;
using PokemonOrder.Dto;

namespace PokemonOrder.Services
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<CustomerDto, CustomerEntity>().ReverseMap();
        }
    }
}