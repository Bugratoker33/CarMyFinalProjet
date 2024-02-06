using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpGet("getall")]
        public IActionResult Getall()
        {
            var result = _customerService.GetAll();
            if (result.Succeess == true)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("getbyıd")]
        public IActionResult getbyıd(int id)
        {
            var result = _customerService.GetById(id);

            if (result.Succeess == true)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("add")]
        public IActionResult Add(Customer customer)
        {

            var result = _customerService.Add(customer);

            if (result.Succeess == true)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("update")]
        public IActionResult Update(Customer customer)
        {
            var result = _customerService.Update(customer);
            if (result.Succeess == true)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("delete")]
        public IActionResult Delete(Customer customer)
        {
            var result = _customerService.Delete(customer);
            if (!result.Succeess)
            {
                return BadRequest(result);
            }
            return BadRequest(result);

        }

    }
}
