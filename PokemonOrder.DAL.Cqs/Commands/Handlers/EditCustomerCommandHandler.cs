using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PokemonOrder.DAL.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace PokemonOrder.DAL.Cqs.Commands.Handlers
{
    public class EditCustomerCommandHandler : IRequestHandler<EditCustomerCommand, int>
    {
        private readonly PokemonOrderContext _context;
        private readonly IMapper _mapper;

        public EditCustomerCommandHandler(PokemonOrderContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> Handle(EditCustomerCommand request, CancellationToken cancellationToken)
        {
            var dto = await _context.Customers
                .FirstOrDefaultAsync(n => n.Id.Equals(request.Customer.Id), cancellationToken);

            dto.Mail = request.Customer.Mail;
            dto.PhoneNumber = request.Customer.PhoneNumber;
            dto.Id = request.Customer.Id;
            dto.Name = request.Customer.Name;
            dto.NumberOfOrders = request.Customer.NumberOfOrders;

            _context.Customers.Update(_mapper.Map<CustomerEntity>(dto));

            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}