using master_backend.Models;
using master_backend.Models.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace master_backend.Controllers;

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
    public async Task<IActionResult> Update(long id, [FromBody] BusinessCategory business)
    {
        if (id != business.BusinessCategoryID) return BadRequest(new { message = "Route id and body id must match." });
        if ((await _repo.GetBusinessByIdAsync(id)) is null) return NotFound();
        var ok = await _repo.UpdateBusinessAsync(business);
        return ok ? NoContent() : Problem("Update failed.");
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id)
    {
        var entity = await _repo.GetBusinessByIdAsync(id);
        if (entity is null) return NotFound();
        var ok = await _repo.DeleteBusinessAsync(entity);
        return ok ? NoContent() : Problem("Delete failed.");
    }
}
