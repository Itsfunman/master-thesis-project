using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using master_backend.Models.ModelImplementations.BlockModels;

namespace master_backend.Models.ModelImplementations.ProbabilityModels;

public class DepartmentCategoryProbability
{
    [Key]
    public long departmentCategoryProbabilityId { get; set; }
    
    [Required]
    public long departmentCategoryActionId { get; set; }
    
    [Required]
    public long blockId { get; set; }
    
    [Required]
    public int timesUsed { get; set; }
    
    [Required]
    public DateTime lastUsed { get; set; }
    
    [ForeignKey(nameof(departmentCategoryActionId))]
    public DepartmentCategoryAction? departmentCategoryAction { get; set; }
    
    [ForeignKey(nameof(blockId))]
    public Block? block { get; set; }
}