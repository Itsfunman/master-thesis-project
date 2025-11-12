using backend.FormGeneration.DatabaseAccessor.Models.GeneralDataModels;
using backend.FormGeneration.DataInterface;
using Microsoft.AspNetCore.Mvc;

namespace backend.FormGeneration.DatabaseAccessor.Controllers.GeneralControllers;

[ApiController]
[Route("api/departmentTable")]
public class DepartmentController : ControllerBase
{
    private readonly IDepartmentRepository _departmentRepository;

    public DepartmentController(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    [HttpGet("{id:long}", Name = "GetDepartmentById")]
    public async Task<IActionResult> GetDepartmentByIdAsync(long id)
    {
        var department = await _departmentRepository.GetDepartmentByIdAsync(id);
        return department == null ? NotFound() : Ok(department);
    }

    [HttpPost]
    public async Task<IActionResult> AddDepartmentAsync([FromBody] Department department)
    {
        var created = await _departmentRepository.CreateDepartmentAsync(department);
        return CreatedAtRoute("GetDepartmentById",
            new { id = created.DepartmentID }, created);
    }
}