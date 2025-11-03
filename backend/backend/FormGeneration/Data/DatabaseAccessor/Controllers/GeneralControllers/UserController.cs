using backend.FormGeneration.DatabaseAccessor.Models.GeneralDataModels;
using backend.FormGeneration.DataInterface;
using Microsoft.AspNetCore.Mvc;

namespace backend.FormGeneration.DatabaseAccessor.Controllers.GeneralControllers;

[ApiController]
[Route("api/userTable")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet("{id:long}", Name = "GetUserById")]
    public async Task<IActionResult> GetUserByIdAsync(long id)
    {
        var user = await _userRepository.GetUserByIdAsync(id);
        return user == null ? NotFound() : Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUserAsync([FromBody] User user)
    {
        var created = await _userRepository.CreateUserAsync(user);
        return CreatedAtRoute("GetUserById", 
            new { id = created.UserID }, created);
    }
    
}