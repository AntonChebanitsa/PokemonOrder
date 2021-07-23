using MediatR;
using PokemonOrder.DAL.Entities;

namespace PokemonOrder.DAL.Cqs.Commands
{
    public class AddCustomerCommand : IRequest<int>
    {
        public CustomerEntity Customer { get; set; }

        public AddCustomerCommand(CustomerEntity customer)
        {
            Customer = customer;
        }
    }
}