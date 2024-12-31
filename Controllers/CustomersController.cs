using CustomerManagementWebAPI.Data;
using CustomerManagementWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagementWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController: Controller
    {
        private readonly CustomersAPIDbContext dbContext;
        public CustomersController(CustomersAPIDbContext dbContext)
        {
            this.dbContext=dbContext;

        }
        [HttpGet]
        public async Task <IActionResult> GetCustomers()
        {
            return Ok(await dbContext.Customers.ToListAsync());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetCustomer([FromRoute] Guid id)
        {
            var customer = await dbContext.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPost]
        public async Task< IActionResult> AddCustomer(AddCustomerRequest addCustomerRequest)
        {
            var customer = new Customer()
            {
                id = Guid.NewGuid(),
                Address = addCustomerRequest.Address,
                Email = addCustomerRequest.Email,
                Name = addCustomerRequest.Name,
                Phone = addCustomerRequest.Phone
            };

            await dbContext.Customers.AddAsync(customer);
            await dbContext.SaveChangesAsync();

            return Ok(customer);
        }

        [HttpPut]
        [Route("{id:guid}")]

        public async Task<IActionResult> UpdateCustomer([FromRoute] Guid id,UpdateCustomerRequest updatecustomerRequest)
        {
            var customer = await dbContext.Customers.FindAsync(id);

            if (customer != null)
            {
                customer.Address = updatecustomerRequest.Address;
                customer.Email = updatecustomerRequest.Email;
                customer.Name = updatecustomerRequest.Name;
                customer.Phone = updatecustomerRequest.Phone;

                await dbContext.SaveChangesAsync();
                return Ok(customer);
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteCustomer([FromRoute]Guid id)
        {
          
            var customer = await dbContext.Customers.FindAsync(id);
            
            if (customer != null)
            {
                dbContext.Remove(customer);
                await dbContext.SaveChangesAsync();
                return Ok(customer);
            }
            return NotFound();
        }


    }
}
