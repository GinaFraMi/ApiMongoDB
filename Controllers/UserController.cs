using ApiCRUDMongoDB.Models;
using ApiCRUDMongoDB.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiCRUDMongoDB.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly UserService _userService;

    public UserController(UserService userService) => this._userService = userService;

    [HttpGet]
    public async Task<List<User>> Get()
    {
       return await _userService.GetAllUser();
    }

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<User>> Get(string id)
    {
        var user = await _userService.GetUser(id);
        if (user is null)
        {
            return NotFound();
        }
        return user;
    }

    [HttpPost]
    public async Task<IActionResult> Post(User newUser)
    {
        await _userService.CreateUser(newUser);
        return CreatedAtAction(nameof(Get), new { id = newUser.Id }, newUser);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, User updatedUser)
    {
        var user = await _userService.GetUser(id);
        if (user is null)
        {
            return NotFound();
        }
        updatedUser.Id = id;
        await _userService.UpdateUser(id, updatedUser);
        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var user = await _userService.GetUser(id);
        if (user is null)
        {
            return NotFound();
        }
        await _userService.DeleteUser(id);
        return NoContent();
    }
}