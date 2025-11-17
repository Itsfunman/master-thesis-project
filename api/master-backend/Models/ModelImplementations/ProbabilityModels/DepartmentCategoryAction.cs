using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using master_backend.Models.ModelImplementations.GeneralModels;

namespace master_backend.Models.ModelImplementations.ProbabilityModels;

public class DepartmentCategoryAction
{
    [Key]
    public long departmentCategoryActionId { get; set; }
    
    [Required]
    public long departmentCategoryId { get; set; }

    [Required]
    public int totalActions { get; set; } = 0;
    
    [ForeignKey(nameof(departmentCategoryId))]
    public DepartmentCategory? departmentCategory { get; set; }
}