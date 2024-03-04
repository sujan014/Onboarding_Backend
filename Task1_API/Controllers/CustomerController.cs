using Microsoft.AspNetCore.Mvc;
using Task1_API.Models;
using Task1_API.Services;
using Task1_API.ViewModels.Customers;

namespace Task1_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService= customerService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces(typeof(IEnumerable<CustomerViewModel>))]
        public async Task<IActionResult> GetCustomers()
        {
            var customers = await _customerService.GetCustomers();
            return Ok(customers);
        }
        
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(typeof(CustomerViewModel))]
        public async Task<IActionResult> GetCustomer(int id)
        {
            try
            {
                var customer = await _customerService.GetCustomerById(id);
                return Ok(customer);
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("createcustomer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Produces(typeof(CustomerViewModel))]
        public async Task<IActionResult> CreateCustomer([FromBody]CreateCustomerRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var customerRequest = await _customerService.CreateCustomer(request);
            return Ok(customerRequest);
        }

        [HttpPost("updatecustomer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Produces(typeof(CustomerViewModel))]
        public async Task<IActionResult> UpdateCustomer(int? id, [FromBody]UpdateCustomerRequest? request)
        {
            if (id == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var customer = await _customerService.UpdateCustomer((int)id, request);                
                return Ok(customer);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);                
            }
        }

        [HttpPost("deletecustomer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]        
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            try
            {
                await _customerService.DeleteCustomer(id);                
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
            return Ok();
        }
    }
}
