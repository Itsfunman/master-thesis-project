using master_backend.Models.IRepository.FuzzyIRepositories;
using master_backend.Models.ModelImplementations.FuzzyModels;
using Microsoft.AspNetCore.Mvc;

namespace master_backend.Controllers.FuzzyControllers;

[ApiExplorerSettings(GroupName = "Fuzzy")]
[ApiController]
[Route("api/[controller]")]
public class UserWeightController : ControllerBase
{
    private readonly IUserWeightRepository _repo;
    public UserWeightController(IUserWeightRepository repo) => _repo = repo;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserWeight>>> GetAll()
        => Ok(await _repo.GetUserWeightsAsync());

    [HttpGet("{id:long}")]
    public async Task<ActionResult<UserWeight>> GetById(long id)
        => (await _repo.GetUserWeightByIdAsync(id)) is { } u ? Ok(u) : NotFound();

    [HttpPost]
    public async Task<ActionResult<UserWeight>> Create([FromBody] UserWeight userWeight)
    {
        if (!ModelState.IsValid) return ValidationProblem(ModelState);
        var created = await _repo.CreateUserWeightAsync(userWeight);
        return CreatedAtAction(nameof(GetById), new { id = created.userWeightId }, created);
    }

    [HttpPut("{id:long}")]
    public async Task<IActionResult> Update(long id, [FromBody] UserWeight userWeight)
    {
        if (id != userWeight.userWeightId)
            return BadRequest(new { message = "Route id and body id must match." });

        if ((await _repo.GetUserWeightByIdAsync(id)) is null)
            return NotFound();

        await _repo.UpdateUserWeightAsync(userWeight);
        return NoContent();
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id)
    {
        var ok = await _repo.DeleteUserWeightAsync(id);
        return ok ? NoContent() : NotFound();
    }
}