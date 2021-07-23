using MediatR;
using PokemonOrder.DAL.Cqs.Commands;
using PokemonOrder.DAL.Cqs.Queries;
using PokemonOrder.DAL.Entities;
using PokemonOrder.Dto;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Threading.Tasks;

namespace PokemonOrder.Services
{
    public class CustomerService : ICustomerService
    {
        private const int FIRST_ORDER = 1;
        private readonly IMediator _mediator;

        public CustomerService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IEnumerable<CustomerDto>> GetAllCustomers()
        {
            var response = await _mediator.Send(new GetAllCustomersQuery());

            return response;
        }

        public async Task PlaceOrder(string email, string name, string phoneNumber)
        {
            var customer = await GetCustomer(email);

            if (customer == null)
            {
                await AddNewCustomer(new CustomerDto()
                {
                    Mail = email,
                    Name = name,
                    PhoneNumber = phoneNumber
                });
            }
            else
            {
                await EditCustomer(customer);
            }
        }

        private async Task<CustomerDto> GetCustomer(string email)
        {
            var response = await _mediator.Send(new GetCustomerByEmailQuery(email));

            return response;
        }

        private async Task AddNewCustomer(CustomerDto customer)
        {
            await _mediator.Send(new AddCustomerCommand(new CustomerEntity()
            {
                Id = Guid.NewGuid(),
                Mail = customer.Mail,
                Name = customer.Name,
                NumberOfOrders = FIRST_ORDER,
                PhoneNumber = customer.PhoneNumber
            }));

            SendEmail(customer.Mail);
        }

        private async Task EditCustomer(CustomerDto customer)
        {
            var newNumberOfOrders = ++customer.NumberOfOrders;

            await _mediator.Send(new EditCustomerCommand(new CustomerEntity()
            {
                Id = customer.Id,
                Mail = customer.Mail,
                Name = customer.Name,
                NumberOfOrders = newNumberOfOrders,
                PhoneNumber = customer.PhoneNumber
            }));

            SendEmail(customer.Mail);
        }

        public void SendEmail(string email)
        {
            try
            {
                var smtpClient = new SmtpClient("smtp.gmail.com", 587);

                smtpClient.Credentials = new System.Net.NetworkCredential("dersalaga@gmail.com", "VoNn0IHD");
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.EnableSsl = true;

                var mail = new MailMessage();
                mail.From = new MailAddress("dersalaga@gmail.com", "PokemonDealer");
                mail.To.Add(new MailAddress(email));
                mail.CC.Add(new MailAddress("MyEmailID@gmail.com"));

                smtpClient.Send(mail);
            }
            catch 
            {
                return;
            }
        }
    }
}
