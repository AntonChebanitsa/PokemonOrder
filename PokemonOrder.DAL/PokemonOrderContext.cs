using Microsoft.EntityFrameworkCore;
using PokemonOrder.DAL.Entities;

namespace PokemonOrder.DAL
{
    public class PokemonOrderContext : DbContext
    {
        public DbSet<CustomerEntity> Customers { get; set; }
        public PokemonOrderContext(DbContextOptions<PokemonOrderContext> options) : base(options)
        {

        }
    }
}