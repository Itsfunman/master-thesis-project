using master_backend.Models.IRepository.GeneralIRepositories;
using master_backend.Models.ModelImplementations.GeneralModels;
using Microsoft.AspNetCore.Mvc;

namespace master_backend.Controllers.GeneralControllers;

[ApiExplorerSettings(GroupName = "General")]
[ApiController]
[Route("api/[controller]")]
public class CompanyController : ControllerBase
{
    private readonly ICompanyRepository _repo;
    public CompanyController(ICompanyRepository repo) => _repo = repo;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Company>>> GetAll()
        => Ok(await _repo.GetCompaniesAsync());

    [HttpGet("{id:long}")]
    public async Task<ActionResult<Company>> GetById(long id)
        => (await _repo.GetCompanyByIdAsync(id)) is { } c ? Ok(c) : NotFound();

    [HttpGet("by-name/{name}")]
    public async Task<ActionResult<Company>> GetByName(string name)
        => (await _repo.GetCompanyByNameAsync(name)) is { } c ? Ok(c) : NotFound();

    [HttpPost]
    public async Task<ActionResult<Company>> Create([FromBody] Company company)
    {
        if (!ModelState.IsValid) return ValidationProblem(ModelState);
        var created = await _repo.CreateCompanyAsync(company);
        return CreatedAtAction(nameof(GetById), new { id = created.CompanyId }, created);
    }

    [HttpPut("{id:long}")]
    public async Task<IActionResult> Update(long id, [FromBody] Company company)
    {
        if (id != company.CompanyId) 
            return BadRequest(new { message = "Route id and body id must match." });

        if ((await _repo.GetCompanyByIdAsync(id)) is null) 
            return NotFound();

        await _repo.UpdateCompanyAsync(company);
        return NoContent();
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id)
    {
        var ok = await _repo.DeleteCompanyAsync(id);
        return ok ? NoContent() : NotFound();
    }
}