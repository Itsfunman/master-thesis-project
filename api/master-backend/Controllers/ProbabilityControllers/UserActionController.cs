using master_backend.Models.IRepository.ProbabilityIRepositories;
using master_backend.Models.ModelImplementations.ProbabilityModels;
using Microsoft.AspNetCore.Mvc;

namespace master_backend.Controllers.ProbabilityControllers;

[ApiExplorerSettings(GroupName = "Probability")]
[ApiController]
[Route("api/[controller]")]
public class UserActionController : ControllerBase
{
    private readonly IUserActionRepository _repo;
    public UserActionController(IUserActionRepository repo) => _repo = repo;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserAction>>> GetAll()
        => Ok(await _repo.GetUserActionsAsync());

    [HttpGet("{id:long}")]
    public async Task<ActionResult<UserAction>> GetById(long id)
        => (await _repo.GetUserActionByIdAsync(id)) is { } a ? Ok(a) : NotFound();

    [HttpGet("by-user/{userId:long}")]
    public async Task<ActionResult<UserAction>> GetByUser(long userId)
        => (await _repo.GetUserActionByUserIdAsync(userId)) is { } a ? Ok(a) : NotFound();

    [HttpPost]
    public async Task<ActionResult<UserAction>> Create([FromBody] UserAction action)
    {
        if (!ModelState.IsValid) return ValidationProblem(ModelState);
        var created = await _repo.CreateUserActionAsync(action);
        return CreatedAtAction(nameof(GetById), new { id = created.userActionId }, created);
    }

    [HttpPut("{id:long}")]
    public async Task<IActionResult> Update(long id, [FromBody] UserAction action)
    {
        if (id != action.userActionId)
            return BadRequest(new { message = "Route id and body id must match." });

        if ((await _repo.GetUserActionByIdAsync(id)) is null)
            return NotFound();

        await _repo.UpdateUserActionAsync(action);
        return NoContent();
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id)
    {
        var ok = await _repo.DeleteUserActionAsync(id);
        return ok ? NoContent() : NotFound();
    }
}