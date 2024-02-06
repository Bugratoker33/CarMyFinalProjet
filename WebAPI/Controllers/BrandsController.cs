using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result=_brandService.GetAll();
            if (result.Succeess ==true )
            {
                return Ok(result);

            }
            return BadRequest(result);
        }
        [HttpGet("getbyıd")]
        public IActionResult GetById(int id) 
        {
            var result=_brandService.GetById(id);
            if (result.Succeess ==true )
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult add(Brand brand)
        {
            var result = _brandService.Add(brand);
            if(result.Succeess ==true )
            {
                return Ok(result);

            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult delete(Brand brand) 
        {
            var result = _brandService.Delete(brand);
            if (result.Succeess ==true )
            {
                return Ok(result);
            }
            return BadRequest(result);
        }




        [HttpPost("update")]
        public IActionResult update(Brand brand) 
        {
            var result = _brandService.Update( brand );
            if(result.Succeess ==true )
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

    }
}
