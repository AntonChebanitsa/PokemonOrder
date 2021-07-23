using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokemonOrder.Api.Models;
using PokemonOrder.Services;

namespace PokemonOrder.Api.Controllers
{
    public class OrderController : Controller
    {
        private readonly ICustomerService _customerService;

        public OrderController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<IActionResult> Index()
        {
            var customers = await _customerService.GetAllCustomers();
            
            return View(customers);
        }

        public IActionResult Form()
        {
            return View();
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Order(CustomerModel model)
        {
            if (ModelState.IsValid)
            {
                await _customerService.PlaceOrder(model.Mail, model.Name, model.PhoneNumber);

                return RedirectToAction("Index", "Order");
            }

            return BadRequest();
        }
    }
}

