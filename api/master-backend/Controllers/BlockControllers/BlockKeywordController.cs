using master_backend.Models.IRepository.BlockIRepositories;
using master_backend.Models.ModelImplementations.BlockModels;
using Microsoft.AspNetCore.Mvc;

namespace master_backend.Controllers.BlockControllers;

[ApiExplorerSettings(GroupName = "Block")]
[ApiController]
[Route("api/[controller]")]
public class BlockKeywordController : ControllerBase
{
    private readonly IBlockKeywordRepository _repo;
    public BlockKeywordController(IBlockKeywordRepository repo) => _repo = repo;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BlockKeyword>>> GetAll()
        => Ok(await _repo.GetKeywordsAsync());

    [HttpGet("{id:long}")]
    public async Task<ActionResult<BlockKeyword>> GetById(long id)
        => (await _repo.GetKeywordByIdAsync(id)) is { } k ? Ok(k) : NotFound();

    [HttpGet("by-name/{name}")]
    public async Task<ActionResult<BlockKeyword>> GetByName(string name)
        => (await _repo.GetKeywordByNameAsync(name)) is { } k ? Ok(k) : NotFound();

    [HttpPost]
    public async Task<ActionResult<BlockKeyword>> Create([FromBody] BlockKeyword keyword)
    {
        if (!ModelState.IsValid) return ValidationProblem(ModelState);
        var created = await _repo.CreateKeywordAsync(keyword);
        return CreatedAtAction(nameof(GetById), new { id = created.blockKeywordId }, created);
    }

    [HttpPut("{id:long}")]
    public async Task<ActionResult<BlockKeyword>> Update(long id, [FromBody] BlockKeyword keyword)
    {
        if (id != keyword.blockKeywordId)
            return BadRequest(new { message = "Route id and body id must match." });

        if ((await _repo.GetKeywordByIdAsync(id)) is null)
            return NotFound();

        var updated = await _repo.UpdateKeywordAsync(keyword);
        return Ok(updated);
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id)
    {
        if ((await _repo.GetKeywordByIdAsync(id)) is null)
            return NotFound();

        var ok = await _repo.DeleteKeywordAsync(id);
        return ok ? NoContent() : Problem("Delete failed.");
    }
}