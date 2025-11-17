using master_backend.Models.IRepository.ProbabilityIRepositories;
using master_backend.Models.ModelImplementations.ProbabilityModels;
using Microsoft.AspNetCore.Mvc;

namespace master_backend.Controllers.ProbabilityControllers;

[ApiExplorerSettings(GroupName = "Probability")]
[ApiController]
[Route("api/[controller]")]
public class CompanyActionController : ControllerBase
{
    private readonly ICompanyActionRepository _repo;
    public CompanyActionController(ICompanyActionRepository repo) => _repo = repo;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CompanyAction>>> GetAll()
        => Ok(await _repo.GetCompanyActionsAsync());

    [HttpGet("{id:long}")]
    public async Task<ActionResult<CompanyAction>> GetById(long id)
        => (await _repo.GetCompanyActionByIdAsync(id)) is { } ca ? Ok(ca) : NotFound();

    [HttpGet("by-company/{companyId:long}")]
    public async Task<ActionResult<CompanyAction>> GetByCompanyId(long companyId)
        => (await _repo.GetCompanyActionByCompanyIdAsync(companyId)) is { } ca ? Ok(ca) : NotFound();

    [HttpPost]
    public async Task<ActionResult<CompanyAction>> Create([FromBody] CompanyAction companyAction)
    {
        if (!ModelState.IsValid) return ValidationProblem(ModelState);
        var created = await _repo.CreateCompanyActionAsync(companyAction);
        return CreatedAtAction(nameof(GetById), new { id = created.companyActionId }, created);
    }

    [HttpPut("{id:long}")]
    public async Task<IActionResult> Update(long id, [FromBody] CompanyAction companyAction)
    {
        if (id != companyAction.companyActionId)
            return BadRequest(new { message = "Route id and body id must match." });

        if ((await _repo.GetCompanyActionByIdAsync(id)) is null)
            return NotFound();

        await _repo.UpdateCompanyActionAsync(companyAction);
        return NoContent();
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id)
    {
        var success = await _repo.DeleteCompanyActionAsync(id);
        return success ? NoContent() : NotFound();
    }
}