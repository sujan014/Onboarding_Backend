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
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(typeof(IEnumerable<CustomerViewModel>))]
        public async Task<IActionResult> GetCustomers()
        {
            try
            {
                var customers = await _customerService.GetCustomers();
                return Ok(customers);
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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

        [HttpPost("createCustomer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(typeof(CustomerViewModel))]
        public async Task<IActionResult> CreateCustomer([FromBody]CreateCustomerRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var customerRequest = await _customerService.CreateCustomer(request);
                return Ok(customerRequest);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("updateCustomer/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]        
        [Produces(typeof(CustomerViewModel))]
        public async Task<IActionResult> UpdateCustomer(int? id, [FromBody]UpdateCustomerRequest request)
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

        [HttpDelete("deleteCustomer/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            try
            {
                await _customerService.DeleteCustomer(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }            
        }
    }
}
