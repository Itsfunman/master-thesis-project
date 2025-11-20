using master_backend.Models.IRepository.FuzzyIRepositories;
using master_backend.Models.ModelImplementations.FuzzyModels;
using Microsoft.AspNetCore.Mvc;

namespace master_backend.Controllers.FuzzyControllers;

[ApiExplorerSettings(GroupName = "Fuzzy")]
[ApiController]
[Route("api/[controller]")]
public class CompanyWeightController : ControllerBase
{
    private readonly ICompanyWeightRepository _repo;
    public CompanyWeightController(ICompanyWeightRepository repo) => _repo = repo;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CompanyWeight>>> GetAll()
        => Ok(await _repo.GetCompanyWeightsAsync());

    [HttpGet("{id:long}")]
    public async Task<ActionResult<CompanyWeight>> GetById(long id)
        => (await _repo.GetCompanyWeightByIdAsync(id)) is { } u ? Ok(u) : NotFound();

    [HttpPost]
    public async Task<ActionResult<CompanyWeight>> Create([FromBody] CompanyWeight companyWeight)
    {
        if (!ModelState.IsValid) return ValidationProblem(ModelState);
        var created = await _repo.CreateCompanyWeightAsync(companyWeight);
        return CreatedAtAction(nameof(GetById), new { id = created.companyWeightId }, created);
    }

    [HttpPut("{id:long}")]
    public async Task<IActionResult> Update(long id, [FromBody] CompanyWeight companyWeight)
    {
        if (id != companyWeight.companyWeightId)
            return BadRequest(new { message = "Route id and body id must match." });

        if ((await _repo.GetCompanyWeightByIdAsync(id)) is null)
            return NotFound();

        await _repo.UpdateCompanyWeightAsync(companyWeight);
        return NoContent();
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id)
    {
        var ok = await _repo.DeleteCompanyWeightAsync(id);
        return ok ? NoContent() : NotFound();
    }
}