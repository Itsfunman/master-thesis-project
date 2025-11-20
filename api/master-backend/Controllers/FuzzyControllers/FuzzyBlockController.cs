using master_backend.Models.IRepository.FuzzyIRepositories;
using master_backend.Models.ModelImplementations.FuzzyModels;
using Microsoft.AspNetCore.Mvc;

namespace master_backend.Controllers.FuzzyControllers;

[ApiExplorerSettings(GroupName = "Fuzzy")]
[ApiController]
[Route("api/[controller]")]
public class FuzzyBlockController : ControllerBase
{
    private readonly IFuzzyBlockRepository _repo;
    public FuzzyBlockController(IFuzzyBlockRepository repo) => _repo = repo;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<FuzzyBlock>>> GetAll()
        => Ok(await _repo.GetFuzzyBlocksAsync());
    
    [HttpGet("by-block/{blockId:long}")]
    public async Task<ActionResult<IEnumerable<FuzzyBlock>>> GetByBlock(long blockId)
        => Ok(await _repo.GetFuzzyBlocksByBlockIdAsync(blockId));
    
    [HttpGet("{id:long}")]
    public async Task<ActionResult<FuzzyBlock>> GetById(long id)
        => (await _repo.GetFuzzyBlockByIdAsync(id)) is { } u ? Ok(u) : NotFound();

    [HttpPost]
    public async Task<ActionResult<FuzzyBlock>> Create([FromBody] FuzzyBlock fuzzyBlock)
    {
        if (!ModelState.IsValid) return ValidationProblem(ModelState);
        var created = await _repo.CreateFuzzyBlockAsync(fuzzyBlock);
        return CreatedAtAction(nameof(GetById), new { id = created.fuzzyBlockId }, created);
    }

    [HttpPut("{id:long}")]
    public async Task<IActionResult> Update(long id, [FromBody] FuzzyBlock fuzzyBlock)
    {
        if (id != fuzzyBlock.fuzzyBlockId)
            return BadRequest(new { message = "Route id and body id must match." });

        if ((await _repo.GetFuzzyBlockByIdAsync(id)) is null)
            return NotFound();

        await _repo.UpdateFuzzyBlockAsync(fuzzyBlock);
        return NoContent();
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id)
    {
        var ok = await _repo.DeleteFuzzyBlockAsync(id);
        return ok ? NoContent() : NotFound();
    }
}