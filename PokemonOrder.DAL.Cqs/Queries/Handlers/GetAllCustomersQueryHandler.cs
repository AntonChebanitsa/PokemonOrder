using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PokemonOrder.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PokemonOrder.DAL.Cqs.Queries.Handlers
{
    public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, IEnumerable<CustomerDto>>
    {
        private readonly PokemonOrderContext _context;
        private readonly IMapper _mapper;

        public GetAllCustomersQueryHandler(PokemonOrderContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CustomerDto>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Customers.Select(customer => _mapper.Map<CustomerDto>(customer))
                .ToListAsync(cancellationToken);
            return result;
        }
    }
}