using Liskov_Substitution_Principle.DataTransferObject;
using Liskov_Substitution_Principle.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Liskov_Substitution_Principle.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly CustomerService _customerService;

        public CustomersController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("{lastName}")]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomerByLastNameAsync(string lastName)
        {
            var customers = await _customerService.GetCustomersByLastNameAsync(lastName);
            if (customers == null || !customers.Any())
            {
                return NotFound();
            }
            return Ok(customers);

        }
    }
}
