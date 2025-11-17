using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using master_backend.Models.ModelImplementations.BlockModels;

namespace master_backend.Models.ModelImplementations.ProbabilityModels;

public class BlockProbabilityHistory
{
    [Key]
    public long blockProbabilityHistoryId { get; set; }
    
    [Required]
    public long blockId { get; set; }
    
    [Required]
    public long userProbabilityId { get; set; }
    
    [Required]
    public long departmentCategoryProbabilityId { get; set; }
    
    [Required]
    public long companyProbabilityId { get; set; }
    
    [Required]
    public long businessCategoryProbabilityId { get; set; }
    
    [Required]
    public float probability { get; set; }
    
    [Required]
    public DateTime lastUsed { get; set; }
    
    [ForeignKey(nameof(blockId))]
    public Block? block { get; set; }
    
    [ForeignKey(nameof(userProbabilityId))]
    public UserProbability? userProbability { get; set; }
    
    [ForeignKey(nameof(departmentCategoryProbabilityId))]
    public DepartmentCategoryProbability? departmentCategoryProbability { get; set; }
    
    [ForeignKey(nameof(companyProbabilityId))]
    public CompanyProbability? companyProbability { get; set; }
    
    [ForeignKey(nameof(businessCategoryProbabilityId))]
    public BusinessCategoryProbability? businessCategoryProbability { get; set; }
}