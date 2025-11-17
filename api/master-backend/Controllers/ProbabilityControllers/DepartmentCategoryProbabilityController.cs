using master_backend.Models.IRepository.ProbabilityIRepositories;
using master_backend.Models.ModelImplementations.ProbabilityModels;
using Microsoft.AspNetCore.Mvc;

namespace master_backend.Controllers.ProbabilityControllers;

[ApiExplorerSettings(GroupName = "Probability")]
[ApiController]
[Route("api/[controller]")]
public class DepartmentCategoryProbabilityController : ControllerBase
{
    private readonly IDepartmentCategoryProbabilityRepository _repo;
    public DepartmentCategoryProbabilityController(IDepartmentCategoryProbabilityRepository repo) => _repo = repo;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DepartmentCategoryProbability>>> GetAll()
        => Ok(await _repo.GetDepartmentCategoryProbabilitiesAsync());

    [HttpGet("{id:long}")]
    public async Task<ActionResult<DepartmentCategoryProbability>> GetById(long id)
        => (await _repo.GetDepartmentCategoryProbabilityByIdAsync(id)) is { } p ? Ok(p) : NotFound();

    [HttpGet("by-action/{departmentCategoryActionId:long}")]
    public async Task<ActionResult<IEnumerable<DepartmentCategoryProbability>>> GetByAction(long departmentCategoryActionId)
        => Ok(await _repo.GetDepartmentCategoryProbabilitiesByActionIdAsync(departmentCategoryActionId));

    [HttpGet("by-block/{blockId:long}")]
    public async Task<ActionResult<IEnumerable<DepartmentCategoryProbability>>> GetByBlock(long blockId)
        => Ok(await _repo.GetDepartmentCategoryProbabilitiesByBlockIdAsync(blockId));

    [HttpPost]
    public async Task<ActionResult<DepartmentCategoryProbability>> Create([FromBody] DepartmentCategoryProbability probability)
    {
        if (!ModelState.IsValid) return ValidationProblem(ModelState);
        var created = await _repo.CreateDepartmentCategoryProbabilityAsync(probability);
        return CreatedAtAction(nameof(GetById), new { id = created.departmentCategoryProbabilityId }, created);
    }

    [HttpPut("{id:long}")]
    public async Task<IActionResult> Update(long id, [FromBody] DepartmentCategoryProbability probability)
    {
        if (id != probability.departmentCategoryProbabilityId)
            return BadRequest(new { message = "Route id and body id must match." });

        if ((await _repo.GetDepartmentCategoryProbabilityByIdAsync(id)) is null)
            return NotFound();

        await _repo.UpdateDepartmentCategoryProbabilityAsync(probability);
        return NoContent();
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id)
    {
        var ok = await _repo.DeleteDepartmentCategoryProbabilityAsync(id);
        return ok ? NoContent() : NotFound();
    }
}