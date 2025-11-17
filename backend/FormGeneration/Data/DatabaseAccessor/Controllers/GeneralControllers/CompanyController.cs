using backend.FormGeneration.DatabaseAccessor.Models.GeneralDataModels;
using backend.FormGeneration.DataInterface;
using Microsoft.AspNetCore.Mvc;

namespace backend.FormGeneration.DatabaseAccessor.Controllers.GeneralControllers;

[ApiController]
[Route("api/companyTable")]
public class CompanyController : ControllerBase
{
    private readonly ICompanyRepository _companyRepository;

    public CompanyController(ICompanyRepository companyRepository)
    {
        _companyRepository = companyRepository;
    }

    [HttpGet("{id:long}", Name = "GetCompanyById")]
    public async Task<IActionResult> GetCompanyByIdAsync(long id)
    {
        var company = await _companyRepository.GetCompanyByIdAsync(id);
        return company == null ? NotFound() : Ok(company);
    }

    [HttpPost]
    public async Task<IActionResult> AddCompanyAsync([FromBody] Company company)
    {
        var created = await _companyRepository.CreateCompanyAsync(company);
        return CreatedAtRoute("GetCompanyById", new { id = created.CompanyId }, company);
    }
}