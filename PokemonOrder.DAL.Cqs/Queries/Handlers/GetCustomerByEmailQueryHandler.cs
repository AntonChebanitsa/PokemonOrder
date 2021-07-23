using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PokemonOrder.Dto;
using System.Threading;
using System.Threading.Tasks;

namespace PokemonOrder.DAL.Cqs.Queries.Handlers
{
    public class GetCustomerByEmailQueryHandler : IRequestHandler<GetCustomerByEmailQuery, CustomerDto>
    {
        private readonly PokemonOrderContext _context;
        private readonly IMapper _mapper;

        public GetCustomerByEmailQueryHandler(PokemonOrderContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CustomerDto> Handle(GetCustomerByEmailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Customers
                .FirstOrDefaultAsync(customer => customer.Mail.Equals(request.Email), cancellationToken);
            var result = _mapper.Map<CustomerDto>(entity);

            return result;
        }
    }
}