using master_backend.Models.IRepository.BlockIRepositories;
using master_backend.Models.ModelImplementations.BlockModels;
using Microsoft.AspNetCore.Mvc;

namespace master_backend.Controllers.BlockControllers;

[ApiExplorerSettings(GroupName = "Block")]
[ApiController]
[Route("api/[controller]")]
public class BlockKeywordLinkController : ControllerBase
{
    private readonly IBlockKeywordLinkRepository _repo;
    public BlockKeywordLinkController(IBlockKeywordLinkRepository repo) => _repo = repo;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BlockKeywordLink>>> GetAll()
        => Ok(await _repo.GetKeywordLinksAsync());

    [HttpGet("{id:long}")]
    public async Task<ActionResult<BlockKeywordLink>> GetById(long id)
        => (await _repo.GetKeywordLinkByIdAsync(id)) is { } l ? Ok(l) : NotFound();

    [HttpPost]
    public async Task<ActionResult<BlockKeywordLink>> Create([FromBody] BlockKeywordLink link)
    {
        if (!ModelState.IsValid) return ValidationProblem(ModelState);
        var created = await _repo.CreateKeywordLinkAsync(link);
        return CreatedAtAction(nameof(GetById), new { id = created.blockKeywordLinkId }, created);
    }

    [HttpPut("{id:long}")]
    public async Task<ActionResult<BlockKeywordLink>> Update(long id, [FromBody] BlockKeywordLink link)
    {
        if (id != link.blockKeywordLinkId)
            return BadRequest(new { message = "Route id and body id must match." });

        if ((await _repo.GetKeywordLinkByIdAsync(id)) is null)
            return NotFound();

        var updated = await _repo.UpdateKeywordLinkAsync(link);
        return Ok(updated);
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id)
    {
        if ((await _repo.GetKeywordLinkByIdAsync(id)) is null)
            return NotFound();

        var ok = await _repo.DeleteKeywordLinkAsync(id);
        return ok ? NoContent() : Problem("Delete failed.");
    }
}