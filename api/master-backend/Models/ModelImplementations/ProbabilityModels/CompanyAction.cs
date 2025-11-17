using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using master_backend.Models.ModelImplementations.GeneralModels;

namespace master_backend.Models.ModelImplementations.ProbabilityModels;

public class CompanyAction
{
    [Key]
    public long companyActionId { get; set; }
    
    [Required]
    public long companyId { get; set; }

    [Required]
    public int totalActions { get; set; } = 0;
    
    [ForeignKey(nameof(companyId))]
    public Company? company { get; set; }
}
