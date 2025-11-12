using backend.FormGeneration.DatabaseAccessor.Models.GeneralDataModels;
using backend.FormGeneration.DataInterface;
using backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend.FormGeneration.DatabaseAccessor.Controllers.GeneralControllers;

[ApiController]
[Route("api/businessTable")]
public class BusinessController : ControllerBase
{
    private readonly IBusinessRepository _businessRepository;

    public BusinessController(IBusinessRepository businessRepository)
    {
        _businessRepository = businessRepository;
    }

    [HttpGet("{id:long}", Name = "GetBusinessById")]
    public async Task<IActionResult> GetBusinessByIdAsync(long id)
    {
        var business = await _businessRepository.GetBusinessByIdAsync(id);
        return business == null ? NotFound() : Ok(business);
    }

    [HttpPost]
    public async Task<IActionResult> CreateBusinessAsync([FromBody] Business business)
    {
        var created = await _businessRepository.CreateBusinessAsync(business);

        return CreatedAtRoute("GetBusinessById", new { id = created.BusinessID }, created);
    }
}