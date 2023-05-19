using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiValidCustom.Models;

namespace WebApiValidCustom.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    [HttpPost(template:"/")]
    public IActionResult Post([FromBody]CreateUserModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest();
        
        return Ok();
    }
}
