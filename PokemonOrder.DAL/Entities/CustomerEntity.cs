using System;

namespace PokemonOrder.DAL.Entities
{
    public class CustomerEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string PhoneNumber { get; set; }
        public int NumberOfOrders { get; set; }
    }
}
