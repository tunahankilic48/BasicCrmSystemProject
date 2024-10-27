using BasicCrmSystem_Application.Models.DTOs;
using BasicCrmSystem_Application.Models.VMs;
using BasicCrmSystem_Application.Services.CustomerService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BasicCrmSystem_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        [Authorize]
        public async Task<List<CustomerVM>> GetAll()
        {
            List<CustomerVM> customers = await _customerService.GetAllCustomers();

            return customers;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateCustomerDTO model)
        {
            bool result = await _customerService.Create(model);

            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Update([FromBody] UpdateCustomerDTO model)
         {
             bool result = await _customerService.Update(model);

             if (result)
             {
                 return Ok();
             }
             return BadRequest();
         }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
         {
             await _customerService.Delete(id);
             return Ok();
         }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<UpdateCustomerDTO> GetById(int id)
         {
             UpdateCustomerDTO customer = await _customerService.GetById(id);
             return customer;
         }
    }
}
