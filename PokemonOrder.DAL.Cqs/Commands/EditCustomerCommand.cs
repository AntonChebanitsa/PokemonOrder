using MediatR;
using PokemonOrder.DAL.Entities;

namespace PokemonOrder.DAL.Cqs.Commands
{
    public class EditCustomerCommand : IRequest<int>
    {
        public CustomerEntity Customer { get; set; }

        public EditCustomerCommand(CustomerEntity customer)
        {
            Customer = customer;
        }
    }
}