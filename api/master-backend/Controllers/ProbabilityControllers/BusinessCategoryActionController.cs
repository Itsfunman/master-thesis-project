using master_backend.Models.IRepository.ProbabilityIRepositories;
using master_backend.Models.ModelImplementations.ProbabilityModels;
using Microsoft.AspNetCore.Mvc;

namespace master_backend.Controllers.ProbabilityControllers;

[ApiExplorerSettings(GroupName = "Probability")]
[ApiController]
[Route("api/[controller]")]
public class BusinessCategoryActionController : ControllerBase
{
    private readonly IBusinessCategoryActionRepository _repo;
    public BusinessCategoryActionController(IBusinessCategoryActionRepository repo) => _repo = repo;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BusinessCategoryAction>>> GetAll()
        => Ok(await _repo.GetBusinessCategoryActionsAsync());

    [HttpGet("{id:long}")]
    public async Task<ActionResult<BusinessCategoryAction>> GetById(long id)
        => (await _repo.GetBusinessCategoryActionByIdAsync(id)) is { } a ? Ok(a) : NotFound();

    [HttpGet("by-business-category/{businessCategoryId:long}")]
    public async Task<ActionResult<IEnumerable<BusinessCategoryAction>>> GetByBusinessCategory(long businessCategoryId)
        => Ok(await _repo.GetBusinessCategoryActionsByBusinessCategoryIdAsync(businessCategoryId));

    [HttpPost]
    public async Task<ActionResult<BusinessCategoryAction>> Create([FromBody] BusinessCategoryAction action)
    {
        if (!ModelState.IsValid) return ValidationProblem(ModelState);
        var created = await _repo.CreateBusinessCategoryActionAsync(action);
        return CreatedAtAction(nameof(GetById),
            new { id = created.businessCategoryActionId }, created);
    }

    [HttpPut("{id:long}")]
    public async Task<ActionResult<BusinessCategoryAction>> Update(long id, [FromBody] BusinessCategoryAction action)
    {
        if (id != action.businessCategoryActionId)
            return BadRequest(new { message = "Route id and body id must match." });

        if ((await _repo.GetBusinessCategoryActionByIdAsync(id)) is null)
            return NotFound();

        var updated = await _repo.UpdateBusinessCategoryActionAsync(action);
        return Ok(updated);
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id)
    {
        var ok = await _repo.DeleteBusinessCategoryActionAsync(id);
        return ok ? NoContent() : NotFound();
    }
}