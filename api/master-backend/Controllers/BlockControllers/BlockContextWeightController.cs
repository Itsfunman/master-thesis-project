using master_backend.Models.IRepository.BlockIRepositories;
using master_backend.Models.ModelImplementations.BlockModels;
using Microsoft.AspNetCore.Mvc;

namespace master_backend.Controllers.BlockControllers;

[ApiExplorerSettings(GroupName = "Block")]
[ApiController]
[Route("api/[controller]")]
public class BlockContextWeightController : ControllerBase
{
    private readonly IBlockContextWeightRepository _repo;
    public BlockContextWeightController(IBlockContextWeightRepository repo) => _repo = repo;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BlockContextWeight>>> GetAll()
        => Ok(await _repo.GetContextWeightsAsync());

    [HttpGet("{id:long}")]
    public async Task<ActionResult<BlockContextWeight>> GetById(long id)
        => (await _repo.GetContextWeightByIdAsync(id)) is { } cw ? Ok(cw) : NotFound();

    [HttpPost]
    public async Task<ActionResult<BlockContextWeight>> Create([FromBody] BlockContextWeight contextWeight)
    {
        if (!ModelState.IsValid) return ValidationProblem(ModelState);
        var created = await _repo.CreateContextWeightAsync(contextWeight);
        return CreatedAtAction(nameof(GetById), new { id = created.blockContextWeightId }, created);
    }

    [HttpPut("{id:long}")]
    public async Task<ActionResult<BlockContextWeight>> Update(long id, [FromBody] BlockContextWeight contextWeight)
    {
        if (id != contextWeight.blockContextWeightId)
            return BadRequest(new { message = "Route id and body id must match." });

        if ((await _repo.GetContextWeightByIdAsync(id)) is null)
            return NotFound();

        var updated = await _repo.UpdateContextWeightAsync(contextWeight);
        return Ok(updated);
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id)
    {
        if ((await _repo.GetContextWeightByIdAsync(id)) is null)
            return NotFound();

        var ok = await _repo.DeleteContextWeightAsync(id);
        return ok ? NoContent() : Problem("Delete failed.");
    }
}