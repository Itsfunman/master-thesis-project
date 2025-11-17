using master_backend.Models.IRepository.ProbabilityIRepositories;
using master_backend.Models.ModelImplementations.ProbabilityModels;
using Microsoft.AspNetCore.Mvc;

namespace master_backend.Controllers.ProbabilityControllers;

[ApiExplorerSettings(GroupName = "Probability")]
[ApiController]
[Route("api/[controller]")]
public class BlockProbabilityHistoryController : ControllerBase
{
    private readonly IBlockProbabilityHistoryRepository _repo;
    public BlockProbabilityHistoryController(IBlockProbabilityHistoryRepository repo) => _repo = repo;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BlockProbabilityHistory>>> GetAll()
        => Ok(await _repo.GetBlockProbabilityHistoriesAsync());

    [HttpGet("{id:long}")]
    public async Task<ActionResult<BlockProbabilityHistory>> GetById(long id)
        => (await _repo.GetBlockProbabilityHistoryByIdAsync(id)) is { } e ? Ok(e) : NotFound();

    [HttpPost]
    public async Task<ActionResult<BlockProbabilityHistory>> Create([FromBody] BlockProbabilityHistory entity)
    {
        if (!ModelState.IsValid) return ValidationProblem(ModelState);
        var created = await _repo.CreateBlockProbabilityHistoryAsync(entity);
        return CreatedAtAction(nameof(GetById), new { id = created.blockProbabilityHistoryId }, created);
    }

    [HttpPut("{id:long}")]
    public async Task<ActionResult<BlockProbabilityHistory>> Update(long id, [FromBody] BlockProbabilityHistory entity)
    {
        if (id != entity.blockProbabilityHistoryId)
            return BadRequest(new { message = "Route id and body id must match." });

        if ((await _repo.GetBlockProbabilityHistoryByIdAsync(id)) is null)
            return NotFound();

        var updated = await _repo.UpdateBlockProbabilityHistoryAsync(entity);
        return Ok(updated);
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id)
    {
        var deleted = await _repo.DeleteBlockProbabilityHistoryAsync(id);
        return deleted ? NoContent() : NotFound();
    }
}