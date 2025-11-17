using System.ComponentModel.DataAnnotations;

namespace master_backend.Models.ModelImplementations.BlockModels;

public class Block
{
    [Key]
    public long blockId { get; set; }
    
    [Required, MaxLength(80)]
    public string blockTitle { get; set; } = string.Empty;
    
    [Required, MaxLength(500)]
    public string blockDescription { get; set; } = string.Empty;
    
    [Required, MaxLength(5000)]
    public string blockHTML { get; set; } = string.Empty;
}