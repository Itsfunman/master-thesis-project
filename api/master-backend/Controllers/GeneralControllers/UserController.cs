using master_backend.Models.IRepository.GeneralIRepositories;
using master_backend.Models.ModelImplementations.GeneralModels;
using Microsoft.AspNetCore.Mvc;

namespace master_backend.Controllers.GeneralControllers;

[ApiExplorerSettings(GroupName = "General")]
[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _repo;
    public UserController(IUserRepository repo) => _repo = repo;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetAll()
        => Ok(await _repo.GetUsersAsync());

    [HttpGet("{id:long}")]
    public async Task<ActionResult<User>> GetById(long id)
        => (await _repo.GetUserByIdAsync(id)) is { } u ? Ok(u) : NotFound();

    [HttpGet("by-email/{email}")]
    public async Task<ActionResult<User>> GetByEmail(string email)
        => (await _repo.GetUserByEmailAsync(email)) is { } u ? Ok(u) : NotFound();

    [HttpGet("by-company/{companyId:long}")]
    public async Task<ActionResult<IEnumerable<User>>> GetByCompany(long companyId)
        => Ok(await _repo.GetUsersByCompanyIdAsync(companyId));

    [HttpGet("by-department-category/{departmentCategoryId:long}")]
    public async Task<ActionResult<IEnumerable<User>>> GetByDepartmentCategory(long departmentCategoryId)
        => Ok(await _repo.GetUsersByDepartmentCategoryIdAsync(departmentCategoryId));

    [HttpGet("by-business-category/{businessCategoryId:long}")]
    public async Task<ActionResult<IEnumerable<User>>> GetByBusinessCategory(long businessCategoryId)
        => Ok(await _repo.GetUsersByBusinessCategoryIdAsync(businessCategoryId));

    [HttpPost]
    public async Task<ActionResult<User>> Create([FromBody] User user)
    {
        if (!ModelState.IsValid) return ValidationProblem(ModelState);
        var created = await _repo.CreateUserAsync(user);
        return CreatedAtAction(nameof(GetById), new { id = created.UserId }, created);
    }

    [HttpPut("{id:long}")]
    public async Task<IActionResult> Update(long id, [FromBody] User user)
    {
        if (id != user.UserId)
            return BadRequest(new { message = "Route id and body id must match." });

        if ((await _repo.GetUserByIdAsync(id)) is null)
            return NotFound();

        await _repo.UpdateUserAsync(user);
        return NoContent();
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id)
    {
        var ok = await _repo.DeleteUserAsync(id);
        return ok ? NoContent() : NotFound();
    }
}