using master_backend.Models;
using master_backend.Models.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace master_backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DepartmentCategoryController : ControllerBase
{
    private readonly IDepartmentCategoryRepository _repo;
    
    public DepartmentCategoryController(IDepartmentCategoryRepository repo) => _repo = repo;
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<DepartmentCategory>>> GetAll()
        => Ok(await _repo.GetDepartmentsAsync());

    [HttpGet("{id:long}")]
    public async Task<ActionResult<DepartmentCategory>> GetById(long id)
        => (await _repo.GetDepartmentByIdAsync(id)) is { } d ? Ok(d) : NotFound();

    [HttpGet("by-name/{name}")]
    public async Task<ActionResult<DepartmentCategory>> GetByName(string name)
        => (await _repo.GetDepartmentByNameAsync(name)) is { } d ? Ok(d) : NotFound();

    [HttpPost]
    public async Task<ActionResult<DepartmentCategory>> Create([FromBody] DepartmentCategory department)
    {
        if (!ModelState.IsValid) return ValidationProblem(ModelState);
        var created = await _repo.CreateDepartmentAsync(department);
        return CreatedAtAction(nameof(GetById), new { id = created.DepartmentCategoryID }, created);
    }

    [HttpPut("{id:long}")]
    public async Task<IActionResult> Update(long id, [FromBody] DepartmentCategory department)
    {
        if (id != department.DepartmentCategoryID) return BadRequest(new { message = "Route id and body id must match." });
        if ((await _repo.GetDepartmentByIdAsync(id)) is null) return NotFound();
        var ok = await _repo.UpdateDepartmentAsync(department);
        return ok ? NoContent() : Problem("Update failed.");
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id)
    {
        var entity = await _repo.GetDepartmentByIdAsync(id);
        if (entity is null) return NotFound();
        var ok = await _repo.DeleteDepartmentAsync(entity);
        return ok ? NoContent() : Problem("Delete failed.");
    }
}