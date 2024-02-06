using Business.Abstract;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("getall")]
        public IActionResult Getall()
        {
            var result = _userService.GetAll();
            if (result.Succeess == true)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("getbyıd")]
        public IActionResult getbyıd(int id)
        {
            var result = _userService.GetById(id);

            if (result.Succeess == true)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("add")]
        public IActionResult Add(User user)
        {

            var result = _userService.Add(user);

            if (result.Succeess == true)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("update")]
        public IActionResult Update(User user)
        {
            var result = _userService.Update(user);
            if (result.Succeess == true)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("delete")]
        public IActionResult Delete(User user)
        {
            var result = _userService.Delete(user);
            if (!result.Succeess)
            {
                return BadRequest(result);
            }
            return BadRequest(result);

        }

    }
}
