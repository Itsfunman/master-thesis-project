using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using master_backend.Models.ModelImplementations.BlockModels;

namespace master_backend.Models.ModelImplementations.ProbabilityModels;

public class CompanyProbability
{
    [Key]
    public long companyProbabilityId { get; set; }
    
    [Required]
    public long companyActionId { get; set; }
    
    [Required]
    public long blockId { get; set; }
    
    [Required]
    public int timesUsed { get; set; }
    
    [Required]
    public DateTime lastUsed { get; set; }
    
    [ForeignKey(nameof(companyActionId))]
    public CompanyAction? companyAction { get; set; }
    
    [ForeignKey(nameof(blockId))]
    public Block? block { get; set; }
}