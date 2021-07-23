using System;

namespace PokemonOrder.Dto
{
    public class CustomerDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string PhoneNumber { get; set; }
        public int NumberOfOrders { get; set; }
    }
}
