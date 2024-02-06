using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }
        [HttpGet("detail")]
        public IActionResult Detail() 
        {
          var result= _carService.GetCarDetail();
            if (result.Succeess == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result= _carService.GetAll();

            if (result.Succeess == true)
            {
                return Ok(result);

            }
            return BadRequest(result.Message);

        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _carService.GetById(id);
            if (result.Succeess == true)
            {
                return Ok(result.Data);
            }
            return BadRequest(result);
        }

        [HttpGet("getbybrandid")]
        public IActionResult GetByBrandId(int id)
        {
            var result = _carService.GetCarsByBrandId(id);
            if (result.Succeess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Car car) 
        {
            var result = _carService.Add(car);

            if (result.Succeess == true)
            {
                return Ok(result);

            }
            return BadRequest(result.Message);
        }
        [HttpPost("delete")]
        public IActionResult Delet(Car car) 
        {
          var result= _carService.Delete(car);
            if(result.Succeess == true)
            {
                return Ok(result);

            }return BadRequest(result);
        
        
        
        }
        [HttpPost("update")]
        public IActionResult Update(Car car)
        {
            var result=_carService.Update(car);
            if (result.Succeess == true)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
