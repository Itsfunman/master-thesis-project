using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using master_backend.Models.ModelImplementations.GeneralModels;

namespace master_backend.Models.ModelImplementations.ProbabilityModels;

public class BusinessCategoryAction
{
    [Key]
    public long businessCategoryActionId { get; set; }
    
    [Required]
    public long businessCategoryId { get; set; }

    [Required]
    public int totalActions { get; set; } = 0;
    
    [ForeignKey(nameof(businessCategoryId))]
    public BusinessCategory? businessCategory { get; set; }
}