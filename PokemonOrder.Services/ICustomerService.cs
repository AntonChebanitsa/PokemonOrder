using PokemonOrder.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokemonOrder.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDto>> GetAllCustomers();
        Task PlaceOrder(string email, string name, string phoneNumber);
    }
}