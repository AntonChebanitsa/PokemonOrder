using System.Collections.Generic;
using PokemonOrder.Dto;

namespace PokemonOrder.Api.Models
{
    public class CustomerListModel
    {
        public IEnumerable<CustomerDto> Customers { get; set; }
    }
}