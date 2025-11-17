using master_backend.Models.IRepository.ProbabilityIRepositories;
using master_backend.Models.ModelImplementations.ProbabilityModels;
using Microsoft.AspNetCore.Mvc;

namespace master_backend.Controllers.ProbabilityControllers;

[ApiExplorerSettings(GroupName = "Probability")]
[ApiController]
[Route("api/[controller]")]
public class DepartmentCategoryActionController : ControllerBase
{
    private readonly IDepartmentCategoryActionRepository _repo;
    public DepartmentCategoryActionController(IDepartmentCategoryActionRepository repo) => _repo = repo;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DepartmentCategoryAction>>> GetAll()
        => Ok(await _repo.GetDepartmentCategoryActionsAsync());

    [HttpGet("{id:long}")]
    public async Task<ActionResult<DepartmentCategoryAction>> GetById(long id)
        => (await _repo.GetDepartmentCategoryActionByIdAsync(id)) is { } a ? Ok(a) : NotFound();

    [HttpGet("by-department-category/{departmentCategoryId:long}")]
    public async Task<ActionResult<IEnumerable<DepartmentCategoryAction>>> GetByDepartmentCategory(long departmentCategoryId)
        => Ok(await _repo.GetDepartmentCategoryActionsByDepartmentCategoryIdAsync(departmentCategoryId));

    [HttpPost]
    public async Task<ActionResult<DepartmentCategoryAction>> Create([FromBody] DepartmentCategoryAction action)
    {
        if (!ModelState.IsValid) return ValidationProblem(ModelState);
        var created = await _repo.CreateDepartmentCategoryActionAsync(action);
        return CreatedAtAction(nameof(GetById), new { id = created.departmentCategoryActionId }, created);
    }

    [HttpPut("{id:long}")]
    public async Task<IActionResult> Update(long id, [FromBody] DepartmentCategoryAction action)
    {
        if (id != action.departmentCategoryActionId)
            return BadRequest(new { message = "Route id and body id must match." });

        if ((await _repo.GetDepartmentCategoryActionByIdAsync(id)) is null)
            return NotFound();

        await _repo.UpdateDepartmentCategoryActionAsync(action);
        return NoContent();
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id)
    {
        var ok = await _repo.DeleteDepartmentCategoryActionAsync(id);
        return ok ? NoContent() : NotFound();
    }
}