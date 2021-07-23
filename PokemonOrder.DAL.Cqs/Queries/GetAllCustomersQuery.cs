using MediatR;
using PokemonOrder.Dto;
using System.Collections.Generic;

namespace PokemonOrder.DAL.Cqs.Queries
{
    public class GetAllCustomersQuery : IRequest<IEnumerable<CustomerDto>>
    {

    }
}