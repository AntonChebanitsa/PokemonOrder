using Microsoft.AspNetCore.Mvc;
using PokemonOrder.Models;
using PokemonOrder.Services;
using System.Threading.Tasks;

namespace PokemonOrder.Controllers
{
    public class OrderController : Controller
    {
        private readonly ICustomerService _customerService;

        public OrderController(ICustomerService customerService)
        {
            _customerService = customerService;
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

                return RedirectToAction("Index", "Home");
            }

            return BadRequest();
        }
    }
}

