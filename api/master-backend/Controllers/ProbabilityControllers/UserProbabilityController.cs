using master_backend.Models.IRepository.ProbabilityIRepositories;
using master_backend.Models.ModelImplementations.ProbabilityModels;
using Microsoft.AspNetCore.Mvc;

namespace master_backend.Controllers.ProbabilityControllers;

[ApiExplorerSettings(GroupName = "Probability")]
[ApiController]
[Route("api/[controller]")]
public class UserProbabilityController : ControllerBase
{
    private readonly IUserProbabilityRepository _repo;
    public UserProbabilityController(IUserProbabilityRepository repo) => _repo = repo;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserProbability>>> GetAll()
        => Ok(await _repo.GetUserProbabilitiesAsync());

    [HttpGet("{id:long}")]
    public async Task<ActionResult<UserProbability>> GetById(long id)
        => (await _repo.GetUserProbabilityByIdAsync(id)) is { } p ? Ok(p) : NotFound();

    [HttpGet("by-action/{userActionId:long}")]
    public async Task<ActionResult<IEnumerable<UserProbability>>> GetByUserAction(long userActionId)
        => Ok(await _repo.GetUserProbabilitiesByUserActionIdAsync(userActionId));

    [HttpGet("by-block/{blockId:long}")]
    public async Task<ActionResult<IEnumerable<UserProbability>>> GetByBlock(long blockId)
        => Ok(await _repo.GetUserProbabilitiesByBlockIdAsync(blockId));

    [HttpPost]
    public async Task<ActionResult<UserProbability>> Create([FromBody] UserProbability prob)
    {
        if (!ModelState.IsValid) return ValidationProblem(ModelState);
        var created = await _repo.CreateUserProbabilityAsync(prob);
        return CreatedAtAction(nameof(GetById), new { id = created.userProbabilityId }, created);
    }

    [HttpPut("{id:long}")]
    public async Task<IActionResult> Update(long id, [FromBody] UserProbability prob)
    {
        if (id != prob.userProbabilityId)
            return BadRequest(new { message = "Route id and body id must match." });

        if ((await _repo.GetUserProbabilityByIdAsync(id)) is null)
            return NotFound();

        await _repo.UpdateUserProbabilityAsync(prob);
        return NoContent();
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id)
    {
        var ok = await _repo.DeleteUserProbabilityAsync(id);
        return ok ? NoContent() : NotFound();
    }
}