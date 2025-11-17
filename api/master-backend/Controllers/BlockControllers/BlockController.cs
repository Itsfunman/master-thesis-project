using master_backend.Models.IRepository.BlockIRepositories;
using master_backend.Models.ModelImplementations.BlockModels;
using Microsoft.AspNetCore.Mvc;

namespace master_backend.Controllers.BlockControllers;

[ApiExplorerSettings(GroupName = "Block")]
[ApiController]
[Route("api/[controller]")]
public class BlockController : ControllerBase
{
    private readonly IBlockRepository _repo;
    public BlockController(IBlockRepository repo) => _repo = repo;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Block>>> GetAll()
        => Ok(await _repo.GetBlocksAsync());

    [HttpGet("{id:long}")]
    public async Task<ActionResult<Block>> GetById(long id)
        => (await _repo.GetBlockByIdAsync(id)) is { } b ? Ok(b) : NotFound();

    [HttpPost]
    public async Task<ActionResult<Block>> Create([FromBody] Block block)
    {
        if (!ModelState.IsValid) return ValidationProblem(ModelState);
        var created = await _repo.CreateBlockAsync(block);
        return CreatedAtAction(nameof(GetById), new { id = created.blockId }, created);
    }

    [HttpPut("{id:long}")]
    public async Task<ActionResult<Block>> Update(long id, [FromBody] Block block)
    {
        if (id != block.blockId)
            return BadRequest(new { message = "Route id and body id must match." });

        if ((await _repo.GetBlockByIdAsync(id)) is null)
            return NotFound();

        var updated = await _repo.UpdateBlockAsync(block);
        return Ok(updated);
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id)
    {
        if ((await _repo.GetBlockByIdAsync(id)) is null)
            return NotFound();

        var ok = await _repo.DeleteBlockAsync(id);
        return ok ? NoContent() : Problem("Delete failed.");
    }
}