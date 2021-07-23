using MediatR;
using PokemonOrder.Dto;

namespace PokemonOrder.DAL.Cqs.Queries
{
    public class GetCustomerByEmailQuery : IRequest<CustomerDto>
    {
        public string Email { get; set; }

        public GetCustomerByEmailQuery(string email)
        {
            Email = email;
        }
    }
}