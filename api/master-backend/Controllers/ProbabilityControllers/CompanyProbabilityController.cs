using master_backend.Models.IRepository.ProbabilityIRepositories;
using master_backend.Models.ModelImplementations.ProbabilityModels;
using Microsoft.AspNetCore.Mvc;

namespace master_backend.Controllers.ProbabilityControllers;

[ApiExplorerSettings(GroupName = "Probability")]
[ApiController]
[Route("api/[controller]")]
public class CompanyProbabilityController : ControllerBase
{
    private readonly ICompanyProbabilityRepository _repo;
    public CompanyProbabilityController(ICompanyProbabilityRepository repo) => _repo = repo;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CompanyProbability>>> GetAll()
        => Ok(await _repo.GetCompanyProbabilitiesAsync());

    [HttpGet("{id:long}")]
    public async Task<ActionResult<CompanyProbability>> GetById(long id)
        => (await _repo.GetCompanyProbabilityByIdAsync(id)) is { } cp ? Ok(cp) : NotFound();

    [HttpGet("by-action/{companyActionId:long}")]
    public async Task<ActionResult<IEnumerable<CompanyProbability>>> GetByAction(long companyActionId)
        => Ok(await _repo.GetCompanyProbabilitiesByCompanyActionIdAsync(companyActionId));

    [HttpGet("by-block/{blockId:long}")]
    public async Task<ActionResult<IEnumerable<CompanyProbability>>> GetByBlock(long blockId)
        => Ok(await _repo.GetCompanyProbabilitiesByBlockIdAsync(blockId));

    [HttpPost]
    public async Task<ActionResult<CompanyProbability>> Create([FromBody] CompanyProbability companyProbability)
    {
        if (!ModelState.IsValid) return ValidationProblem(ModelState);
        var created = await _repo.CreateCompanyProbabilityAsync(companyProbability);
        return CreatedAtAction(nameof(GetById), new { id = created.companyProbabilityId }, created);
    }

    [HttpPut("{id:long}")]
    public async Task<IActionResult> Update(long id, [FromBody] CompanyProbability companyProbability)
    {
        if (id != companyProbability.companyProbabilityId)
            return BadRequest(new { message = "Route id and body id must match." });

        if ((await _repo.GetCompanyProbabilityByIdAsync(id)) is null)
            return NotFound();

        await _repo.UpdateCompanyProbabilityAsync(companyProbability);
        return NoContent();
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id)
    {
        var success = await _repo.DeleteCompanyProbabilityAsync(id);
        return success ? NoContent() : NotFound();
    }
}