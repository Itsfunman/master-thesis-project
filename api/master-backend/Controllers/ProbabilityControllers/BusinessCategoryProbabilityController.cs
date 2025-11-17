using master_backend.Models.IRepository.ProbabilityIRepositories;
using master_backend.Models.ModelImplementations.ProbabilityModels;
using Microsoft.AspNetCore.Mvc;

namespace master_backend.Controllers.ProbabilityControllers;

[ApiExplorerSettings(GroupName = "Probability")]
[ApiController]
[Route("api/[controller]")]
public class BusinessCategoryProbabilityController : ControllerBase
{
    private readonly IBusinessCategoryProbabilityRepository _repo;
    public BusinessCategoryProbabilityController(IBusinessCategoryProbabilityRepository repo) => _repo = repo;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BusinessCategoryProbability>>> GetAll()
        => Ok(await _repo.GetBusinessCategoryProbabilitiesAsync());

    [HttpGet("{id:long}")]
    public async Task<ActionResult<BusinessCategoryProbability>> GetById(long id)
        => (await _repo.GetBusinessCategoryProbabilityByIdAsync(id)) is { } p ? Ok(p) : NotFound();

    [HttpGet("by-action/{businessCategoryActionId:long}")]
    public async Task<ActionResult<IEnumerable<BusinessCategoryProbability>>> GetByAction(long businessCategoryActionId)
        => Ok(await _repo.GetBusinessCategoryProbabilitiesByActionIdAsync(businessCategoryActionId));

    [HttpGet("by-block/{blockId:long}")]
    public async Task<ActionResult<IEnumerable<BusinessCategoryProbability>>> GetByBlock(long blockId)
        => Ok(await _repo.GetBusinessCategoryProbabilitiesByBlockIdAsync(blockId));

    [HttpPost]
    public async Task<ActionResult<BusinessCategoryProbability>> Create([FromBody] BusinessCategoryProbability prob)
    {
        if (!ModelState.IsValid) return ValidationProblem(ModelState);
        var created = await _repo.CreateBusinessCategoryProbabilityAsync(prob);
        return CreatedAtAction(nameof(GetById),
            new { id = created.businessCategoryProbabilityId }, created);
    }

    [HttpPut("{id:long}")]
    public async Task<ActionResult<BusinessCategoryProbability>> Update(long id, [FromBody] BusinessCategoryProbability prob)
    {
        if (id != prob.businessCategoryProbabilityId)
            return BadRequest(new { message = "Route id and body id must match." });

        if ((await _repo.GetBusinessCategoryProbabilityByIdAsync(id)) is null)
            return NotFound();

        var updated = await _repo.UpdateBusinessCategoryProbabilityAsync(prob);
        return Ok(updated);
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id)
    {
        var ok = await _repo.DeleteBusinessCategoryProbabilityAsync(id);
        return ok ? NoContent() : NotFound();
    }
}