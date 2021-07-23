using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace PokemonOrder.DAL.Cqs.Commands.Handlers
{
    public class AddCustomerCommandHandler : IRequestHandler<AddCustomerCommand, int>
    {
        private readonly PokemonOrderContext _context;

        public AddCustomerCommandHandler(PokemonOrderContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
        {
            await _context.Customers.AddAsync(request.Customer, cancellationToken);

            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}