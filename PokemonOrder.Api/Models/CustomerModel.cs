using System;

namespace PokemonOrder.Api.Models
{
    public class CustomerModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string PhoneNumber { get; set; }
        public int NumberOfOrders { get; set; }
    }
}