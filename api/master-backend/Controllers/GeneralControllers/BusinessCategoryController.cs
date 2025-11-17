using master_backend.Models.IRepository.GeneralIRepositories;
using master_backend.Models.ModelImplementations.GeneralModels;
using Microsoft.AspNetCore.Mvc;

namespace master_backend.Controllers.GeneralControllers;

[ApiExplorerSettings(GroupName = "General")]
[ApiController]
[Route("api/[controller]")]
public class BusinessesCategoryController : ControllerBase
{
    private readonly IBusinessCategoryRepository _repo;
    public BusinessesCategoryController(IBusinessCategoryRepository repo) => _repo = repo;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BusinessCategory>>> GetAll()
        => Ok(await _repo.GetBusinessesAsync());

    [HttpGet("{id:long}")]
    public async Task<ActionResult<BusinessCategory>> GetById(long id)
        => (await _repo.GetBusinessByIdAsync(id)) is { } b ? Ok(b) : NotFound();

    [HttpGet("by-name/{name}")]
    public async Task<ActionResult<BusinessCategory>> GetByName(string name)
        => (await _repo.GetBusinessByNameAsync(name)) is { } b ? Ok(b) : NotFound();

    [HttpPost]
    public async Task<ActionResult<BusinessCategory>> Create([FromBody] BusinessCategory business)
    {
        if (!ModelState.IsValid) return ValidationProblem(ModelState);
        var created = await _repo.CreateBusinessAsync(business);
        return CreatedAtAction(nameof(GetById), new { id = created.BusinessCategoryID }, created);
    }

    [HttpPut("{id:long}")]
    public async Task<ActionResult<BusinessCategory>> Update(long id, [FromBody] BusinessCategory businessCategory)
    {
        if (id != businessCategory.BusinessCategoryID)
            return BadRequest(new { message = "Route id and body id must match." });

        if ((await _repo.GetBusinessByIdAsync(id)) is null)
            return NotFound();

        var updated = await _repo.UpdateBusinessAsync(businessCategory);
        return Ok(updated);
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id)
    {
        if ((await _repo.GetBusinessByIdAsync(id)) is null)
            return NotFound();

        var ok = await _repo.DeleteBusinessAsync(id);
        return ok ? NoContent() : Problem("Delete failed.");
    }
}
