using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using master_backend.Models.ModelImplementations.GeneralModels;

namespace master_backend.Models.ModelImplementations.ProbabilityModels;

public class UserAction
{
    [Key]
    public long userActionId { get; set; }
    
    [Required]
    public long userId { get; set; }

    [Required]
    public int totalActions { get; set; } = 0;
    
    [ForeignKey(nameof(userId))]
    public User? user { get; set; }
}